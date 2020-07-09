using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forms1
{
    struct BiasResult
    {
        public double r1;
        public double r2;
        public double ve;
        public double vce;
        public double re;
        public double rc;
        public double vb;
        public double ie;
        public double ib;
        public double ir1;
        public double ir2;
        public double vrc;
    }
    class Bias
    {
        MainForm mainForm;
        public Bias(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

   

        private static double parse_R(String sr)
        {
            double rmul = 1;
            double R;
            if (sr.ToLower().EndsWith("k"))
            {
                rmul = 1000.0;
                sr = sr.Substring(0, sr.Length - 1);
            }
            else if (sr.ToLower().EndsWith("r"))
            {
                rmul = 1.0;
                sr = sr.Substring(0, sr.Length - 1);
            }

            R = Double.Parse(sr) * rmul;

            return R;
        }


        public BiasResult Calculate(string s_vcc, string s_ic, string s_beta, string s_vbe,
            string ve_re, string vce_rc, string s_r1, string s_r2)
        {
            double vcc = Double.Parse(s_vcc);
            double ic = Double.Parse(s_ic) / 1000;
            double beta = Double.Parse(s_beta);
            double vbe = Double.Parse(s_vbe);

            ve_re = ve_re.ToLower();
            vce_rc = vce_rc.ToLower();

            BiasResult res = new BiasResult();

            if (s_r1 == "" && s_r2 == "")
            {
                res.r1 = vcc / (ic / 10);
            }
            else if (s_r1 != "")
            {
                res.r1 = parse_R(s_r1);
            }
            else
            {
                res.r1 = 0.0;
                res.r2 = parse_R(s_r2);
            }

            double ib = ic / beta;

            res.ie = ic + ib;

            if (ve_re.EndsWith("r") || ve_re.EndsWith("k"))
            {
                res.re = Double.Parse(ve_re.Substring(0, ve_re.Length - 1));
                if (ve_re.EndsWith("k"))
                {
                    res.re *= 1000;
                }

                res.ve = res.re * res.ie;

            }
            else if (ve_re.EndsWith("v"))
            {
                res.ve = Double.Parse(ve_re.Substring(0, ve_re.Length - 1));
                res.re = res.ve / res.ie;
            }
            else
            {
                throw new Exception ("Ve/Re: "+ ve_re  + ": missing v or R suffix");
            }

            if (vce_rc.EndsWith("r") || vce_rc.EndsWith("k"))
            {
                res.rc = Double.Parse(vce_rc.Substring(0, vce_rc.Length - 1));
                if (vce_rc.EndsWith("k"))
                {
                    res.rc *= 1000;
                }

                res.vrc = res.rc * ic;
                res.vce = vcc - res.ve - res.vrc;
                if (res.vce < 0)
                {
                    res.vce = 0;
                }

            }
            else if (vce_rc.EndsWith("v"))
            {
                res.vce = Double.Parse(vce_rc.Substring(0, vce_rc.Length - 1));
                res.vrc = vcc - res.vce - res.ve;
                if (res.vrc < 0)
                {
                    res.vrc = 0;
                }
                res.rc = res.vrc / ic;
            }
            else
            {
                throw new Exception("Vce/Rc: " + vce_rc + ": missing v or R suffix");
            }

            res.vb = res.ve + vbe;

            if (res.r1 < 0.0001)
            {
                res.r1 = res.r2 * (vcc / res.vb - 1);
                double vth = vcc * res.r2 / (res.r1 + res.r2);
                double rth = res.r1 * res.r2 / (res.r1 + res.r2);

                if ((res.ie * res.r1) / (beta + 1) > vcc)
                {
                    res.r1 = vcc * 0.6 / res.ie * beta;
                    //System.out.println("r1 is too high, reducing to " + r1);
                }
            }

            double rp = (vcc - (res.ie * res.r1) / (beta + 1)) / res.vb;

            res.r2 = res.r1 / (rp - 1);
            double vth2 = vcc * res.r2 / (res.r1 + res.r2);
            double rth2 = res.r1 * res.r2 / (res.r1 + res.r2);

            res.ir1 = (vcc - res.vb) / res.r1;
            res.ir2 = res.vb / res.r2;
            res.ib = res.ir1 - res.ir2;


            return res;

        }
    }
}
