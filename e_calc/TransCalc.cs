﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms.VisualStyles;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace forms1
{
    struct trans_calc_input_text
    {
        public string Vin;
        public string freq;
        public string Bmax;
        public string permeability;
        public string Iex;
        public string H;
        public string core_W;
        public string core_H;
        public string core_L;
        public string Ae_W;
        public string Ae_H;
        public string mpath_W;
        public string mpath_H;
        public string window_size;
        public string coupling_coeff;
        public string stackingFactor;
        public string insulationThickness;
        public string Vout;
        public string Iout_max;
        public string awg1;
        public string wfactor1;
        public string N1;
        public string N_per_layer1;
        public string ampacity1;
        public string awg2;
        public string wfactor2;
        public string N2;
        public string N_per_layer2;
        public string ampacity2;
        public string maxTemp;
        public string pf;
    }
    struct trans_calc_result_text
    {
        public string length_m_1;
        public string length_ft_1;
        public string thickness_mm_1;
        public string resistance_1;
        public string N_1;
        public string N_per_layer_1;
        public string totalLayers_1;
        public string lastLayerTurns_1;
        public string mpath_l_m;
        public string awg_max_current_amp_1;
        public string L1;
        public string B_max;
        public string H_amp_t_m;
        public string I_ex_amp;
        public string permeability;
        public string weight_g_1;
        public string weight_g_2;
        public string length_m_2;
        public string length_ft_2;
        public string thickness_mm_2;
        public string resistance_2;
        public string N_2;
        public string N_per_layer_2;
        public string totalLayers_2;
        public string lastLayerTurns_2;
        public string awg_max_current_amp_2;
        public string L2;
        public string Vout_idle;
        public string Vout_imax;
        public string Iout_max;
        public string total_thickness_mm;
        public string turns_ratio;
        public string wire_csa_ratio;
        public string wire_total_weight;
        public string wire_weight_ratio;
        public string Ip_full_load;
        public string power_VA;
        public List<string> warnings;
        public bool IsWindowExceeded;
        public bool IsAmpacity1Exceeded;
        public bool IsAmpacity2Exceeded;

        public trans_calc_result_text(trans_calc_result res)
        {
            this.warnings = new List<string>();

            if (res.Ip_full_load > res.primary.awg_max_current_amp)
            {
                var Ip = String.Format("{0:0.##}", res.Ip_full_load);
                var maxAmpacity = String.Format("{0:0.##}", res.primary.awg_max_current_amp);
                warnings.Add($"Ip={Ip}A exceeds the maximum ampacity of the primary={maxAmpacity}A");
                IsAmpacity1Exceeded = true;
            }
            else
            {
                IsAmpacity1Exceeded = false;
            }

            if (1 - res.secondary.awg_max_current_amp / res.I_out_max  > 0.05)
            {
                var Iout = String.Format("{0:0.##}", res.I_out_max);
                var maxAmpacity = String.Format("{0:0.##}", res.secondary.awg_max_current_amp);
                warnings.Add($"Iout={Iout}A exceeds the maximum ampacity of the secondary={maxAmpacity}A");
                IsAmpacity2Exceeded = true;
            }
            else
            {
                IsAmpacity2Exceeded = false;
            }

            if (1 - res.WindowSize / res.total_thickness_mm > 0.05)
            {
                var totalBuildup = String.Format("{0:0.#}", res.total_thickness_mm);
                warnings.Add($"Total build-up: {totalBuildup}mm exceeds the maximum window size: {res.WindowSize}mm");
                IsWindowExceeded = true;
            }
            else
            {
                IsWindowExceeded = false;
            }

            this.length_m_1 = String.Format("{0:0.##}", res.primary.length_m);
            this.length_ft_1 = String.Format("{0:0.##}", res.primary.length_ft);
            this.thickness_mm_1 = String.Format("{0:0.##}", res.primary.thickness_mm);
            this.resistance_1 = String.Format("{0:0.##}", res.primary.resistance);
            this.N_1 = res.primary.N.ToString();
            this.N_per_layer_1 = res.primary.N_per_layer.ToString();
            this.totalLayers_1 = res.primary.totalLayers.ToString();
            this.lastLayerTurns_1 =
                (res.primary.lastLayerTurns != 0) ? res.primary.lastLayerTurns.ToString() : "";
            this.mpath_l_m = String.Format("{0:0.##}", res.mpath_l_m);
            this.awg_max_current_amp_1 =
                (res.primary.awg_max_current_amp > 0.0000001) ? String.Format("{0:0.##}", res.primary.awg_max_current_amp) : "";
            this.L1 =
                (res.primary.L > 0.0000001) ? String.Format("{0:0.##}", res.primary.L) : "";

            this.B_max = String.Format("{0:0.##}", res.B_max);
            this.H_amp_t_m =
                (res.H_amp_t_m > 0.0000001) ? String.Format("{0:0.##}", res.H_amp_t_m) : "";

            this.I_ex_amp =
                (res.I_ex_amp > 0.0000001) ? String.Format("{0:0.##}", res.I_ex_amp) : "";

            this.permeability =
                (res.permeability > 0.0000001) ? String.Format("{0:0.##}", res.permeability) : "";

            this.weight_g_1 =
                (res.primary.mass > 0.0000001) ? String.Format("{0:0.##}", res.primary.mass) : "";

            this.length_m_2 = String.Format("{0:0.##}", res.secondary.length_m);
            this.length_ft_2 = String.Format("{0:0.##}", res.secondary.length_ft);
            this.thickness_mm_2 = String.Format("{0:0.##}", res.secondary.thickness_mm);
            this.resistance_2 = String.Format("{0:0.##}", res.secondary.resistance);
            this.N_2 = res.secondary.N.ToString();
            this.N_per_layer_2 = res.secondary.N_per_layer.ToString();
            this.totalLayers_2 = res.secondary.totalLayers.ToString();
            this.lastLayerTurns_2 =
                (res.secondary.lastLayerTurns != 0) ? res.secondary.lastLayerTurns.ToString() : "";

            this.awg_max_current_amp_2 =
                (res.secondary.awg_max_current_amp > 0.0000001) ? String.Format("{0:0.##}", res.secondary.awg_max_current_amp) : "";

            this.L2 =
                (res.secondary.L > 0.0000001) ? String.Format("{0:0.##}", res.secondary.L) : "";

            this.weight_g_2 =
                (res.secondary.mass > 0.0000001) ? String.Format("{0:0.##}", res.secondary.mass) : "";

            this.total_thickness_mm =
                (res.total_thickness_mm > 0.0000001) ? String.Format("{0:0.##}", res.total_thickness_mm) : "";

            this.Vout_idle = String.Format("{0:0.##}", res.Vout_idle);
            this.Vout_imax = String.Format("{0:0.##}", res.Vout_imax);
            this.Iout_max = String.Format("{0:0.##}", res.I_out_max);
            if (res.turns_ratio > 1)
            {
                this.turns_ratio = String.Format("{0:0.##}", res.turns_ratio) + ":1";
            }
            else
            {
                this.turns_ratio = "1:" + String.Format("{0:0.##}", 1 / res.turns_ratio);
            }
            if (res.wire_csa_ratio > 1)
            {
                this.wire_csa_ratio = String.Format("{0:0.##}", res.wire_csa_ratio) + ":1";

            }
            else
            {
                this.wire_csa_ratio = "1:" + String.Format("{0:0.##}", 1 / res.wire_csa_ratio);
            }
            this.wire_total_weight = String.Format("{0:0.##}", res.wire_total_weight);

            if (res.wire_weight_ratio > 1)
            {
                this.wire_weight_ratio = String.Format("{0:0.##}", res.wire_weight_ratio) + ":1";
            }
            else
            {
                this.wire_weight_ratio = "1:" + String.Format("{0:0.##}", 1 / res.wire_weight_ratio);
            }
            this.Ip_full_load = String.Format("{0:0.##}", res.Ip_full_load);
            this.power_VA = String.Format("{0:0.##}", res.power_VA);
        }
    }


    struct trans_calc_result_winding
    {
        public double length_m;
        public double length_ft;
        public double thickness_mm;
        public double resistance;
        public int totalLayers;
        public int N_per_layer;
        public int lastLayerTurns;
        public int N;
        public double L;
        public double awg_max_current_amp;
        public double mass;
    }

    struct trans_calc_result
    {
        public trans_calc_result_winding primary;
        public trans_calc_result_winding secondary;
        public double mpath_l_m;
        public double B_max;
        public double permeability;
        public double I_ex_amp;
        public double H_amp_t_m;
        public double Vout_idle;
        public double Vout_imax;
        public double I_out_max;
        public double total_thickness_mm;
        public double turns_ratio;
        public double wire_total_weight;
        public double wire_csa_ratio;
        public double wire_weight_ratio;
        public double Ip_full_load;
        public double power_VA;
        public double WindowSize;
    }

    struct trans_calc_input_common
    {
        public double Vin;
        public double Freq;
        public double B_max;
        public double permeability;
        public double I_ex;
        public double H_ampt_m;

        public double Core_L;
        public double Core_W;
        public double Core_H;
        public double Ae_W;
        public double Ae_H;
        public double pf1;

        public double mpath_l_cm;
        public double max_temp;

        public double WindowSize;
        public double CouplingCoeff;
        public double StackingFactor;
        public double InsulationThickness;

        public double Vout_idle;
        public double Iout_max;
    }

    struct trans_calc_input_winding
    {
        public AWG awg;
        public double w_factor;
        public int N;
        public int N_per_layer;
        public int ampacity_mil_per_amp;
    }

    struct trans_calc_input
    {
        public trans_calc_input_common common;
        public trans_calc_input_winding primary;
        public trans_calc_input_winding secondary;
        public bool processSecondary;
    }

    class AWG
    {
        private int gauge;
        private double diameter_mm;
        private const double mm_in_mils = 1 / 0.0254;
        // private const double copper_resistivity = 1.678e-8;
        // Annealed copper
        private const double copper_resistivity = 1.728e-8;

        private const double copper_density_kg_m3 = 8950;
        private const double copper_temperature_coeff = 0.00393;

        public AWG(int number, double value)
        {
            this.gauge = number;
            this.diameter_mm = value;
        }

        public double Gauge
        {
            get { return gauge; }
        }

        public double Diameter_mm
        {
            get { return diameter_mm; }
        }

        public double Diameter_m
        {
            get { return diameter_mm / 1000; }
        }

        public double Csa_m2
        {
            get { return Math.PI * Math.Pow(Diameter_m / 2, 2); }
        }

        public double Diameter_mils
        {
            get { return diameter_mm * mm_in_mils; }
        }

        public double GetCircularMils()
        {
            return Diameter_mils * Diameter_mils;
        }

        public double CalculateResistance(double length_m, double tempC)
        {
            double res = copper_resistivity * (1 + (tempC - 20) * copper_temperature_coeff);
            return length_m * res / (Math.PI * Math.Pow(Diameter_m / (double)2, 2));
        }

        public double CalculateMass_g(double length_m)
        {
            double v = Csa_m2 * length_m;
            return v * copper_density_kg_m3 * 1000;
        }

    }

    class TransCalc
    {
        private static double u0 = 4 * Math.PI * 10e-8;
        private List<AWG> awgValues = new List<AWG>();

        public enum H_UNITS
        {
            AMP_TURNS_M,
            AMP_TURNS_IN,
            OERSTEDS
        }

        private bool tempUnitsC = true;
        private H_UNITS H_units;
        private bool mass_units_g = true;

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
        }

        private AWG parseAWG(string text)
        {
            int awg_number = int.Parse(text, NumberStyles.Integer);
            var awg_item = awgValues.Where(v => v.Gauge == awg_number).FirstOrDefault();
            if (awg_item == null)
            {
                throw new Exception($"Invalid awg #: {text}");
            }

            return awg_item;
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
            return dH;
        }


        public trans_calc_input_text Load()
        {
            trans_calc_input_text input_text = new trans_calc_input_text();

            string csv = File.ReadAllText("transcalc.csv");
            csv = csv.Trim(new char[] { '\r', '\n', ' ' });
            string[] values = csv.Split(',');
            if (values.Length == 33)
            {
                string mains = values[0];
                if (mains != "120" && mains != "220" )
                {
                    throw new Exception($"Unexpected mains voltage: {mains}");
                }
                input_text.Vin = mains;

                input_text.Bmax = values[1];
                input_text.permeability = values[2];
                input_text.Iex = values[3];
                input_text.H = values[4];
                input_text.core_W = values[5];
                input_text.core_H = values[6];
                input_text.core_L = values[7];
                input_text.Ae_W = values[8];
                input_text.Ae_H = values[9];
                input_text.mpath_W = values[10];
                input_text.mpath_H = values[11];
                input_text.window_size = values[12];
                input_text.coupling_coeff = values[13];
                input_text.stackingFactor = values[14];
                input_text.insulationThickness = values[15];
                input_text.Vout = values[16];
                input_text.Iout_max = values[17];

                input_text.awg1 = values[18];
                input_text.wfactor1 = values[19];
                input_text.N1 = values[20];
                input_text.N_per_layer1 = values[21];
                input_text.ampacity1 = values[22];
                input_text.pf = values[23];

                input_text.awg2 = values[24];
                input_text.wfactor2 = values[25];
                input_text.N2 = values[26];
                input_text.N_per_layer2 = values[27];
                input_text.ampacity2 = values[28];

                input_text.maxTemp = values[29];

                if (values[30] == "0")
                {
                    tempUnitsC = true;
                }
                else if (values[30] == "1")
                {
                    tempUnitsC = false;
                }
                else
                {
                    throw new Exception("Error parsing Temp units");
                }

                if (values[31] == "0")
                {
                    H_Units = H_UNITS.AMP_TURNS_M;
                }
                else if (values[31] == "1")
                {
                    H_Units = H_UNITS.AMP_TURNS_IN;
                }
                else if (values[31] == "2")
                {
                    H_Units = H_UNITS.OERSTEDS;
                }
                else
                {
                    throw new Exception("Error parsing H units");
                }

                if (values[32] == "0")
                {
                    mass_units_g = true;
                }
                else if (values[32] == "1")
                {
                    mass_units_g = false;
                }
                else
                {
                    throw new Exception("Error parsing mass units");
                }
            }
            else
            {
                throw new Exception("Error parsing csv file");
            }

            return input_text;
        }

        private trans_calc_input_winding processWinding(string winding, string sawg, string wfactor, 
            string N, string N_per_layer, string ampacity_cm_per_amp)
        {
            trans_calc_input_winding res = new trans_calc_input_winding();
            if (sawg == "")
            {
                throw new Exception("AWG not set");
            }

            AWG awg = parseAWG(sawg);

            if (ampacity_cm_per_amp != "")
            {
                int cm_per_amp = int.Parse (ampacity_cm_per_amp, NumberStyles.Integer);
                if (cm_per_amp < 300 || cm_per_amp > 1000)
                {
                    throw new Exception("Cm per ampere should be between 300 and 1000");
                }
                res.ampacity_mil_per_amp = cm_per_amp;
            }

            res.awg = awg;
            if (wfactor != "")
            {
                res.w_factor = double.Parse(wfactor, NumberStyles.Float);
                if (res.w_factor < .5 || res.w_factor > 1)
                {
                    throw new Exception($"{winding}: W factor has to be in the range of 0.5 to 1");
                }

                if (N != "")
                {
                    res.N = int.Parse(N, NumberStyles.Integer);
                    if (res.N < 1)
                    {
                        throw new Exception("Invalid value for turns");
                    }
                }
            }

            if (N_per_layer != "")
            {
                res.N_per_layer = int.Parse(N_per_layer, NumberStyles.Integer);
                if (res.N_per_layer < 1 || res.N_per_layer > res.N)
                {
                    throw new Exception("Invalid value for turns per layer");
                }
            }
            return res;
        }

        public trans_calc_result_text Calculate(trans_calc_input_text text_input)
        {

            trans_calc_input input = convertTextToInput(text_input);

            double Epeak = input.common.Vin * Math.Sqrt(2);
            double omega = input.common.Freq * 2 * Math.PI;
            double Ae = input.common.Ae_W * input.common.Ae_H * input.common.StackingFactor;
            double l_m = input.common.mpath_l_cm;
            double V_in = input.common.Vin;
            double I_ex = input.common.I_ex;
            double u = input.common.permeability;
            double H_peak = input.common.H_ampt_m;
            double L1 = 0;

            // N1 not set, calculate it
            if (input.primary.N == 0)
            {
                input.primary.N = (int)(Epeak / (input.common.B_max * Ae * omega));
            }
            else //recalculate Bmax based on N
            {
                input.common.B_max = Epeak / (input.primary.N * Ae * omega);
                if (input.common.B_max > 2)
                {
                    throw new Exception($"Calculated Bmax is too high: {input.common.B_max}. It has to be <2T. The number of turns is too low");
                }
            }

            trans_calc_result result = new trans_calc_result();

            result.mpath_l_m = l_m;

            //Priority: Iex, permeability, H
            if (I_ex > 0.000000000001)
            {
                L1 = V_in / (I_ex * omega);
                u = (L1 * l_m) / (input.primary.N * input.primary.N * Ae) / u0;
                H_peak = input.common.B_max / u / u0;
            }
            else if (u > 0.0000000000001)
            {
                L1 = input.primary.N * input.primary.N * u * u0 * Ae / l_m;
                I_ex = V_in / (omega * L1);
                H_peak = input.common.B_max / u / u0;
            }
            else if (H_peak > 0.0000000000001)
            {
                //divide by sqrt(2) to get RMS
                I_ex = H_peak / input.primary.N * l_m / Math.Sqrt(2);
                u = input.common.B_max / H_peak / u0;
                L1 = V_in / (I_ex * omega);
            }

            if (u > 0.00000000001 && (u < 1000 || u > 10000))
            {
                throw new Exception($"Calculated permeability={u} is not in the expected range of 1000 to 10000. Check the values of Bmax/I_ex/H Amp-t-m");
            }
            if (H_peak > 0.00000000001 && (H_peak < 1 || H_peak > 2000))
            {
                throw new Exception($"Calculated H={H_peak} Amp-t-m is not in the expected range of 1 to 2000. Check the values of Bmax/I_ex/Amp-t-m");
            }

            result.B_max = input.common.B_max;
            result.H_amp_t_m = H_peak;
            result.I_ex_amp = I_ex;
            result.permeability = u;

            // Calculate primary
            trans_calc_result_winding w1 = calculateWinding(input.common, input.primary);
            result.primary = w1;
            result.primary.L = L1;
            result.total_thickness_mm = result.primary.thickness_mm + input.common.InsulationThickness;


 
            //Calculate secondary if configured 
            if (input.processSecondary)
            {
                if (input.common.Vout_idle > 0.00000001 && input.secondary.N == 0)
                {
                    input.secondary.N = (int) (input.primary.N / input.common.Vin * input.common.Vout_idle / input.common.CouplingCoeff);
                }
                else if (input.secondary.N > 0)
                {
                    input.common.Vout_idle = input.common.Vin / input.primary.N * input.secondary.N * input.common.CouplingCoeff;
                }

                result.turns_ratio = (double)input.primary.N / (double)input.secondary.N;
                result.I_out_max = input.common.Iout_max;

                input.common.Core_H += w1.thickness_mm / 1000;
                input.common.Core_W += w1.thickness_mm / 1000;
                trans_calc_result_winding w2 = calculateWinding(input.common, input.secondary);
                result.secondary = w2;
                if (u > 0.00000000001)
                {
                    result.secondary.L = w2.N * w2.N * u * u0 * Ae / l_m;
                }

                result.Vout_idle = input.common.Vout_idle;
                double ratio_squared = Math.Pow(w2.N / w1.N, 2);
                double total_R = w1.resistance * ratio_squared + w2.resistance;
                double regulation_vdrop = input.common.Iout_max * total_R;
                if (regulation_vdrop > result.Vout_idle / 2)
                {
                    throw new Exception($"Voltage drop too high: {regulation_vdrop}. Check Iout, Vout, wire ga");
                }
                result.Vout_imax = result.Vout_idle - regulation_vdrop;

                result.I_out_max = input.common.Iout_max;
                result.total_thickness_mm += w2.thickness_mm;
                result.wire_total_weight = w1.mass + w2.mass;
                result.wire_csa_ratio = input.primary.awg.Csa_m2 / input.secondary.awg.Csa_m2;
                result.wire_weight_ratio = w1.mass / w2.mass;
                result.Ip_full_load = 
                    Math.Sqrt (Math.Pow (result.I_out_max / result.turns_ratio, 2) + 
                    Math.Pow(result.I_ex_amp, 2));
                result.power_VA = result.I_out_max * result.Vout_imax;

            }

            result.WindowSize = input.common.WindowSize;

            return new trans_calc_result_text(result); 
        }
        private trans_calc_input convertTextToInput(trans_calc_input_text strin) 
        {
            trans_calc_input res =  new trans_calc_input();
            res.common = new trans_calc_input_common();
            res.primary = new trans_calc_input_winding();

            if (strin.Vin == "")
            {
                throw new Exception("Vin not set");
            }
            res.common.Vin = double.Parse(strin.Vin, NumberStyles.Float);
            if (strin.freq == "")
            {
                throw new Exception("Freq not set");
            }
            res.common.Freq = double.Parse(strin.freq, NumberStyles.Float);

            if (strin.Bmax == "" && strin.N1 == "")
            {
                throw new Exception("Either Bmax or Primary turns must be set");
            }

            if (strin.Bmax != "")
            {
                res.common.B_max = double.Parse(strin.Bmax, NumberStyles.Float);
                if (res.common.B_max < 0.1 || res.common.B_max > 2)
                {
                    throw new Exception("Bmax, has to be in the range of 0.1T to 2T");
                }
            }

            if (strin.permeability != "")
            {
                res.common.permeability = double.Parse(strin.permeability, NumberStyles.Float);
                if (res.common.permeability < 1000 || res.common.permeability > 10000)
                {
                    throw new Exception("Permeability has to be in the range of 1000 to 10000");
                }
            }

            if (strin.Iex != "")
            {
                // from mA to A
                res.common.I_ex = double.Parse(strin.Iex, NumberStyles.Float) / 1000;
                if (res.common.I_ex < 0.01 || res.common.I_ex > 2)
                {
                    throw new Exception("Iex has to be in the range of 10mA to 2A");
                }
            }

            if (strin.H != "")
            {
                res.common.H_ampt_m = double.Parse(strin.H, NumberStyles.Float);
                if (H_Units == H_UNITS.OERSTEDS)
                {
                    res.common.H_ampt_m = Oe_to_Ampturns(res.common.H_ampt_m);
                }
                else if (H_Units == H_UNITS.AMP_TURNS_IN)
                {
                    res.common.H_ampt_m /= 0.0254;
                }
                if (res.common.H_ampt_m < 1 || res.common.H_ampt_m > 2000)
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
                res.common.pf1 = double.Parse(strin.pf, NumberStyles.Float);
                if (res.common.pf1 < 0 && res.common.pf1 > 1.0)
                {
                    throw new Exception("pf has to be between 0 and 1");
                }
            }

            //to m
            res.common.Core_L = double.Parse(strin.core_L, NumberStyles.Float) / 100;
            res.common.Core_W = double.Parse(strin.core_W, NumberStyles.Float) / 100;
            res.common.Core_H = double.Parse(strin.core_H, NumberStyles.Float) / 100;

            if (res.common.Core_L < 0.01 || res.common.Core_L > 0.5)
            {
                throw new Exception("Invalid core L");
            }
            if (res.common.Core_W < 0.01 || res.common.Core_W > 0.5)
            {
                throw new Exception("Invalid core W");
            }
            if (res.common.Core_H < 0.01 || res.common.Core_H > 0.5)
            {
                throw new Exception("Invalid core H");
            }

            if (strin.Ae_W == "" || strin.Ae_H == "")
            {
                throw new Exception("Ae W/H not set");
            }
            //to m
            res.common.Ae_W = double.Parse(strin.Ae_W) / 100;
            if (res.common.Ae_W < 0.01 || res.common.Ae_W > 0.5)
            {
                throw new Exception("Invalid Ae width");
            }
            res.common.Ae_H = double.Parse(strin.Ae_H) / 100;
            if (res.common.Ae_H < 0.01 || res.common.Ae_H > 0.5)
            {
                throw new Exception("Invalid Ae height");
            }

            if (res.common.Ae_W > res.common.Core_W)
            {
                throw new Exception("Ae_W > bobbin W");
            }

            if (res.common.Ae_H > res.common.Core_H)
            {
                throw new Exception("Ae_H > bobbin H");
            }

            if (strin.mpath_H != "" && strin.mpath_W != "")
            {
                //cm 
                double Mpath_H = double.Parse(strin.mpath_H, NumberStyles.Float)/100;
                double Mpath_W = double.Parse(strin.mpath_W, NumberStyles.Float)/100;

                if (Mpath_H < 0.01 || Mpath_H > 0.5)
                {
                    throw new Exception("Invalid magnetic path value: H");
                }

                if (Mpath_W < 0.01 || Mpath_W > 0.5)
                {
                    throw new Exception("Invalid magnetic path value: W");
                }

                res.common.mpath_l_cm = (Mpath_H + Mpath_W) * 2;
            }

            if (strin.window_size == "")
            {
                throw new Exception("Window size not set");
            }

            // in cm
            res.common.WindowSize = double.Parse(strin.window_size, NumberStyles.Float);
            if (res.common.WindowSize < 0.1 || res.common.WindowSize > 50)
            {
                throw new Exception("Invalid window size in cm");
            }

            if (strin.coupling_coeff == "")
            {
                throw new Exception("Coupling coefficient not set");
            }

            res.common.CouplingCoeff = double.Parse(strin.coupling_coeff, NumberStyles.Float);
            if (res.common.CouplingCoeff < 0.5 || res.common.CouplingCoeff > 1.0)
            {
                throw new Exception("Coupling coefficient has to be in the range of 0.5 to 1.0");
            }

            if (strin.stackingFactor == "")
            {
                throw new Exception("Stacking factor not set");
            }

            res.common.StackingFactor = double.Parse(strin.stackingFactor, NumberStyles.Float);
            if (res.common.StackingFactor < 0.5 || res.common.StackingFactor > 1.0)
            {
                throw new Exception("Stacking factor has to be in the range of 0.5 to 1.0");
            }

            if (strin.insulationThickness == "")
            {
                throw new Exception("Insulation thickness not set");
            }

            res.common.InsulationThickness = double.Parse(strin.insulationThickness, NumberStyles.Float);
            if (res.common.InsulationThickness < 0 || res.common.InsulationThickness > res.common.WindowSize)
            {
                throw new Exception("Insulation thickness in mm cannot exceed window size");
            }

            if (strin.Vout != "")
            {
                res.common.Vout_idle = double.Parse(strin.Vout, NumberStyles.Float);
                if (res.common.Vout_idle < 0.1)
                {
                    throw new Exception("Invalid Vout value");
                }
            }

            if (strin.Iout_max != "")
            {
                res.common.Iout_max = double.Parse(strin.Iout_max, NumberStyles.Float);
                if (res.common.Iout_max < 0.00000000001)
                {
                    throw new Exception("Invalid Iout_max value");
                }
            }

            res.common.max_temp = double.Parse(strin.maxTemp, NumberStyles.Float);
            if (!IsTempUnitsC)
            {
                res.common.max_temp = F_to_C(res.common.max_temp);
            }

            if (res.common.max_temp < 20)
            {
                res.common.max_temp = 20;
            }

            res.primary = processWinding("Primary", strin.awg1, strin.wfactor1, strin.N1, strin.N_per_layer1, strin.ampacity1);

            if ((strin.N2 != "" || strin.Vout != ""))
            {
                res.secondary = processWinding("Secondary", strin.awg2, strin.wfactor2, strin.N2, strin.N_per_layer2, strin.ampacity2);
                res.processSecondary = true;
            }
            else
            {
                res.processSecondary = false;
            }

            return res;
        }

        private trans_calc_result_winding calculateWinding(trans_calc_input_common common, trans_calc_input_winding w)
        {
            if (w.w_factor < 0.000000000001)
            {
                throw new Exception("W factor not set");
            }

            double dl = w.awg.Diameter_m / w.w_factor;
            double dh = w.awg.Diameter_m / w.w_factor;

            trans_calc_result_winding res = new trans_calc_result_winding();

            if (w.N_per_layer == 0)
            {
                w.N_per_layer = (int)(common.Core_L / dl);
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

                double p = 2.0 * (common.Core_W + common.Core_H + 2.0 * delta);
                length_m += p * turnsPerLayerSaved;
            }

            double length_f = length_m * 3.28084;
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

            return res;
        }
    }

}