using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms.VisualStyles;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Diagnostics;

namespace forms1
{
    struct trans_calc_input_text
    {
        public string Vin;
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
        public string max_eq_R;
        public bool isVoutAtFullLoad;
    }
    struct trans_calc_result_text
    {
        public string length_m_1;
        public string length_ft_1;
        public string buildup_mm_1;
        public string R_1;
        public string N_1;
        public string N_per_layer_1;
        public string totalLayers_1;
        public string lastLayerTurns_1;
        public string mpath_l_m;
        public string awg_max_current_amp_1;
        public string L_1;
        public string B_max;
        public string H;
        public string I_ex;
        public string permeability;
        public string weight_1;
        public string weight_2;
        public string length_m_2;
        public string length_ft_2;
        public string buildup_mm_2;
        public string R_2;
        public string N_2;
        public string N_per_layer_2;
        public string totalLayers_2;
        public string lastLayerTurns_2;
        public string awg_max_current_amp_2;
        public string L_2;
        public string Vout_idle;
        public string Vout_load;
        public string Iout_max;
        public string total_thickness_mm;
        public string turns_ratio;
        public string wire_csa_ratio;
        public string wire_total_weight;
        public string wire_weight_ratio;
        public string Ip_full_load;
        public string power_VA;
        public string total_eq_R;
        public string regulation;
        public List<string> warnings;
        public bool IsWindowExceeded;
        public bool IsAmpacity1Exceeded;
        public bool IsAmpacity2Exceeded;
        public bool IsMaxResistanceExceeded;

        public trans_calc_result_text(trans_calc_result res, trans_calc_input input)
        {
            this.warnings = new List<string>();
            IsAmpacity1Exceeded = false;
            IsAmpacity2Exceeded = false;
            IsWindowExceeded = false;
            IsMaxResistanceExceeded = false;

            if (input.processSecondary)
            {
                if (res.Ip_full_load > 0.00000001 &&
                    res.primary.awg_max_current_amp > 0.00000001 &&
                    res.Ip_full_load > res.primary.awg_max_current_amp)
                {
                    var Ip = String.Format("{0:0.##}", res.Ip_full_load);
                    var maxAmpacity = String.Format("{0:0.##}", res.primary.awg_max_current_amp);
                    warnings.Add($"Ip={Ip}A exceeds the maximum ampacity of the primary={maxAmpacity}A");
                    IsAmpacity1Exceeded = true;
                }

                if (res.Iout_max > 0.00000001 &&
                    res.secondary.awg_max_current_amp > 0.0000001 &&
                    (1 - res.secondary.awg_max_current_amp / res.Iout_max) > 0.05)
                {
                    var Iout = String.Format("{0:0.##}", res.Iout_max);
                    var maxAmpacity = String.Format("{0:0.##}", res.secondary.awg_max_current_amp);
                    warnings.Add($"Iout={Iout}A exceeds the maximum ampacity of the secondary={maxAmpacity}A");
                    IsAmpacity2Exceeded = true;
                }

                if (input.common.WindowSize > 0.0000001 && 
                    (1 - input.common.WindowSize / res.total_thickness_mm) > 0.05)
                {
                    var totalBuildup = String.Format("{0:0.#}", res.total_thickness_mm);
                    warnings.Add($"Total build-up: {totalBuildup}mm exceeds the maximum window size: {input.common.WindowSize}mm");
                    IsWindowExceeded = true;
                }

                if (input.common.max_res_R > 0.0000001 && res.total_eq_R > input.common.max_res_R)
                {
                    var total_eq_R = String.Format("{0:0.#}", res.total_eq_R);
                    warnings.Add($"Total R: {total_eq_R} exceeds the maximum total R: {input.common.max_res_R}");
                    IsMaxResistanceExceeded = true;
                }

            }

            this.length_m_1 = String.Format("{0:0.##}", res.primary.length_m);
            this.length_ft_1 = String.Format("{0:0.##}", res.primary.length_ft);
            this.buildup_mm_1 = String.Format("{0:0.##}", res.primary.thickness_mm);
            this.R_1 = String.Format("{0:0.##}", res.primary.resistance);
            this.N_1 = res.primary.N.ToString();
            this.N_per_layer_1 = res.primary.N_per_layer.ToString();
            this.totalLayers_1 = res.primary.totalLayers.ToString();
            this.lastLayerTurns_1 =
                (res.primary.lastLayerTurns != 0) ? res.primary.lastLayerTurns.ToString() : TransCalc.EmptyValue;
            this.mpath_l_m = (res.mpath_l_m > 0.0000001) ?
                String.Format("{0:0.##}", res.mpath_l_m) : TransCalc.EmptyValue;
            this.awg_max_current_amp_1 =
                (res.primary.awg_max_current_amp > 0.0000001) ? String.Format("{0:0.##}", res.primary.awg_max_current_amp) : TransCalc.EmptyValue;
            this.L_1 =
                (res.primary.L > 0.0000001) ? String.Format("{0:0.##}", res.primary.L) : TransCalc.EmptyValue;

            this.B_max = String.Format("{0:0.##}", res.B_max);
            this.H =
                (res.H > 0.0000001) ? String.Format("{0:0.##}", res.H) : TransCalc.EmptyValue;

            this.I_ex =
                (res.I_ex > 0.0000001) ? String.Format("{0:0.##}", res.I_ex) : TransCalc.EmptyValue;

            this.permeability =
                (res.permeability > 0.0000001) ? String.Format("{0:0.##}", res.permeability) : TransCalc.EmptyValue;

            this.weight_1 =
                (res.primary.mass > 0.0000001) ? String.Format("{0:0.##}", res.primary.mass) : TransCalc.EmptyValue;

            /////////////////////////////////
            if (input.processSecondary)
            {
                this.length_m_2 = String.Format("{0:0.##}", res.secondary.length_m);
                this.length_ft_2 = String.Format("{0:0.##}", res.secondary.length_ft);
                this.buildup_mm_2 = String.Format("{0:0.##}", res.secondary.thickness_mm);
                this.R_2 = String.Format("{0:0.##}", res.secondary.resistance);
                this.N_2 = res.secondary.N.ToString();
                this.N_per_layer_2 = res.secondary.N_per_layer.ToString();
                this.totalLayers_2 = res.secondary.totalLayers.ToString();
                this.lastLayerTurns_2 =
                    (res.secondary.lastLayerTurns != 0) ? res.secondary.lastLayerTurns.ToString() : "";

                this.awg_max_current_amp_2 =
                    (res.secondary.awg_max_current_amp > 0.0000001) ? String.Format("{0:0.##}", res.secondary.awg_max_current_amp) : TransCalc.EmptyValue;

                this.L_2 =
                    (res.secondary.L > 0.0000001) ? String.Format("{0:0.##}", res.secondary.L) : TransCalc.EmptyValue;

                this.weight_2 =
                    (res.secondary.mass > 0.0000001) ? String.Format("{0:0.##}", res.secondary.mass) : TransCalc.EmptyValue;

                this.total_thickness_mm =
                    (res.total_thickness_mm > 0.0000001) ? String.Format("{0:0.##}", res.total_thickness_mm) : TransCalc.EmptyValue;

                this.Vout_idle = String.Format("{0:0.##}", res.Vout_idle);
                this.Vout_load = (res.Vout_load > 0.0000001) ?
                    String.Format("{0:0.##}", res.Vout_load) : TransCalc.EmptyValue;
                this.Iout_max =
                    (res.Iout_max > 0.0000001) ? String.Format("{0:0.##}", res.Iout_max) : TransCalc.EmptyValue;
                
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
                this.Ip_full_load = (res.Ip_full_load > 0.00000001) ?
                    String.Format("{0:0.##}", res.Ip_full_load) : TransCalc.EmptyValue;
                this.power_VA = (res.power_VA > 0.0000000001) ?
                    String.Format("{0:0.##}", res.power_VA) : TransCalc.EmptyValue;

                this.regulation = (res.regulation > 0.0000000001) ?
                    String.Format("{0:0.##}", res.regulation) : TransCalc.EmptyValue;

                this.total_eq_R = (res.total_eq_R > 0.0000000001) ?
                    String.Format("{0:0.##}", res.total_eq_R) : TransCalc.EmptyValue;
            }
            else
            {
                this.length_m_2 = TransCalc.EmptyValue;
                this.length_ft_2 = TransCalc.EmptyValue;
                this.buildup_mm_2 = TransCalc.EmptyValue;
                this.R_2 = TransCalc.EmptyValue;
                this.N_2 = TransCalc.EmptyValue;
                this.N_per_layer_2 = TransCalc.EmptyValue;
                this.totalLayers_2 = TransCalc.EmptyValue;
                this.lastLayerTurns_2 = TransCalc.EmptyValue;
                this.awg_max_current_amp_2 = TransCalc.EmptyValue;
                this.L_2 = TransCalc.EmptyValue;
                this.weight_2 = TransCalc.EmptyValue;
                this.total_thickness_mm = TransCalc.EmptyValue;
                this.Vout_idle = TransCalc.EmptyValue;
                this.Vout_load = TransCalc.EmptyValue;
                this.Iout_max = TransCalc.EmptyValue;
                this.turns_ratio = TransCalc.EmptyValue;
                this.wire_csa_ratio = TransCalc.EmptyValue;
                this.wire_total_weight = TransCalc.EmptyValue;
                this.wire_weight_ratio = TransCalc.EmptyValue;
                this.Ip_full_load = TransCalc.EmptyValue;
                this.power_VA = TransCalc.EmptyValue;
                this.total_eq_R = TransCalc.EmptyValue;
                this.regulation = TransCalc.EmptyValue;
            }
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
        public double I_ex;
        public double H;
        public double Vout_idle;
        public double Vout_load;
        public double Iout_max;
        public double total_thickness_mm;
        public double turns_ratio;
        public double wire_total_weight;
        public double wire_csa_ratio;
        public double wire_weight_ratio;
        public double Ip_full_load;
        public double power_VA;
        public double total_eq_R;
        public double regulation;
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
        public double max_res_R;

        public double WindowSize;
        public double CouplingCoeff;
        public double StackingFactor;
        public double InsulationThickness;

        public double Vout;
        public double Iout_max;
        public bool   IsVoutAtFullLoad;
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
        private const double meters_in_inch = 0.0254;
        public  static double meters_in_foot = meters_in_inch * 12;
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
        private double lbs_in_g = 0.00220462262185;
        private Dictionary<CONFIG_KEYWORDS, string> cfg_keywords;

        public enum H_UNITS
        {
            AMP_TURNS_M,
            AMP_TURNS_IN,
            OERSTEDS
        }

        enum CONFIG_KEYWORDS
        {
            UNKNOWN_KEYWORD,
            V_IN, 
            B_MAX,
            H,
            PERMEABILITY,
            I_EX,
            CORE_W,
            CORE_H,
            CORE_L,
            Ae_W,
            Ae_H,
            MPATH_W,
            MPATH_H,
            WINDOW_SIZE,
            COUPLING_COEFF,
            STACKING_FACTOR,
            INSULATION,
            V_OUT,
            IS_V_OUT_AT_MAX_LOAD, 
            I_OUT,
            MAX_TEMP,
            MAX_EQ_R, 
            AWG_1,
            W_FACTOR_1,
            N_1,
            N_PER_LAYER_1,
            PF_1,
            CM_PER_AMP_1,
            AWG_2,
            W_FACTOR_2,
            N_2,
            N_PER_LAYER_2,
            CM_PER_AMP_2, 
            H_UNITS,
            TEMP_UNITS,
            WEIGHT_UNITS
        }

        private bool tempUnitsC = true;
        private H_UNITS H_units;
        private bool mass_units_g = true;
        public static string EmptyValue = "- -";
        private string[] H_labels = new string[] { "Amp-t/m", "Amp-t/in", "Oe" };

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

            cfg_keywords = new Dictionary<CONFIG_KEYWORDS, string>();
            cfg_keywords[CONFIG_KEYWORDS.V_IN] = "V_mains";
            cfg_keywords[CONFIG_KEYWORDS.B_MAX] = "B";
            cfg_keywords[CONFIG_KEYWORDS.H] = "H";
            cfg_keywords[CONFIG_KEYWORDS.PERMEABILITY] = "u";
            cfg_keywords[CONFIG_KEYWORDS.I_EX] = "Iex";
            cfg_keywords[CONFIG_KEYWORDS.CORE_W] = "CoreW";
            cfg_keywords[CONFIG_KEYWORDS.CORE_H] = "CoreH";
            cfg_keywords[CONFIG_KEYWORDS.CORE_L] = "CoreL";
            cfg_keywords[CONFIG_KEYWORDS.Ae_W] = "AeW";
            cfg_keywords[CONFIG_KEYWORDS.Ae_H] = "AeH";
            cfg_keywords[CONFIG_KEYWORDS.MPATH_W] = "MpathW";
            cfg_keywords[CONFIG_KEYWORDS.MPATH_H] = "MpathH";
            cfg_keywords[CONFIG_KEYWORDS.WINDOW_SIZE] = "WindowSize";
            cfg_keywords[CONFIG_KEYWORDS.COUPLING_COEFF] = "CouplingCoeff";
            cfg_keywords[CONFIG_KEYWORDS.STACKING_FACTOR] = "StackingFactor";
            cfg_keywords[CONFIG_KEYWORDS.INSULATION] = "Insulation_mm";
            cfg_keywords[CONFIG_KEYWORDS.V_OUT] = "Vout";
            cfg_keywords[CONFIG_KEYWORDS.IS_V_OUT_AT_MAX_LOAD] = "IsVoutAtMaxLoad";
            cfg_keywords[CONFIG_KEYWORDS.I_OUT] = "Iout";
            cfg_keywords[CONFIG_KEYWORDS.MAX_TEMP] = "MaxTemp";
            cfg_keywords[CONFIG_KEYWORDS.MAX_EQ_R] = "MaxEqR";
            cfg_keywords[CONFIG_KEYWORDS.AWG_1] = "Awg1";
            cfg_keywords[CONFIG_KEYWORDS.W_FACTOR_1] = "Wfactor1";
            cfg_keywords[CONFIG_KEYWORDS.N_1] = "N1";
            cfg_keywords[CONFIG_KEYWORDS.N_PER_LAYER_1] = "N_per_layer1";
            cfg_keywords[CONFIG_KEYWORDS.PF_1] = "PF1";
            cfg_keywords[CONFIG_KEYWORDS.CM_PER_AMP_1] = "CM_Per_Amp1";
            cfg_keywords[CONFIG_KEYWORDS.AWG_2] = "Awg2";
            cfg_keywords[CONFIG_KEYWORDS.W_FACTOR_2] = "Wfactor2";
            cfg_keywords[CONFIG_KEYWORDS.N_2] = "N2";
            cfg_keywords[CONFIG_KEYWORDS.N_PER_LAYER_2] = "N_per_layer2";
            cfg_keywords[CONFIG_KEYWORDS.CM_PER_AMP_2] = "CM_Per_Amp2";
            cfg_keywords[CONFIG_KEYWORDS.H_UNITS] = "H_units";
            cfg_keywords[CONFIG_KEYWORDS.TEMP_UNITS] = "Temp_units";
            cfg_keywords[CONFIG_KEYWORDS.WEIGHT_UNITS] = "Weight_units";
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

        private void ProcessLine (string line, ref trans_calc_input_text strin)
        {
            string[] parts = line.Split('=');

            var key = cfg_keywords.FirstOrDefault(e => e.Value.Equals(parts[0].Trim(), StringComparison.OrdinalIgnoreCase)).Key;
            if (key == CONFIG_KEYWORDS.UNKNOWN_KEYWORD)
            {
                throw new Exception($"Error parsing cfg file, invalid keyword: {line}");
            }    
            switch(key)
            {
                case CONFIG_KEYWORDS.V_IN:
                    strin.Vin = parts[1];
                    break;
                case CONFIG_KEYWORDS.B_MAX:
                    strin.Bmax = parts[1];
                    break;
                case CONFIG_KEYWORDS.H:
                    strin.H = parts[1];
                    break;
                case CONFIG_KEYWORDS.PERMEABILITY:
                    strin.permeability = parts[1];
                    break;
                case CONFIG_KEYWORDS.I_EX:
                    strin.Iex = parts[1];
                    break;
                case CONFIG_KEYWORDS.CORE_W:
                    strin.core_W = parts[1];
                    break;
                case CONFIG_KEYWORDS.CORE_H:
                    strin.core_H = parts[1];
                    break;
                case CONFIG_KEYWORDS.CORE_L:
                    strin.core_L = parts[1];
                    break;
                case CONFIG_KEYWORDS.Ae_W:
                    strin.Ae_W = parts[1];
                    break;
                case CONFIG_KEYWORDS.Ae_H:
                    strin.Ae_H = parts[1];
                    break;
                case CONFIG_KEYWORDS.MPATH_W:
                    strin.mpath_W = parts[1];
                    break;
                case CONFIG_KEYWORDS.MPATH_H:
                    strin.mpath_H = parts[1];
                    break;
                case CONFIG_KEYWORDS.WINDOW_SIZE:
                    strin.window_size = parts[1];
                    break;
                case CONFIG_KEYWORDS.COUPLING_COEFF:
                    strin.coupling_coeff = parts[1];
                    break;
                case CONFIG_KEYWORDS.STACKING_FACTOR:
                    strin.stackingFactor = parts[1];
                    break;
                case CONFIG_KEYWORDS.INSULATION:
                    strin.insulationThickness = parts[1];
                    break;
                case CONFIG_KEYWORDS.V_OUT:
                    strin.Vout = parts[1];
                    break;
                case CONFIG_KEYWORDS.IS_V_OUT_AT_MAX_LOAD:
                    strin.isVoutAtFullLoad = bool.Parse (parts[1]);
                    break;
                case CONFIG_KEYWORDS.I_OUT:
                    strin.Iout_max = parts[1];
                    break;
                case CONFIG_KEYWORDS.MAX_TEMP:
                    strin.maxTemp = parts[1];
                    break;
                case CONFIG_KEYWORDS.MAX_EQ_R:
                    strin.max_eq_R = parts[1];
                    break;
                case CONFIG_KEYWORDS.AWG_1:
                    strin.awg1 = parts[1];
                    break;
                case CONFIG_KEYWORDS.W_FACTOR_1:
                    strin.wfactor1 = parts[1];
                    break;
                case CONFIG_KEYWORDS.N_1:
                    strin.N1 = parts[1];
                    break;
                case CONFIG_KEYWORDS.N_PER_LAYER_1:
                    strin.N_per_layer1 = parts[1];
                    break;
                case CONFIG_KEYWORDS.PF_1:
                    strin.pf = parts[1];
                    break;
                case CONFIG_KEYWORDS.CM_PER_AMP_1:
                    strin.ampacity1 = parts[1];
                    break;
                case CONFIG_KEYWORDS.AWG_2:
                    strin.awg2 = parts[1];
                    break;
                case CONFIG_KEYWORDS.W_FACTOR_2:
                    strin.wfactor2 = parts[1];
                    break;
                case CONFIG_KEYWORDS.N_2:
                    strin.N2 = parts[1];
                    break;
                case CONFIG_KEYWORDS.N_PER_LAYER_2:
                    strin.N_per_layer2 = parts[1];
                    break;
                case CONFIG_KEYWORDS.CM_PER_AMP_2:
                    strin.ampacity2 = parts[1];
                    break;
                case CONFIG_KEYWORDS.H_UNITS:
                    this.H_units =  (H_UNITS) int.Parse(parts[1]);
                    break;
                case CONFIG_KEYWORDS.TEMP_UNITS:
                    this.IsTempUnitsC = parts[1] == "1" ? true : false;
                    break;
                case CONFIG_KEYWORDS.WEIGHT_UNITS:
                    this.IsMassUnits_g = parts[1] == "1" ? true : false;
                    break;
                default:
                    throw new Exception($"Unknown key: {key}");
            }
        }

        public trans_calc_input_text Load(string fileName)
        {
            trans_calc_input_text input_text = new trans_calc_input_text();

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                {
                    ProcessLine(sr.ReadLine(), ref input_text);
                }
            }

            return input_text;
        }


        private trans_calc_input_winding convertWinding(string winding, string sawg, string wfactor, 
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
            if (wfactor == "")
            {
                throw new Exception("W factor not set");
            }

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

        public void SaveResults(trans_calc_input_text strin, trans_calc_result_text result, string fileName)
        {
            trans_calc_input input = convertTextToInput(strin);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Input:\n");
                
                sw.WriteLine($"Core size  WxHxL     : {strin.core_W} x {strin.core_H} x {strin.core_L} cm");
                sw.WriteLine($"Ae, WxH              : {strin.Ae_W} x {strin.Ae_H} cm");
                if (strin.window_size != "")
                {
                    sw.WriteLine($"Window size          : {strin.window_size} mm");
                }
                if (input.common.mpath_l_cm > 0.0000001)
                {
                    sw.WriteLine($"Mpath, WxH           : {strin.mpath_W} x {strin.mpath_H} cm");
                }
                if (strin.Bmax != "")
                {   
                    sw.WriteLine($"Bmax                 : {strin.Bmax} T");
                }
                if (strin.H != "")
                {
                    sw.WriteLine($"H                    : {strin.H} " + HUnitlsLabel);
                }
                if (strin.permeability != "")
                {
                    sw.WriteLine($"u/u0                 : {strin.permeability}");
                }
                if (strin.Iex != "")
                {
                    sw.WriteLine($"Iex                  : {strin.Iex} A");
                }

                sw.WriteLine($"L1/L2 coupling coeff : {strin.coupling_coeff}");
                sw.WriteLine($"Stacking factor      : {strin.stackingFactor}");
                if (strin.insulationThickness != "")
                {
                    sw.WriteLine($"Insulation           : {strin.insulationThickness} mm");
                }
                if (strin.Vout != "")
                {
                    string fullLoad = strin.isVoutAtFullLoad ? "(full load)" : "(idle)";
                    sw.WriteLine($"Vout                 : {strin.Vout} {fullLoad}");
                }
                if (strin.Iout_max != "")
                {
                    sw.WriteLine($"Iout max             : {strin.Iout_max} A");
                }
                sw.WriteLine($"Max temperature      : {strin.maxTemp} " + TempUnitsLabel);
                if (strin.max_eq_R != "")
                {
                    sw.WriteLine($"Max equivalent R     : {strin.max_eq_R}");
                }
                sw.WriteLine();

                sw.WriteLine($"Primary   : {strin.awg1} AWG, Wfactor: {strin.wfactor1}, N: {strin.N1}, " +
                    $"N per layer: {strin.N_per_layer1} C.M. per amp: {strin.ampacity1}");

                if (input.processSecondary)
                {
                    sw.WriteLine($"Secondary : {strin.awg2} AWG, Wfactor: {strin.wfactor2}, N: {strin.N2}, " +
                        $"N per layer: {strin.N_per_layer2} C.M. per amp: {strin.ampacity2}");
                }

                sw.WriteLine($"\nMains: {input.common.Vin.ToString()}V / {input.common.Freq.ToString()}Hz");

                sw.WriteLine("\n=== Results: =====================================\n");
                sw.WriteLine("Primary:\n");
                sw.WriteLine($"Turns                : {result.N_1}");
                sw.WriteLine($"Turns per layer      : {result.N_per_layer_1}");
                sw.WriteLine($"Total layers         : {result.totalLayers_1}");
                sw.WriteLine($"Last layer turns     : {result.lastLayerTurns_1}");
                sw.WriteLine($"Wire length          : {result.length_m_1} m / {result.length_ft_1} ft");
                sw.WriteLine($"Build-up             : {result.buildup_mm_1} mm");
                sw.WriteLine($"R                    : {result.R_1}");
                if (result.mpath_l_m != EmptyValue)
                {
                    sw.WriteLine($"Magnetic path        : {result.mpath_l_m} m");
                }
                if (result.L_1 != EmptyValue)
                {
                    sw.WriteLine($"L                    : {result.L_1} H");
                }
                sw.WriteLine($"Bmax                 : {result.B_max} T");
                if (result.permeability != EmptyValue)
                {
                    sw.WriteLine($"u/u0                 : {result.permeability}");
                }
                if (result.H != EmptyValue)
                {
                    sw.WriteLine($"H                    : {result.H} " + HUnitlsLabel);
                }
                if (result.I_ex != EmptyValue)
                {
                    sw.WriteLine($"Iex                  : {result.I_ex} A");
                }
                if (result.Ip_full_load != EmptyValue)
                {
                    sw.WriteLine($"Ip, full load        : {result.Ip_full_load} A");
                }
                if (result.awg_max_current_amp_1 != EmptyValue)
                {
                    sw.WriteLine($"AWG max current      : {result.awg_max_current_amp_1} A");
                }
                sw.WriteLine($"Weight               : {result.weight_1} " + MassUnitsLabel);

                if (input.processSecondary)
                {
                    sw.WriteLine("\nSecondary:\n");
                    sw.WriteLine($"Turns                : {result.N_2}");
                    sw.WriteLine($"Turns per layer      : {result.N_per_layer_2}");
                    sw.WriteLine($"Total layers         : {result.totalLayers_2}");
                    sw.WriteLine($"Last layer turns     : {result.lastLayerTurns_2}");
                    sw.WriteLine($"Wire length          : {result.length_m_2} m / {result.length_ft_2} ft");
                    sw.WriteLine($"Build-up             : {result.buildup_mm_2} mm");
                    sw.WriteLine($"R                    : {result.R_2}");
                    sw.WriteLine($"Total build-up       : {result.N_2} mm");
                    sw.WriteLine($"L                    : {result.L_2} H");
                    sw.WriteLine($"Vout idle            : {result.Vout_idle} V");
                    sw.WriteLine($"Vout full load       : {result.Vout_load} V");
                    sw.WriteLine($"Iout full load       : {result.Iout_max} A");
                    sw.WriteLine($"AWG max current      : {result.awg_max_current_amp_2} A");
                    sw.WriteLine($"Weight               : {result.weight_2} " + MassUnitsLabel);

                    sw.WriteLine($"\nTurns ratio          : {result.turns_ratio}");
                    sw.WriteLine($"Wire c.s.a ratio     : {result.wire_csa_ratio}");
                    sw.WriteLine($"Total weight         : {result.wire_total_weight} " + MassUnitsLabel);
                    sw.WriteLine($"Weight ratio         : {result.wire_weight_ratio}");
                    sw.WriteLine($"Output Power         : {result.power_VA} VA");
                    sw.WriteLine($"Total equivalent R   : {result.total_eq_R}");
                    sw.WriteLine($"% Regulation         : {result.regulation}");
                }
                if (result.warnings.Count > 0)
                {
                    sw.WriteLine("\nWarnings:\n");
                    foreach (string msg in result.warnings)
                    {
                        sw.WriteLine(msg);
                    }
                }
            }
        }

        public void SaveSettings(trans_calc_input_text strin, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.V_IN]}={strin.Vin}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.B_MAX]}={strin.Bmax}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.H]}={strin.H}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.PERMEABILITY]}={strin.permeability}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.I_EX]}={strin.Iex}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.CORE_W]}={strin.core_W}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.CORE_H]}={strin.core_H}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.CORE_L]}={strin.core_L}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.Ae_W]}={strin.Ae_W}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.Ae_H]}={strin.Ae_H}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.MPATH_W]}={strin.mpath_W}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.MPATH_H]}={strin.mpath_H}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.WINDOW_SIZE]}={strin.window_size}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.COUPLING_COEFF]}={strin.coupling_coeff}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.STACKING_FACTOR]}={strin.stackingFactor}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.INSULATION]}={strin.insulationThickness}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.V_OUT]}={strin.Vout}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.IS_V_OUT_AT_MAX_LOAD]}={strin.isVoutAtFullLoad}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.I_OUT]}={strin.Iout_max}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.MAX_TEMP]}={strin.maxTemp}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.MAX_EQ_R]}={strin.max_eq_R}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.AWG_1]}={strin.awg1}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.W_FACTOR_1]}={strin.wfactor1}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.N_1]}={strin.N1}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.N_PER_LAYER_1]}={strin.N_per_layer1}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.PF_1]}={strin.pf}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.CM_PER_AMP_1]}={strin.ampacity1}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.AWG_2]}={strin.awg2}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.W_FACTOR_2]}={strin.wfactor2}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.N_2]}={strin.N2}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.N_PER_LAYER_2]}={strin.N_per_layer2}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.CM_PER_AMP_2]}={strin.ampacity2}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.H_UNITS]}={(int)this.H_Units}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.TEMP_UNITS]}={(this.IsTempUnitsC ? "1" : "0")}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.WEIGHT_UNITS]}={(this.IsMassUnits_g ? "1" : "0")}");
            }
        }
            
        public trans_calc_result_text Calculate(trans_calc_input_text text_input)
        {
            trans_calc_input input = convertTextToInput(text_input);

            double L1;
            double Ae;
            trans_calc_result result = CalculateCommon(ref input, out L1, out Ae);

            // Calculate primary
            trans_calc_result_winding w1 = calculateWinding(input.common, input.primary);
            w1.L = L1;
            result.primary = w1;
 
            //Calculate secondary if configured 
            if (input.processSecondary)
            {
                result.total_thickness_mm = w1.thickness_mm + input.common.InsulationThickness;
                result.Iout_max = input.common.Iout_max;
                input.common.Core_H += w1.thickness_mm / 1000;
                input.common.Core_W += w1.thickness_mm / 1000;

                trans_calc_result_winding w2;
                int maxAttemps = 100;
                int count = 0;
                double Vout_load = input.common.Vout;
                while (true)
                {
                    w2 = CalculateSecondary(input, w1.resistance, ref result);
                    double Vout_ratio = 1 - result.Vout_load / Vout_load;

                    bool recalcVatFullLoad =
                        input.common.IsVoutAtFullLoad &&
                        input.common.Iout_max > 0.0000000001 &&
                        result.Vout_load > 0.0000000000001 &&
                        result.Vout_idle > 0.0000000000001 &&
                        Math.Abs(Vout_ratio) > 0.00001 && 
                        ++count < maxAttemps;

                    if (!recalcVatFullLoad)
                    {
                        break;
                    }

                    double Vdelta = (Vout_load - result.Vout_load);
                    input.common.Vout += Vdelta;
                }

                if (result.permeability > 0.00000000001 && result.mpath_l_m > 0.0000001)
                {
                    w2.L = w2.N * w2.N * result.permeability * u0 * Ae / result.mpath_l_m;
                }

                result.secondary = w2;
                result.total_thickness_mm += w2.thickness_mm;
                result.wire_total_weight = w1.mass + w2.mass;
                result.wire_csa_ratio = input.primary.awg.Csa_m2 / input.secondary.awg.Csa_m2;
                result.wire_weight_ratio = w1.mass / w2.mass;
            }

            ConvertUnits(ref result);

            return new trans_calc_result_text(result, input); 
        }

        private void ConvertUnits (ref trans_calc_result result)
        {
            if (H_units == H_UNITS.AMP_TURNS_IN)
            {
                result.H *= 0.0254;
            }
            else if (H_units == H_UNITS.OERSTEDS)
            {
                result.H = AmpTurns_to_Oe(result.H);
            }

            if (!IsMassUnits_g)
            {
                result.wire_total_weight *= lbs_in_g;
                result.primary.mass *= lbs_in_g;
                result.secondary.mass *= lbs_in_g;
            }
        }

        private trans_calc_result CalculateCommon(ref trans_calc_input input, out double L1, out double Ae)
        {
            trans_calc_result result = new trans_calc_result();

            double Epeak = input.common.Vin * Math.Sqrt(2);
            double omega = input.common.Freq * 2 * Math.PI;
            Ae = input.common.Ae_W * input.common.Ae_H * input.common.StackingFactor;
            double l_m = input.common.mpath_l_cm;
            double V_in = input.common.Vin;
            double I_ex = input.common.I_ex;
            double u = input.common.permeability;
            double H_peak = input.common.H_ampt_m;
            
            L1 = 0;

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

            if (l_m > 0.0000001)
            {
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

            result.mpath_l_m = l_m;
            result.B_max = input.common.B_max;
            result.H = H_peak;
            result.I_ex = I_ex;
            result.permeability = u;
            return result;
        }

        private trans_calc_result_winding CalculateSecondary (trans_calc_input input, double w1_R, ref trans_calc_result result)
        {
            double Vout = input.common.Vout;

            if (Vout > 0.00000001 && input.secondary.N == 0)
            {
                input.secondary.N = (int)(input.primary.N / input.common.Vin * Vout / input.common.CouplingCoeff);
            }
            else if (input.secondary.N > 0)
            {
                Vout = input.common.Vin / input.primary.N * input.secondary.N * input.common.CouplingCoeff;
            }

            double turns_ratio = (double)input.primary.N / (double)input.secondary.N;

            trans_calc_result_winding w2 = calculateWinding(input.common, input.secondary);

            double Vout_idle = Vout;
            double Vout_load = 0;

            double total_R = w1_R / turns_ratio / turns_ratio + w2.resistance;

            if (input.common.Iout_max > 0.0000000001)
            {
                double regulation_vdrop = input.common.Iout_max * total_R;
                if (regulation_vdrop > Vout_idle / 2)
                {
                    throw new Exception($"Voltage drop too high: {regulation_vdrop}. Check Iout, Vout, wire ga");
                }
                
                Vout_load = Vout_idle - regulation_vdrop;

                result.Iout_max = input.common.Iout_max;
                result.power_VA = result.Iout_max * Vout_load;
                result.regulation = (Vout_idle - Vout_load) / Vout_idle * 100;

                double ph0 = Math.Acos(input.common.pf1);
                double Ip_re = result.Iout_max / turns_ratio + result.I_ex * input.common.pf1;
                double Ip_im = result.I_ex * Math.Sin(ph0);
                result.Ip_full_load =
                    Math.Sqrt(Math.Pow(Ip_re, 2) + Math.Pow(Ip_im, 2));
            }

            result.Vout_idle = Vout_idle;
            result.Vout_load = Vout_load;
            result.turns_ratio = turns_ratio;
            result.total_eq_R = total_R;

            return w2;

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
            if (strin.Vin == "120")
            {
                res.common.Freq = 60;
            }
            else if (strin.Vin == "220")
            {
                res.common.Freq = 50;
            }
            else
            {
                throw new Exception($"Unexpected mains voltage: {strin.Vin}, 110 or 220 expected");
            }

            res.common.IsVoutAtFullLoad = strin.isVoutAtFullLoad;

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
                if (res.common.pf1 < 0 || res.common.pf1 > 1.0)
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

            if (strin.window_size != "")
            {
                // in cm
                res.common.WindowSize = double.Parse(strin.window_size, NumberStyles.Float);
                if (res.common.WindowSize < 0.1 || res.common.WindowSize > 50)
                {
                    throw new Exception("Invalid window size in cm");
                }
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

            if (strin.insulationThickness != "")
            {
                res.common.InsulationThickness = double.Parse(strin.insulationThickness, NumberStyles.Float);
            }            
            
            if (res.common.WindowSize > 0.0000001)
            {
                if (res.common.InsulationThickness < 0 || res.common.InsulationThickness > res.common.WindowSize)
                {
                    throw new Exception("Insulation thickness in mm cannot exceed window size");
                }
            }

            if (strin.Vout != "")
            {
                res.common.Vout = double.Parse(strin.Vout, NumberStyles.Float);
                if (res.common.Vout < 0.1)
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

            if (strin.max_eq_R != "")
            {
                res.common.max_res_R = double.Parse(strin.max_eq_R, NumberStyles.Float);
                if (res.common.max_res_R < 1)
                {
                    throw new Exception("Invalid value of max equivalent R");
                }
            }


            res.primary = convertWinding("Primary", strin.awg1, strin.wfactor1, strin.N1, strin.N_per_layer1, strin.ampacity1);

            if ((strin.N2 != "" || strin.Vout != ""))
            {
                res.secondary = convertWinding("Secondary", strin.awg2, strin.wfactor2, strin.N2, strin.N_per_layer2, strin.ampacity2);
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

            return res;
        }
    }

}