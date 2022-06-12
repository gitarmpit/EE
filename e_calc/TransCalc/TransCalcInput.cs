using System;
using System.Globalization;

namespace TransCalc
{
    public struct trans_calc_input_common
    {
        public double Vin;
        public double Freq;
        public double B_max;
        public double permeability;
        public double I_ex;
        public double H;

        public double Core_L;
        public double Core_W;
        public double Core_H;
        public double Ae_W;
        public double Ae_H;
        public double pf1;

        public double mpath_l_cm;
        public double max_temp;
        public double max_eq_R;

        public double WindowSize;
        public double CouplingCoeff;
        public double StackingFactor;
        public double InsulationThickness;

        public double Vout;
        public double Iout_max;
        public bool IsVoutAtFullLoad;
    }
    public struct trans_calc_input_winding
    {
        public AWG awg;
        public double w_factor;
        public int N;
        public int N_per_layer;
        public int ampacity_mil_per_amp;
    }

    /*
    public struct trans_calc_input
    {
        public trans_calc_input_common common;
        public trans_calc_input_winding primary;
        public trans_calc_input_winding secondary;
        public bool processSecondary;
        public bool isMinimizeRegulation;
    }
    */

    public class TransCalcInput
    {
        public trans_calc_input_common common;
        public trans_calc_input_winding primary;
        public trans_calc_input_winding secondary;
        public bool processSecondary;
        public bool isMinimizeRegulation;
        private TransCalc tc;

        public TransCalcInput (TransCalc tc)
        {
            this.tc = tc;
        }

        public void ConvertTextToInput(trans_calc_input_text strin)
        {
            common = new trans_calc_input_common();
            primary = new trans_calc_input_winding();

            if (strin.Vin == "")
            {
                throw new Exception("Vin not set");
            }
            common.Vin = double.Parse(strin.Vin, NumberStyles.Float);
            if (strin.Vin == "120")
            {
                common.Freq = 60;
            }
            else if (strin.Vin == "220")
            {
                common.Freq = 50;
            }
            else
            {
                throw new Exception($"Unexpected mains voltage: {strin.Vin}, 110 or 220 expected");
            }

            common.IsVoutAtFullLoad = strin.isVoutAtFullLoad;

            if (strin.Bmax == "" && strin.N1 == "")
            {
                throw new Exception("Either Bmax or Primary turns must be set");
            }

            if (strin.Bmax != "")
            {
                common.B_max = double.Parse(strin.Bmax, NumberStyles.Float);
                if (common.B_max < 0.1 || common.B_max > 2)
                {
                    throw new Exception("Bmax, has to be in the range of 0.1T to 2T");
                }
            }

            if (strin.permeability != "")
            {
                common.permeability = double.Parse(strin.permeability, NumberStyles.Float);
                if (common.permeability < 1000 || common.permeability > 10000)
                {
                    throw new Exception("Permeability has to be in the range of 1000 to 10000");
                }
            }

            if (strin.I_ex != "")
            {
                // from mA to A
                common.I_ex = double.Parse(strin.I_ex, NumberStyles.Float) / 1000;
                if (common.I_ex < 0.01 || common.I_ex > 2)
                {
                    throw new Exception("Iex has to be in the range of 10mA to 2A");
                }
            }

            if (strin.H != "")
            {
                common.H = double.Parse(strin.H, NumberStyles.Float);
                if (tc.H_Units == TransCalc.H_UNITS.OERSTEDS)
                {
                    common.H = TransCalc.Oe_to_Ampturns(common.H);
                }
                else if (tc.H_Units == TransCalc.H_UNITS.AMP_TURNS_IN)
                {
                    common.H /= 0.0254;
                }
                if (common.H < 1 || common.H > 2000)
                {
                    throw new Exception("Amp t / m has to be in the range of 1 to 2000 Amp-t-m");
                }
            }

            if (strin.core_L == "" || strin.core_W == "" || strin.core_H == "")
            {
                throw new Exception("Core W/H/L not set");
            }

            if (strin.pf != "")
            {
                common.pf1 = double.Parse(strin.pf, NumberStyles.Float);
                if (common.pf1 < 0 || common.pf1 > 1.0)
                {
                    throw new Exception("pf has to be between 0 and 1");
                }
            }

            //to m
            common.Core_L = double.Parse(strin.core_L, NumberStyles.Float) / 100;
            common.Core_W = double.Parse(strin.core_W, NumberStyles.Float) / 100;
            common.Core_H = double.Parse(strin.core_H, NumberStyles.Float) / 100;

            if (common.Core_L < 0.01 || common.Core_L > 0.5)
            {
                throw new Exception("Invalid core L");
            }
            if (common.Core_W < 0.01 || common.Core_W > 0.5)
            {
                throw new Exception("Invalid core W");
            }
            if (common.Core_H < 0.01 || common.Core_H > 0.5)
            {
                throw new Exception("Invalid core H");
            }

            if (strin.Ae_W == "" || strin.Ae_H == "")
            {
                throw new Exception("Ae W/H not set");
            }
            //to m
            common.Ae_W = double.Parse(strin.Ae_W) / 100;
            if (common.Ae_W < 0.01 || common.Ae_W > 0.5)
            {
                throw new Exception("Invalid Ae width");
            }
            common.Ae_H = double.Parse(strin.Ae_H) / 100;
            if (common.Ae_H < 0.01 || common.Ae_H > 0.5)
            {
                throw new Exception("Invalid Ae height");
            }

            if (common.Ae_W > common.Core_W)
            {
                throw new Exception("Ae_W > bobbin W");
            }

            if (common.Ae_H > common.Core_H)
            {
                throw new Exception("Ae_H > bobbin H");
            }

            if (strin.mpath_H != "" && strin.mpath_W != "")
            {
                //cm 
                double Mpath_H = double.Parse(strin.mpath_H, NumberStyles.Float) / 100;
                double Mpath_W = double.Parse(strin.mpath_W, NumberStyles.Float) / 100;

                if (Mpath_H < 0.01 || Mpath_H > 0.5)
                {
                    throw new Exception("Invalid magnetic path value: H");
                }

                if (Mpath_W < 0.01 || Mpath_W > 0.5)
                {
                    throw new Exception("Invalid magnetic path value: W");
                }

                common.mpath_l_cm = (Mpath_H + Mpath_W) * 2;
            }

            if (strin.window_size != "")
            {
                // in cm
                common.WindowSize = double.Parse(strin.window_size, NumberStyles.Float);
                if (common.WindowSize < 0.1 || common.WindowSize > 50)
                {
                    throw new Exception("Invalid window size in cm");
                }
            }

            if (strin.coupling_coeff == "")
            {
                throw new Exception("Coupling coefficient not set");
            }

            common.CouplingCoeff = double.Parse(strin.coupling_coeff, NumberStyles.Float);
            if (common.CouplingCoeff < 0.5 || common.CouplingCoeff > 1.0)
            {
                throw new Exception("Coupling coefficient has to be in the range of 0.5 to 1.0");
            }

            if (strin.stackingFactor == "")
            {
                throw new Exception("Stacking factor not set");
            }

            common.StackingFactor = double.Parse(strin.stackingFactor, NumberStyles.Float);
            if (common.StackingFactor < 0.5 || common.StackingFactor > 1.0)
            {
                throw new Exception("Stacking factor has to be in the range of 0.5 to 1.0");
            }

            if (strin.insulationThickness != "")
            {
                common.InsulationThickness = double.Parse(strin.insulationThickness, NumberStyles.Float);
            }

            if (common.WindowSize > 0.0000001)
            {
                if (common.InsulationThickness < 0 || common.InsulationThickness > common.WindowSize)
                {
                    throw new Exception("Insulation thickness in mm cannot exceed window size");
                }
            }

            if (strin.Vout != "")
            {
                common.Vout = double.Parse(strin.Vout, NumberStyles.Float);
                if (common.Vout < 0.1)
                {
                    throw new Exception("Invalid Vout value");
                }
            }

            if (strin.Iout_max != "")
            {
                common.Iout_max = double.Parse(strin.Iout_max, NumberStyles.Float);
                if (common.Iout_max < 0.00000000001)
                {
                    throw new Exception("Invalid Iout_max value");
                }
            }

            common.max_temp = double.Parse(strin.maxTemp, NumberStyles.Float);
            if (!tc.IsTempUnitsC)
            {
                common.max_temp = TransCalc.F_to_C(common.max_temp);
            }

            if (common.max_temp < 20)
            {
                common.max_temp = 20;
            }

            if (strin.max_eq_R != "")
            {
                common.max_eq_R = double.Parse(strin.max_eq_R, NumberStyles.Float);
                if (common.max_eq_R < 1)
                {
                    throw new Exception("Invalid value of max equivalent R");
                }
            }

            primary = convertWinding("Primary", strin.awg1, strin.wfactor1, strin.N1, strin.N_per_layer1, strin.ampacity1);

            if ((strin.N2 != "" || strin.Vout != ""))
            {
                secondary = convertWinding("Secondary", strin.awg2, strin.wfactor2, strin.N2, strin.N_per_layer2, strin.ampacity2);
                processSecondary = true;
            }
            else
            {
                processSecondary = false;
            }

            isMinimizeRegulation = strin.isMinimizeRegulation;
        }
        private trans_calc_input_winding convertWinding(string winding, string sawg, string wfactor,
            string N, string N_per_layer, string ampacity_cm_per_amp)
        {
            trans_calc_input_winding w = new trans_calc_input_winding();

            AWG awg = null;

            if (sawg != "")
            {
                awg = parseAWG(sawg);
            }

            if (ampacity_cm_per_amp != "")
            {
                int cm_per_amp = int.Parse(ampacity_cm_per_amp, NumberStyles.Integer);
                if (cm_per_amp < 300 || cm_per_amp > 1000)
                {
                    throw new Exception("Cm per ampere should be between 300 and 1000");
                }
                w.ampacity_mil_per_amp = cm_per_amp;
            }

            w.awg = awg;
            if (wfactor == "")
            {
                throw new Exception("W factor not set");
            }

            w.w_factor = double.Parse(wfactor, NumberStyles.Float);
            if (w.w_factor < .5 || w.w_factor > 1)
            {
                throw new Exception($"{winding}: W factor has to be in the range of 0.5 to 1");
            }

            if (N != "")
            {
                w.N = int.Parse(N, NumberStyles.Integer);
                if (w.N < 1)
                {
                    throw new Exception("Invalid value for turns");
                }
            }

            if (N_per_layer != "")
            {
                w.N_per_layer = int.Parse(N_per_layer, NumberStyles.Integer);
                if (w.N_per_layer < 1 || w.N_per_layer > w.N)
                {
                    throw new Exception("Invalid value for turns per layer");
                }
            }
            return w;
        }

        private AWG parseAWG(string text)
        {
            int awg_gauge = int.Parse(text, NumberStyles.Integer);
            var awg_item = tc.GetAwgByGauge(awg_gauge);
            if (awg_item == null)
            {
                throw new Exception($"Invalid awg #: {text}");
            }

            return awg_item;
        }

    }


}