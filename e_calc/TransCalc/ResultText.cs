using System;
using System.Collections.Generic;

namespace TransCalc
{
    public struct trans_calc_result_text
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
        public string AWG1;
        public string AWG2;

        public trans_calc_result_text(trans_calc_result res, TransCalcInput input)
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
                (res.primary.lastLayerTurns != 0) ? res.primary.lastLayerTurns.ToString() : Constants.EmptyValue;
            this.mpath_l_m = (res.mpath_l_m > 0.0000001) ?
                String.Format("{0:0.##}", res.mpath_l_m) : Constants.EmptyValue;
            this.awg_max_current_amp_1 =
                (res.primary.awg_max_current_amp > 0.0000001) ? String.Format("{0:0.##}", res.primary.awg_max_current_amp) : Constants.EmptyValue;
            this.L_1 =
                (res.primary.L > 0.0000001) ? String.Format("{0:0.##}", res.primary.L) : Constants.EmptyValue;

            this.B_max = String.Format("{0:0.##}", res.B_max);
            this.H =
                (res.H > 0.0000001) ? String.Format("{0:0.##}", res.H) : Constants.EmptyValue;

            this.I_ex =
                (res.I_ex > 0.0000001) ? String.Format("{0:0.##}", res.I_ex) : Constants.EmptyValue;

            this.permeability =
                (res.permeability > 0.0000001) ? String.Format("{0:0.##}", res.permeability) : Constants.EmptyValue;

            this.weight_1 =
                (res.primary.mass > 0.0000001) ? String.Format("{0:0.##}", res.primary.mass) : Constants.EmptyValue;

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
                    (res.secondary.awg_max_current_amp > 0.0000001) ? String.Format("{0:0.##}", res.secondary.awg_max_current_amp) : Constants.EmptyValue;

                this.L_2 =
                    (res.secondary.L > 0.0000001) ? String.Format("{0:0.##}", res.secondary.L) : Constants.EmptyValue;

                this.weight_2 =
                    (res.secondary.mass > 0.0000001) ? String.Format("{0:0.##}", res.secondary.mass) : Constants.EmptyValue;

                this.total_thickness_mm =
                    (res.total_thickness_mm > 0.0000001) ? String.Format("{0:0.##}", res.total_thickness_mm) : Constants.EmptyValue;

                this.Vout_idle = String.Format("{0:0.##}", res.Vout_idle);
                this.Vout_load = (res.Vout_load > 0.0000001) ?
                    String.Format("{0:0.##}", res.Vout_load) : Constants.EmptyValue;
                this.Iout_max =
                    (res.Iout_max > 0.0000001) ? String.Format("{0:0.##}", res.Iout_max) : Constants.EmptyValue;

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
                    String.Format("{0:0.##}", res.Ip_full_load) : Constants.EmptyValue;
                this.power_VA = (res.power_VA > 0.0000000001) ?
                    String.Format("{0:0.##}", res.power_VA) : Constants.EmptyValue;

                this.regulation = (res.regulation > 0.0000000001) ?
                    String.Format("{0:0.##}", res.regulation) : Constants.EmptyValue;

                this.total_eq_R = (res.total_eq_R > 0.0000000001) ?
                    String.Format("{0:0.##}", res.total_eq_R) : Constants.EmptyValue;
                this.AWG1 = res.primary.awg.Gauge.ToString();
                this.AWG2 = res.secondary.awg.Gauge.ToString();
            }
            else
            {
                this.length_m_2 = Constants.EmptyValue;
                this.length_ft_2 = Constants.EmptyValue;
                this.buildup_mm_2 = Constants.EmptyValue;
                this.R_2 = Constants.EmptyValue;
                this.N_2 = Constants.EmptyValue;
                this.N_per_layer_2 = Constants.EmptyValue;
                this.totalLayers_2 = Constants.EmptyValue;
                this.lastLayerTurns_2 = Constants.EmptyValue;
                this.awg_max_current_amp_2 = Constants.EmptyValue;
                this.L_2 = Constants.EmptyValue;
                this.weight_2 = Constants.EmptyValue;
                this.total_thickness_mm = Constants.EmptyValue;
                this.Vout_idle = Constants.EmptyValue;
                this.Vout_load = Constants.EmptyValue;
                this.Iout_max = Constants.EmptyValue;
                this.turns_ratio = Constants.EmptyValue;
                this.wire_csa_ratio = Constants.EmptyValue;
                this.wire_total_weight = Constants.EmptyValue;
                this.wire_weight_ratio = Constants.EmptyValue;
                this.Ip_full_load = Constants.EmptyValue;
                this.power_VA = Constants.EmptyValue;
                this.total_eq_R = Constants.EmptyValue;
                this.regulation = Constants.EmptyValue;
                this.AWG1 = Constants.EmptyValue;
                this.AWG2 = Constants.EmptyValue;
            }
        }
    }
}