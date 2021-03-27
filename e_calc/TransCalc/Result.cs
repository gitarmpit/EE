namespace TransCalc
{
    public class trans_calc_result_winding
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
        public AWG awg;
    }

    public struct trans_calc_result
    {
        public trans_calc_result_winding secondary;
        public trans_calc_result_winding primary;
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
}