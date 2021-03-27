using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace TransCalc
{
    public class TransCalc
    {
        private static double u0 = 4 * Math.PI * 10e-8;
        private List<AWG> awgValues = new List<AWG>();
        private double lbs_in_g = 0.00220462262185;

        public enum H_UNITS
        {
            AMP_TURNS_M,
            AMP_TURNS_IN,
            OERSTEDS
        }

        private bool tempUnitsC = true;
        private H_UNITS H_units;
        private bool mass_units_g = true;
        private string[] H_labels = new string[] { "Amp-t/m", "Amp-t/in", "Oe" };

        private TransCalcInput _input;
        private trans_calc_result _result;
        private FilePersistence _filePersistence;

        public TransCalc()
        {
            awgValues.AddRange(new AWG[] {
            new AWG(35, 0.14224),
            new AWG(34, 0.16002),
            new AWG(33, 0.18034),
            new AWG(32, 0.2032),
            new AWG(31, 0.22606),
            new AWG(30, 0.254),
            new AWG(29, 0.28702),
            new AWG(28, 0.32004),
            new AWG(27, 0.36068),
            new AWG(26, 0.40386),
            new AWG(25, 0.45466),
            new AWG(24, 0.51054),
            new AWG(23, 0.57404),
            new AWG(22, 0.64516),
            new AWG(21, 0.7239),
            new AWG(20, 0.8128),
            new AWG(19, 0.91186),
            new AWG(18, 1.02362),
            new AWG(17, 1.15062),
            new AWG(16, 1.29032),
            new AWG(15, 1.45034),
            new AWG(14, 1.62814),
            new AWG(13, 1.8288),
            new AWG(12, 2.05232),
            new AWG(11, 2.30378),
            new AWG(10, 2.58826),
            new AWG(9, 2.90576),
            new AWG(8, 3.2639)
            });

            _input = new TransCalcInput(this);
            _filePersistence = new FilePersistence(this);
        }


        public H_UNITS H_Units
        {
            get { return H_units; }
            set { H_units = value; }
        }

        public bool IsTempUnitsC
        {
            get { return tempUnitsC; }
            set { tempUnitsC = value; }
        }

        public bool IsMassUnits_g
        {
            get { return mass_units_g; }
            set { mass_units_g = value; }
        }

        public string MassUnitsLabel
        {
            get { return IsMassUnits_g ? "g" : "lbs";  }
        }

        public string TempUnitsLabel
        {
            get { return IsTempUnitsC ? "C" : "F"; }
        }

        public string HUnitlsLabel
        {
            get 
            {
                return H_labels[(int)H_Units];
            }
        }

        public static double F_to_C(double f)
        {
            return (f - 32) * 5 / 9;
        }

        public static double C_to_F (double c)
        {
            return (c * 9 / 5) + 32;
        }

        public string UpdateTempText(string stemp)
        {
            double dtemp = double.Parse(stemp, NumberStyles.Float);
            double converted_temp = IsTempUnitsC ?  C_to_F(dtemp) : F_to_C(dtemp);
            return String.Format("{0:0.#}", converted_temp);
        }

        public static double AmpTurns_to_Oe (double at)
        {
            return at * 4 * Math.PI / 1000;
        }

        public static double Oe_to_Ampturns (double oe)
        {
            return oe * 1000 / (4 * Math.PI);
        }

        public double Convert_H(double dH, H_UNITS to_units)
        {
            if (to_units != H_Units)
            {
                if (H_Units == H_UNITS.AMP_TURNS_IN)
                {
                    dH = dH / 0.0254;
                }
                if (to_units == H_UNITS.OERSTEDS)
                {
                    dH = AmpTurns_to_Oe(dH);
                }
                else if (H_Units == H_UNITS.OERSTEDS)
                {
                    dH = Oe_to_Ampturns(dH);
                }
                if (to_units == H_UNITS.AMP_TURNS_IN)
                {
                    dH = dH * 0.0254;
                }
                H_Units = to_units;
            }
            return dH;
        }

        public void SetHUnits (string s)
        {
            H_Units = (H_UNITS)int.Parse(s);
        }

        public AWG GetAwgByGauge(int gauge)
        {
            return awgValues.Where(v => v.Gauge == gauge).FirstOrDefault();
        }

        public trans_calc_input_text Load(string fileName)
        {
            return _filePersistence.Load(fileName);
        }

        public void SaveResults(trans_calc_input_text strin, trans_calc_result_text result, string fileName)
        {
            _filePersistence.SaveResults(strin, result, fileName);
        }

        public void SaveSettings(trans_calc_input_text strin, string fileName)
        {
            _filePersistence.SaveSettings(strin, fileName);
        }

        private void CalculatePrimaryCurrent()
        {
            double ph0 = Math.Acos(_input.common.pf1);
            if (_result.turns_ratio < 0.000001)
            {
                throw new Exception("Turns ratio has not been calculated");
            }

            double Ip_re = _input.common.Iout_max / _result.turns_ratio + _result.I_ex * _input.common.pf1;
            double Ip_im = _result.I_ex * Math.Sin(ph0);
            _result.Ip_full_load =
                Math.Sqrt(Math.Pow(Ip_re, 2) + Math.Pow(Ip_im, 2));
        }

        private void CalculateTurnsRatio ()
        {
            if (_input.common.Vout > 0.00000001 && _input.secondary.N == 0)
            {
                _input.secondary.N = (int)(_input.primary.N / _input.common.Vin * _input.common.Vout / _input.common.CouplingCoeff);
            }
            else if (_input.secondary.N > 0)
            {
                _input.common.Vout = _input.common.Vin / _input.primary.N * _input.secondary.N * _input.common.CouplingCoeff;
            }

            _result.turns_ratio = (double)_input.primary.N / (double)_input.secondary.N;
        }

        public trans_calc_result_text Calculate(trans_calc_input_text text_input)
        {
            _input.ConvertTextToInput(text_input);


            double L1;
            double Ae;
            CalculateCommon(out L1, out Ae);

            // Calculate primary
            bool retry_primary = false;
            int minAWG = 8;
            if (_input.primary.awg == null)
            {
                retry_primary = true;
            }

            if (_input.processSecondary)
            {
                CalculateTurnsRatio();
                CalculatePrimaryCurrent();
            }

            do
            {
                if (retry_primary)
                {
                    _input.primary.awg = AutoSelectAWG(minAWG++, _input.isMinimizeRegulation, _input.primary, _result.Ip_full_load);
                }

                trans_calc_result_winding w1 = calculateWinding(_input.common, _input.primary);
                
                w1.L = L1;
                _result.primary = w1;

                //Calculate secondary if configured 
                if (_input.processSecondary)
                {
                    _result.Iout_max = _input.common.Iout_max;
                    _input.common.Core_H += w1.thickness_mm / 1000;
                    _input.common.Core_W += w1.thickness_mm / 1000;

                    bool retry_secondary = false;
                    minAWG = 8;
                    if (_input.secondary.awg == null)
                    {
                        retry_secondary = true;
                    }

                    trans_calc_result_winding w2 = null;
                    do
                    {
                        if (retry_secondary)
                        {
                            _input.secondary.awg = AutoSelectAWG(minAWG++, _input.isMinimizeRegulation, _input.secondary, _input.common.Iout_max);
                        }

                        w2 = CalculateSecondaryWithRetries(w1.resistance);

                        if (retry_secondary && 
                            (_input.common.WindowSize < 0.000000001 ||
                             w1.thickness_mm + _input.common.InsulationThickness + w2.thickness_mm 
                             <= _input.common.WindowSize))
                        {
                            retry_secondary = false;
                            retry_primary = false;
                        }

                    } while (retry_secondary);

                    if (_result.permeability > 0.00000000001 && _result.mpath_l_m > 0.0000001)
                    {
                        w2.L = w2.N * w2.N * _result.permeability * u0 * Ae / _result.mpath_l_m;
                    }

                    _result.secondary = w2;
                    _result.total_thickness_mm = 
                        w1.thickness_mm + _input.common.InsulationThickness + w2.thickness_mm;
                    _result.wire_total_weight = w1.mass + w2.mass;
                    _result.wire_csa_ratio = w1.awg.Csa_m2 / w2.awg.Csa_m2;
                    _result.wire_weight_ratio = w1.mass / w2.mass;
                }
            }
            while (retry_primary);

            ConvertUnits();

            return new trans_calc_result_text(_result, _input); 
        }

        private trans_calc_result_winding CalculateSecondaryWithRetries(double w1_R)
        {
            int maxAttemps = 100;
            int count = 0;
            double Vout_load = _input.common.Vout;
            trans_calc_result_winding w2;
            while (true)
            {
                w2 = CalculateSecondary(w1_R);
                // TODO have to remember and restore vout_load
                double Vout_ratio = 1 - _result.Vout_load / Vout_load;

                bool recalcVatFullLoad =
                    _input.common.IsVoutAtFullLoad &&
                    _input.common.Iout_max > 0.0000000001 &&
                    _result.Vout_load > 0.0000000000001 &&
                    _result.Vout_idle > 0.0000000000001 &&
                    Math.Abs(Vout_ratio) > 0.00001 &&
                    ++count < maxAttemps;

                if (!recalcVatFullLoad)
                {
                    break;
                }

                double Vdelta = (Vout_load - _result.Vout_load);
                _input.common.Vout += Vdelta;
            }
            return w2;
        }

        private void ConvertUnits ()
        {
            if (H_units == H_UNITS.AMP_TURNS_IN)
            {
                _result.H *= 0.0254;
            }
            else if (H_units == H_UNITS.OERSTEDS)
            {
                _result.H = AmpTurns_to_Oe(_result.H);
            }

            if (!IsMassUnits_g)
            {
                _result.wire_total_weight *= lbs_in_g;
                _result.primary.mass *= lbs_in_g;
                _result.secondary.mass *= lbs_in_g;
            }
        }

        private void CalculateCommon(out double L1, out double Ae)
        {
            double Epeak = _input.common.Vin * Math.Sqrt(2);
            double omega = _input.common.Freq * 2 * Math.PI;
            Ae = _input.common.Ae_W * _input.common.Ae_H * _input.common.StackingFactor;
            double l_m = _input.common.mpath_l_cm;
            double V_in = _input.common.Vin;
            double I_ex = _input.common.I_ex;
            double u = _input.common.permeability;
            double H_peak = _input.common.H;
            
            L1 = 0;

            // N1 not set, calculate it
            if (_input.primary.N == 0)
            {
                _input.primary.N = (int)(Epeak / (_input.common.B_max * Ae * omega));
            }
            else //recalculate Bmax based on N
            {
                _input.common.B_max = Epeak / (_input.primary.N * Ae * omega);
                if (_input.common.B_max > 2)
                {
                    throw new Exception($"Calculated Bmax is too high: {_input.common.B_max}. It has to be <2T. The number of turns is too low");
                }
            }

            if (l_m > 0.0000001)
            {
                //Priority: Iex, permeability, H
                if (I_ex > 0.000000000001)
                {
                    L1 = V_in / (I_ex * omega);
                    u = (L1 * l_m) / (_input.primary.N * _input.primary.N * Ae) / u0;
                    H_peak = _input.common.B_max / u / u0;
                }
                else if (u > 0.0000000000001)
                {
                    L1 = _input.primary.N * _input.primary.N * u * u0 * Ae / l_m;
                    I_ex = V_in / (omega * L1);
                    H_peak = _input.common.B_max / u / u0;
                }
                else if (H_peak > 0.0000000000001)
                {
                    //divide by sqrt(2) to get RMS
                    I_ex = H_peak / _input.primary.N * l_m / Math.Sqrt(2);
                    u = _input.common.B_max / H_peak / u0;
                    L1 = V_in / (I_ex * omega);
                }
            }

            if (u > 0.00000000001 && (u < 100 || u > 20000))
            {
                throw new Exception($"Calculated permeability={u} is not in the expected range of 100 to 20000. Check the values of Bmax/I_ex/H Amp-t-m");
            }

            if (H_peak > 0.00000000001 && (H_peak < 1 || H_peak > 5000))
            {
                throw new Exception($"Calculated H={H_peak} Amp-t-m is not in the expected range of 1 to 5000. Check the values of Bmax/I_ex/Amp-t-m");
            }

            if (L1 > 0.00000000001 && (L1 < 0.1 || L1 > 1000))
            {
                throw new Exception($"Calculated L1={L1} L1 is not in the expected range of 0.1 to 1000H. Check the values of Bmax/I_ex/Amp-t-m");
            }

            _result.mpath_l_m = l_m;
            _result.B_max = _input.common.B_max;
            _result.H = H_peak;
            _result.I_ex = I_ex;
            _result.permeability = u;
        }

        private trans_calc_result_winding CalculateSecondary (double w1_R)
        {
            double Vout = _input.common.Vout;

            trans_calc_result_winding w2 = calculateWinding(_input.common, _input.secondary);

            double Vout_idle = Vout;
            double Vout_load = 0;

            if (_result.turns_ratio < 0.000001)
            {
                throw new Exception("Turns ratio hasn't been calculated");
            }

            double total_R = w1_R / _result.turns_ratio / _result.turns_ratio + w2.resistance;

            if (_input.common.Iout_max > 0.0000000001)
            {
                double regulation_vdrop = _input.common.Iout_max * total_R;
                if (regulation_vdrop > Vout_idle / 2)
                {
                    throw new Exception($"Voltage drop too high: {regulation_vdrop}. Check Iout, Vout, wire ga");
                }
                
                Vout_load = Vout_idle - regulation_vdrop;

                _result.Iout_max = _input.common.Iout_max;
                _result.power_VA = _result.Iout_max * Vout_load;
                _result.regulation = (Vout_idle - Vout_load) / Vout_idle * 100;
            }

            _result.Vout_idle = Vout_idle;
            _result.Vout_load = Vout_load;
            _result.total_eq_R = total_R;
            return w2;

        }

        private AWG AutoSelectAWG(int minAWG, bool isMinimizeRegulation, trans_calc_input_winding w, double requiredCurrent)
        {
            var awgList = awgValues.Where(v => (v.Gauge >= minAWG));
            if (isMinimizeRegulation)
            {
                awgList = awgList.Reverse();
            }

            AWG awg;

            if (requiredCurrent > 0.0000000001 && w.ampacity_mil_per_amp > 0.000000001)
            {
                awg = awgList.Where(v => v.GetMaxCurrent(w.ampacity_mil_per_amp) >= requiredCurrent).
                    FirstOrDefault();
            }
            else
            {
                awg = awgList.Where(v => v.Gauge == minAWG).FirstOrDefault();
            }

            if (awg == null)
            {
                throw new Exception("Autoselect: failed to select AWG for secondary");
            }

            return awg;
        }


        private trans_calc_result_winding calculateWinding(trans_calc_input_common common, trans_calc_input_winding w)
        {
            double dl = w.awg.Diameter_m / w.w_factor;
            double dh = w.awg.Diameter_m / w.w_factor;

            trans_calc_result_winding res = new trans_calc_result_winding();

            if (w.N_per_layer == 0)
            {
                w.N_per_layer = (int)(common.Core_L / dl);
                if (w.N_per_layer > w.N)
                {
                    w.N_per_layer = w.N;
                }
            }

            if (w.N_per_layer == 0)
            {
                throw new Exception("Error: turns per layer calculated to zero");
            }

            int totalLayers = (int)(w.N / (double)w.N_per_layer);

            int lastTurns = (int)w.N - (totalLayers * w.N_per_layer);

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

                double p = 2.0 * (common.Core_W + common.Core_H + 2.0 * delta);
                length_m += p * turnsPerLayerSaved;
            }

            double length_f = length_m / AWG.meters_in_foot;
            double thickness = totalLayers * dh;
            double resistance = w.awg.CalculateResistance(length_m, common.max_temp);
            double mass = w.awg.CalculateMass_g(length_m);
            res.length_m = length_m;
            res.length_ft = length_f;
            res.thickness_mm = thickness * 1000;
            res.resistance = resistance;
            res.mass = mass;
            res.totalLayers = totalLayers;
            res.N = w.N;
            res.N_per_layer = (int)w.N_per_layer;
            res.lastLayerTurns = (lastTurns == (int)w.N_per_layer) ? 0 : lastTurns;

            if (w.ampacity_mil_per_amp != 0)
            {
                res.awg_max_current_amp = w.awg.GetCircularMils() / w.ampacity_mil_per_amp;
            }

            res.awg = w.awg;

            return res;
        }
    }

}