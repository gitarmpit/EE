using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransCalc
{
    public class FilePersistence
    {
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

        private Dictionary<CONFIG_KEYWORDS, string> cfg_keywords;
        private TransCalc tc;

        public FilePersistence(TransCalc tc)
        {
            this.tc = tc;
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

        public void SaveSettings(trans_calc_input_text strin, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.V_IN]}={strin.Vin}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.B_MAX]}={strin.Bmax}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.H]}={strin.H}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.PERMEABILITY]}={strin.permeability}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.I_EX]}={strin.I_ex}");
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
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.H_UNITS]}={(int)tc.H_Units}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.TEMP_UNITS]}={(tc.IsTempUnitsC ? "1" : "0")}");
                sw.WriteLine($"{cfg_keywords[CONFIG_KEYWORDS.WEIGHT_UNITS]}={(tc.IsMassUnits_g ? "1" : "0")}");
            }
        }

        public void SaveResults(trans_calc_input_text strin, trans_calc_result_text result, string fileName)
        {
            TransCalcInput input = new TransCalcInput(tc);
            input.ConvertTextToInput(strin);

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
                    sw.WriteLine($"H                    : {strin.H} " + tc.HUnitlsLabel);
                }
                if (strin.permeability != "")
                {
                    sw.WriteLine($"u/u0                 : {strin.permeability}");
                }
                if (strin.I_ex != "")
                {
                    sw.WriteLine($"Iex                  : {strin.I_ex} A");
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
                sw.WriteLine($"Max temperature      : {strin.maxTemp} " + tc.TempUnitsLabel);
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
                sw.WriteLine($"AWG                  : {result.AWG1}");
                sw.WriteLine($"Turns                : {result.N_1}");
                sw.WriteLine($"Turns per layer      : {result.N_per_layer_1}");
                sw.WriteLine($"Total layers         : {result.totalLayers_1}");
                sw.WriteLine($"Last layer turns     : {result.lastLayerTurns_1}");
                sw.WriteLine($"Wire length          : {result.length_m_1} m / {result.length_ft_1} ft");
                sw.WriteLine($"Build-up             : {result.buildup_mm_1} mm");
                sw.WriteLine($"R                    : {result.R_1}");
                if (result.mpath_l_m != Constants.EmptyValue)
                {
                    sw.WriteLine($"Magnetic path        : {result.mpath_l_m} m");
                }
                if (result.L_1 != Constants.EmptyValue)
                {
                    sw.WriteLine($"L                    : {result.L_1} H");
                }
                sw.WriteLine($"Bmax                 : {result.B_max} T");
                if (result.permeability != Constants.EmptyValue)
                {
                    sw.WriteLine($"u/u0                 : {result.permeability}");
                }
                if (result.H != Constants.EmptyValue)
                {
                    sw.WriteLine($"H                    : {result.H} " + tc.HUnitlsLabel);
                }
                if (result.I_ex != Constants.EmptyValue)
                {
                    sw.WriteLine($"Iex                  : {result.I_ex} A");
                }
                if (result.Ip_full_load != Constants.EmptyValue)
                {
                    sw.WriteLine($"Ip, full load        : {result.Ip_full_load} A");
                }
                if (result.awg_max_current_amp_1 != Constants.EmptyValue)
                {
                    sw.WriteLine($"AWG max current      : {result.awg_max_current_amp_1} A");
                }
                sw.WriteLine($"Weight               : {result.weight_1} " + tc.MassUnitsLabel);

                if (input.processSecondary)
                {
                    sw.WriteLine("\nSecondary:\n");
                    sw.WriteLine($"AWG                  : {result.AWG2}");
                    sw.WriteLine($"Turns                : {result.N_2}");
                    sw.WriteLine($"Turns per layer      : {result.N_per_layer_2}");
                    sw.WriteLine($"Total layers         : {result.totalLayers_2}");
                    sw.WriteLine($"Last layer turns     : {result.lastLayerTurns_2}");
                    sw.WriteLine($"Wire length          : {result.length_m_2} m / {result.length_ft_2} ft");
                    sw.WriteLine($"Build-up             : {result.buildup_mm_2} mm");
                    sw.WriteLine($"R                    : {result.R_2}");
                    sw.WriteLine($"Total build-up       : {result.total_thickness_mm} mm");
                    sw.WriteLine($"L                    : {result.L_2} H");
                    sw.WriteLine($"Vout idle            : {result.Vout_idle} V");
                    sw.WriteLine($"Vout full load       : {result.Vout_load} V");
                    sw.WriteLine($"Iout full load       : {result.Iout_max} A");
                    sw.WriteLine($"AWG max current      : {result.awg_max_current_amp_2} A");
                    sw.WriteLine($"Weight               : {result.weight_2} " + tc.MassUnitsLabel);

                    sw.WriteLine($"\nTurns ratio          : {result.turns_ratio}");
                    sw.WriteLine($"Wire c.s.a ratio     : {result.wire_csa_ratio}");
                    sw.WriteLine($"Total weight         : {result.wire_total_weight} " + tc.MassUnitsLabel);
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
        private void ProcessLine(string line, ref trans_calc_input_text strin)
        {
            string[] parts = line.Split('=');

            var key = cfg_keywords.FirstOrDefault(e => e.Value.Equals(parts[0].Trim(), StringComparison.OrdinalIgnoreCase)).Key;
            if (key == CONFIG_KEYWORDS.UNKNOWN_KEYWORD)
            {
                throw new Exception($"Error parsing cfg file, invalid keyword: {line}");
            }
            switch (key)
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
                    strin.I_ex = parts[1];
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
                    strin.isVoutAtFullLoad = bool.Parse(parts[1]);
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
                    tc.SetHUnits(parts[1]);
                    break;
                case CONFIG_KEYWORDS.TEMP_UNITS:
                    tc.IsTempUnitsC = parts[1] == "1" ? true : false;
                    break;
                case CONFIG_KEYWORDS.WEIGHT_UNITS:
                    tc.IsMassUnits_g = parts[1] == "1" ? true : false;
                    break;
                default:
                    throw new Exception($"Unknown key: {key}");
            }
        }

    }

}