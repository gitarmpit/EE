namespace TransCalc
{
    public struct trans_calc_input_text
    {
        public string Vin;           // r/o
        public string Bmax;          // r/w 
        public string permeability;  // r/w
        public string I_ex;          // r/w
        public string H;             // r/w
        public string core_W;         // r/o
        public string core_H;         // r/o
        public string core_L;         // r/o  
        public string Ae_W;           // r/o  
        public string Ae_H;           // r/o
        public string mpath_W;        // r/o
        public string mpath_H;        // r/o
        public string window_size;    // r/o
        public string coupling_coeff; // r/o
        public string stackingFactor; // r/o
        public string insulationThickness; // r/o
        public string Vout;          // r/w 
        public bool isVoutAtFullLoad;  // r/o
        public string Iout_max;        // r/o
        public string maxTemp;   // r/o
        public string pf;        // r/o
        public string max_eq_R;  // r/o
        public bool isMinimizeRegulation; //auto mode


        //windings 
        //primary:
        public string awg1;            // r/w 
        public string wfactor1;        // r/o
        public string N1;              // r/o
        public string N_per_layer1;    // r/w
        public string ampacity1;       // r/o
        //secondary:
        public string awg2;
        public string wfactor2;
        public string N2;
        public string N_per_layer2;
        public string ampacity2;

    }
}