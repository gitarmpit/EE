using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace forms1
{
    struct trans_calc_result
    {
        public double res_length_m;
        public double res_length_ft;
        public double res_thickness_mms;
        public double res_resistance;
        public int    res_totalLayers;
        public int    res_N_per_layer;
        public int    res_lastLayerTurns;
        public int    res_N;
    }

    struct trans_calc_input_common
    {
        public double B_max;
        public double L;
        public double W;
        public double H;
        public double Ae_W;
        public double Ae_H;
    }

    struct trans_calc_input_winding
    {
        public double awg;
        public double w_factor;
        public double N;
        public double N_per_layer;
    }

    struct trans_calc_input
    {
        public trans_calc_input_common common;
        public trans_calc_input_winding primary;
        public trans_calc_input_winding secondary;
        public bool processSecondary;
    }

    class TransCalc
    {
        public TransCalc()
        {
        }

        private trans_calc_input_winding processWinding(string winding, double awg, string wfactor, string N, string N_per_layer)
        {
            trans_calc_input_winding res = new trans_calc_input_winding();
            res.awg = awg / 1000;  //meters
            res.w_factor = double.Parse(wfactor);
            res.N = N.Length > 0 ? int.Parse(N) : 0.0;
            if (res.w_factor < .5 && res.w_factor > 1)
            {
                throw new Exception($"{winding}: W factor has to be in the range of 0.5 to 1");
            }

            res.N_per_layer = N_per_layer.Length > 0 ? int.Parse(N_per_layer) : 0;
            return res;
        }

        public trans_calc_input convertToInput(
            string bMax, 
            string l, string w, string h,
            string coreL, string coreW,
            double awg1, string wfactor1, string N1, string N_per_layer1,
            double awg2, string wfactor2, string N2, string N_per_layer2)
        {
            trans_calc_input res =  new trans_calc_input();
            res.common = new trans_calc_input_common();
            res.primary = new trans_calc_input_winding();

            res.common.B_max = double.Parse(bMax, NumberStyles.Float);
            if (res.common.B_max < 0.1 || res.common.B_max > 10)
            {
                throw new Exception("Bmax has to be in the range of 0.1 to 10");
            }

            //to m
            res.common.L = double.Parse(l, NumberStyles.Float) / 100;
            res.common.W = double.Parse(w, NumberStyles.Float) / 100;
            res.common.H = double.Parse(h, NumberStyles.Float) / 100;

            if (res.common.L < 0.01 || res.common.L > 0.5)
            {
                throw new Exception("Invalid bobbin length");
            }
            if (res.common.W < 0.01 || res.common.W > 0.5)
            {
                throw new Exception("Invalid bobbin width");
            }
            if (res.common.H < 0.01 || res.common.H > 0.5)
            {
                throw new Exception("Invalid bobbin height");
            }

            //to m
            res.common.Ae_W = double.Parse(coreW) / 100;
            if (res.common.Ae_W < 0.01 || res.common.Ae_W > 0.5)
            {
                throw new Exception("Invalid Ae width");
            }
            res.common.Ae_H = double.Parse(coreL) / 100;
            if (res.common.Ae_H < 0.01 || res.common.Ae_H > 0.5)
            {
                throw new Exception("Invalid Ae height");
            }

            if (res.common.Ae_W > res.common.W)
            {
                throw new Exception("Ae_W > bobbin W");
            }

            if (res.common.Ae_H > res.common.H)
            {
                throw new Exception("Ae_H > bobbin H");
            }

            res.primary = processWinding("Primary", awg1, wfactor1, N1, N_per_layer1);
            if (N2 != "" && wfactor2 != "")
            {
                res.secondary = processWinding("Secondary", awg2, wfactor2, N2, N_per_layer2);
                res.processSecondary = true;
            }
            else
            {
                res.processSecondary = false;
            }


            return res;
        }

        public trans_calc_result calculate(trans_calc_input_common common, trans_calc_input_winding w)
        {
            double dl = w.awg / w.w_factor;
            double dh = w.awg / w.w_factor;

            trans_calc_result res = new trans_calc_result();

            // N not set, calculate it
            if ((int)w.N == 0)
            {
                double E = 120;
                double f = 60;

                w.N = E / (4.443 * common.B_max * common.Ae_W * common.Ae_H  * f);
            }

            if (w.N_per_layer == 0)
            {
                w.N_per_layer = (int)(common.L / dl);
            }

            if (w.N_per_layer == 0)
            {
                throw new Exception("Error: turns per layer calculated to zero");
            }

            int totalLayers = (int)(w.N / (double)w.N_per_layer);

            int lastTurns = (int)w.N - (totalLayers * (int)w.N_per_layer);

            if (lastTurns == 0)
            {
                lastTurns = (int)w.N_per_layer;
            }
            else
            {
                ++totalLayers;
            }

            double length_m = 0;
            double turnsPerLayerSaved = w.N_per_layer;

            for (int i = 0; i < totalLayers; ++i)
            {
                double delta = dh * (double)i;
                if (i == totalLayers - 1)
                {
                    turnsPerLayerSaved = lastTurns;
                }

                double p = 2.0 * (common.W + common.H + 2.0 * delta);
                length_m += p * turnsPerLayerSaved;
            }

            double length_f = length_m * 3.28084;
            double thickness = totalLayers * dh;
            double resistance = length_m * 1.678e-8 / (Math.PI * Math.Pow (w.awg / (double)2, 2));

            res.res_length_m = length_m;
            res.res_length_ft = length_f;
            res.res_thickness_mms = thickness * 1000;
            res.res_resistance = resistance;
            res.res_totalLayers = totalLayers;
            res.res_N = (int)w.N;
            res.res_N_per_layer = (int)w.N_per_layer;
            res.res_lastLayerTurns = (lastTurns == (int)w.N_per_layer) ? 0 : lastTurns;

            return res;

        }
    }
}
