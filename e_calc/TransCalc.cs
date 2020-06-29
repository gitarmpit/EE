using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forms1
{
    struct trans_calc_result
    {
        public string res_length_m;
        public string res_length_ft;
        public string res_thickness_mms;
        public string res_resistivity;
        public string res_totalLayers;
        public string edit_turnsPerLayer;
        public string res_lastLayerTurns;
        public string edit_N;
    }

    class TransCalc
    {

        public trans_calc_result calculate(string s_bMax, double d, string s_l, string s_w, string s_h,
            string s_wfactor, string s_N, string s_coreW, string s_coreH, string s_turnsPerLayer)
        {
            double bMax = double.Parse(s_bMax);
            double l = double.Parse(s_l) * 10;
            double w = double.Parse(s_w) * 10;
            double h = double.Parse(s_h) * 10;
            double wfactor = double.Parse(s_wfactor);
            double N = s_N.Length > 0 ? int.Parse(s_N) : 0.0;
            //cm
            double core_w = double.Parse(s_coreW);
            double core_h = double.Parse(s_coreH);

            if (wfactor < 0.5)
            {
                wfactor = 0.5;
            }

            double dl = d / wfactor;
            double dh = d / wfactor;
            if ((int)w == 0 || (int)h == 0)
            {
                throw new Exception("w h can't be empty");
            }

            trans_calc_result res = new trans_calc_result();

            if ((int)N == 0)
            {
                double E = 120;
                double f = 60;

                N = E / (4.443 * bMax * core_w * core_h * .0001 * f);
                res.edit_N = ((int)N).ToString();
            }


            int turnsPerLayer = s_turnsPerLayer.Length > 0 ? int.Parse(s_turnsPerLayer) : 0;

            if (turnsPerLayer == 0)
            {
                turnsPerLayer = (int)(l / dl);
            }

            if (turnsPerLayer == 0)
            {
                throw new Exception("turns per layer is zero");
            }

            int totalLayers = (int)(N / (double)turnsPerLayer);

            int lastTurns = (int)N - (totalLayers * turnsPerLayer);

            if (lastTurns == 0)
            {
                lastTurns = turnsPerLayer;
            }
            else
            {
                ++totalLayers;
            }

            double length = 0;
            double turnsPerLayerSaved = turnsPerLayer;

            for (int i = 0; i < totalLayers; ++i)
            {
                double delta = dh * (double)i;
                if (i == totalLayers - 1)
                {
                    turnsPerLayerSaved = lastTurns;
                }

                double p = 2.0 * (w + h + 2.0 * delta);
                length += p * turnsPerLayerSaved;

            }

            double length_m = length / 1000.0;
            double length_f = length * 0.0032808;
            double thickness = totalLayers * dh;
            double resistivity = length / 1000 * 1.678e-8 / (3.14159 * d / 2 / 1000.0 * d / 2 / 1000.0);

            res.res_length_m = String.Format("{0:0.##}", length_m);
            res.res_length_ft = String.Format("{0:0.##}", length_f);
            res.res_thickness_mms = String.Format("{0:0.##}", thickness);
            res.res_resistivity = String.Format("{0:0.##}", resistivity);
            res.res_totalLayers = totalLayers.ToString();
            res.edit_turnsPerLayer = turnsPerLayer.ToString();
            res.res_lastLayerTurns = lastTurns.ToString();

            return res;

        }
    }
}
