using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace forms1
{
    public partial class MainForm : Form
    {
        Bias bias;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton_V.Select();

            edit_Bmax.Text = "1.0";
            label_Vce_Rc.Text = "Vce";
            label_VeRe.Text = "Ve";

            edit_beta.Text = "150";
            trackBar_Beta.LargeChange = 10;
            trackBar_Beta.Minimum = 10;
            trackBar_Beta.Maximum = 200;
            trackBar_Beta.SmallChange = 1;
            trackBar_Beta.Value = 150;
            trackBar_Beta.TickFrequency = 10;
            //trackBar_Beta.TickStyle = TickStyle.None;

            edit_Vbe.Text = "0.65";
            trackBar_Vbe.LargeChange = 100;
            trackBar_Vbe.Minimum = 600;
            trackBar_Vbe.Maximum = 1000;
            trackBar_Vbe.SmallChange = 20;
            trackBar_Vbe.Value = 650;
            trackBar_Vbe.TickFrequency = 20;

            edit_Vcc.Text = "10";
            trackBar_Vcc.LargeChange = 10;
            trackBar_Vcc.SmallChange = 1;
            trackBar_Vcc.Minimum = 0;
            trackBar_Vcc.Maximum = 200;
            trackBar_Vcc.Value = 100;
            trackBar_Vcc.TickFrequency = 20;

            edit_Ic.Text = "1";
            trackBar_Ic.LargeChange = 500;
            trackBar_Ic.SmallChange = 100;
            trackBar_Ic.Minimum = 500;
            trackBar_Ic.Maximum = 100000;
            trackBar_Ic.Value = 1000;
            trackBar_Ic.TickFrequency = 200;

            edit_Vce_Rc.Text = "5v";
            trackBar_Vce_Rc.LargeChange = 10;
            trackBar_Vce_Rc.SmallChange = 1;
            trackBar_Vce_Rc.Minimum = 0;
            trackBar_Vce_Rc.Maximum = 200;
            trackBar_Vce_Rc.Value = 100;
            trackBar_Vce_Rc.TickFrequency = 20;

            edit_VeRe.Text = "1v";
            trackBar_Ve_Re.LargeChange = 10;
            trackBar_Ve_Re.SmallChange = 1;
            trackBar_Ve_Re.Minimum = 0;
            trackBar_Ve_Re.Maximum = 50;
            trackBar_Ve_Re.Value = 10;
            trackBar_Ve_Re.TickFrequency = 5;

            bias = new Bias(this);
            if (validate_beta_calc())
            {
                calculateBias();
            }

            try
            {
                string csv = File.ReadAllText("transcalc.csv");
                csv = csv.Trim(new char[] { '\r', '\n', ' ' });
                string[] values = csv.Split(',');
                if (values.Length == 29)
                {
                    string mains = values[0];
                    if (mains == "120")
                    {
                        radiobutton_mains_US.Select();
                    }
                    else if (mains == "220")
                    {
                        radiobutton_mains_EU.Select();
                    }
                    else
                    {
                        throw new Exception($"Unexpected mains voltage: {mains}");
                    }
                    edit_Bmax.Text = values[1];
                    edit_permeability.Text = values[2];
                    edit_Iex.Text = values[3];
                    edit_amptm.Text = values[4];
                    edit_bobbinW.Text = values[5];
                    edit_bobbinH.Text = values[6];
                    edit_bobbinL.Text = values[7];
                    edit_coreW.Text = values[8];
                    edit_coreH.Text = values[9];
                    edit_mpath_W.Text = values[10];
                    edit_mpath_H.Text = values[11];
                    edit_windowSize.Text = values[12];
                    edit_couplingCoeff.Text = values[13];
                    edit_stackingFactor.Text = values[14];
                    edit_insulationThickness.Text = values[15];
                    edit_Vout.Text = values[16];
                    edit_Iout_max.Text = values[17];

                    edit_awg1.Text = values[18];
                    edit_Wfactor1.Text = values[19];
                    edit_N1.Text = values[20];
                    edit_turnsPerLayer1.Text = values[21];
                    edit_ampacity1.Text = values[22];

                    edit_awg2.Text = values[23];
                    edit_Wfactor2.Text = values[24];
                    edit_N2.Text = values[25];
                    edit_turnsPerLayer2.Text = values[26];
                    edit_ampacity2.Text = values[27];

                    edit_max_temp.Text = values[28];

                }
                else
                {
                    throw new Exception("Error parsing csv file");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }


        }

        private void OnCalculate(object sender, EventArgs e)
        {
            runTransCalc();
        }

        private void runTransCalc()
        {
            try
            {
                TransCalc tc = new TransCalc();
                if (edit_max_temp.Text == "")
                {
                    edit_max_temp.Text = "20";
                }

                trans_calc_input_text strin = new trans_calc_input_text();
                if (radiobutton_mains_US.Checked)
                {
                    strin.Vin = "120";
                    strin.freq = "60";
                }
                else
                {
                    strin.Vin = "220";
                    strin.freq = "50";
                }
                strin.Bmax = edit_Bmax.Text;
                strin.permeability = edit_permeability.Text;
                strin.Iex = edit_Iex.Text;
                strin.H_ampt_m = edit_amptm.Text;
                strin.core_W = edit_bobbinW.Text;
                strin.core_H = edit_bobbinH.Text;
                strin.core_L = edit_bobbinL.Text;
                strin.Ae_W = edit_coreW.Text;
                strin.Ae_H = edit_coreH.Text;
                strin.mpath_W = edit_mpath_W.Text;
                strin.mpath_H = edit_mpath_H.Text;
                strin.window_mm = edit_windowSize.Text;
                strin.coupling_coeff = edit_couplingCoeff.Text;
                strin.stackingFactor = edit_stackingFactor.Text;
                strin.insulationThickness = edit_insulationThickness.Text;
                strin.Vout = edit_Vout.Text;
                strin.Iout_max = edit_Iout_max.Text;
                strin.awg1 = edit_awg1.Text;
                strin.wfactor1 = edit_Wfactor1.Text;
                strin.N1 = edit_N1.Text;
                strin.N_per_layer1 = edit_turnsPerLayer1.Text;
                strin.ampacity1 = edit_ampacity1.Text;
                strin.ampacity2 = edit_ampacity2.Text;

                strin.awg2 = edit_awg2.Text;
                strin.wfactor2 = edit_Wfactor2.Text;
                strin.N2 = edit_N2.Text;
                strin.N_per_layer2 = edit_turnsPerLayer2.Text;
                strin.maxTempC = edit_max_temp.Text;
                trans_calc_result_text result = tc.Calculate(strin);

                res_length_m_1.Text = result.length_m_1;
                res_length_ft_1.Text = result.length_ft_1;
                res_thickness_mm_1.Text = result.thickness_mm_1;
                res_resistance_1.Text = result.resistance_1;
                res_turns_1.Text = result.N_1;
                res_turns_per_layer_1.Text = result.N_per_layer_1;
                res_totalLayers_1.Text = result.totalLayers_1;
                res_lastLayerTurns_1.Text = result.lastLayerTurns_1;
                res_mpath_m.Text = result.mpath_l_m;
                res_max_current_1.Text = result.awg_max_current_amp_1;
                res_L1.Text = result.L1;
                res_Bmax.Text = result.B_max;
                res_amptm.Text = result.H_amp_t_m;
                res_Iex.Text = result.I_ex_amp;
                res_permeability.Text = result.permeability;
                res_weight_g1.Text = result.weight_g_1;
                res_length_m_2.Text = result.length_m_2;
                res_length_ft_2.Text = result.length_ft_2;
                res_thickness_mm_2.Text = result.thickness_mm_2;
                res_resistance_2.Text = result.resistance_2;
                res_turns_2.Text = result.N_2;
                res_turns_per_layer_2.Text = result.N_per_layer_2;
                res_totalLayers_2.Text = result.totalLayers_2;
                res_lastLayerTurns_2.Text = result.lastLayerTurns_2;
                res_max_current_2.Text = result.awg_max_current_amp_2;
                res_L2.Text = result.L2;
                res_Vout_idle.Text = result.Vout_idle;
                res_Vout_imax.Text = result.Vout_imax;
                res_Iout.Text = result.Iout_max;
                res_total_thickness_mm.Text = result.total_thickness_mm;
                res_weight_g2.Text = result.weight_g_2;
                res_turns_ratio.Text = result.turns_ratio;
                res_csa_ratio.Text = result.wire_csa_ratio;
                res_wire_total_mass.Text = result.wire_total_weight;
                res_wire_weight_ratio.Text = result.wire_weight_ratio;
                res_Ip_full_load.Text = result.Ip_full_load;
                res_powerVA.Text = result.power_VA;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void transCalcTab_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*
            TabPage page = calcTab.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
            */
        }

        private void OnClear(object sender, EventArgs e)
        {
            edit_bobbinL.Text = "";
            edit_bobbinW.Text = "";
            edit_bobbinH.Text = "";
            edit_coreW.Text = "";
            edit_coreH.Text = "";
            edit_N1.Text = "";
            edit_Wfactor1.Text = "";
            edit_turnsPerLayer1.Text = "";
            res_lastLayerTurns_1.Text = "";
            res_length_ft_1.Text = "";
            res_length_m_1.Text = "";
            res_resistance_1.Text = "";
            res_thickness_mm_1.Text = "";
            res_totalLayers_1.Text = "";

            edit_N2.Text = "";
            edit_Wfactor2.Text = "";
            edit_turnsPerLayer2.Text = "";
            res_lastLayerTurns_2.Text = "";
            res_length_ft_2.Text = "";
            res_length_m_2.Text = "";
            res_resistance_2.Text = "";
            res_thickness_mm_2.Text = "";
            res_totalLayers_2.Text = "";

        }

        private string RtoText (double r)
        {
            if (r > 1000)
            {
                return (r / 1000).ToString("F2") + "K";
            }
            else
            {
                return (r).ToString("F2") + "R";
            }
        }
        private void calculateBias()
        {
            try
            {
                BiasResult res = bias.Calculate(edit_Vcc.Text, edit_Ic.Text, edit_beta.Text,
                    edit_Vbe.Text, edit_VeRe.Text, edit_Vce_Rc.Text, edit_R1.Text, edit_R2.Text);
                label_R1.Text = RtoText(res.r1);
                label_R2.Text = RtoText(res.r2);
                label_R3.Text = RtoText(res.rc);
                label_R4.Text = RtoText(res.re);
                label_R1.Text = RtoText(res.r1); 
                label_Ib.Text = (res.ib * 1000000).ToString("F2") + "uA";
                label_Ir1.Text = (res.ir1 * 1000000).ToString("F2") + "uA";
                label_Ir2.Text = (res.ir2 * 1000000).ToString("F2") + "uA";
                label_Vce.Text = (res.vce).ToString("F1") + "V";
                label_Ve.Text = (res.ve).ToString("F1") + "V";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // ShowDialog(); 
            }
        }

        private void buttion_bias_Click(object sender, EventArgs e)
        {
            if (edit_Vcc.Text != "" && edit_Ic.Text != "" && edit_beta.Text != "" &&
                edit_Vbe.Text != "" && edit_VeRe.Text != "" && edit_Vce_Rc.Text != "")
            {
                calculateBias();
            }
            else
            {
                MessageBox.Show("Need to set Vcc Ic Ve(Re) Vce(Rc)");
            }
        }

        private bool validate_beta_calc()
        {
            if (edit_Vcc.Text != "" && edit_Ic.Text != "" && edit_beta.Text != "" &&
                edit_Vbe.Text != "" && edit_VeRe.Text != "" && edit_Vce_Rc.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            if (tb.Name == trackBar_Beta.Name)
            {
                edit_beta.Text = ((float)trackBar_Beta.Value).ToString();
            }
            else if (tb.Name == trackBar_Vbe.Name)
            {
                edit_Vbe.Text = ((float)trackBar_Vbe.Value / 1000).ToString("F2");
            }
            else if (tb.Name == trackBar_Vcc.Name)
            {
                edit_Vcc.Text = ((float)trackBar_Vcc.Value / 10).ToString("F1");
            }
            else if (tb.Name == trackBar_Ic.Name)
            {
                edit_Ic.Text = ((float)trackBar_Ic.Value / 1000).ToString("F1");
            }
            else if (tb.Name == trackBar_Vce_Rc.Name)
            {
                if (radioButton_V.Checked)
                {
                    edit_Vce_Rc.Text = ((float)trackBar_Vce_Rc.Value / 10).ToString("F1") + "v";
                }
            }
            else if (tb.Name == trackBar_Ve_Re.Name)
            {
                if (radioButton_V.Checked)
                {
                    edit_VeRe.Text = ((float)trackBar_Ve_Re.Value / 10).ToString("F1") + "v";
                }
            }

            if (validate_beta_calc())
            {
                calculateBias();
            }
        }

        private void parseBeta()
        {
            try
            {
                trackBar_Beta.Value = Int32.Parse(edit_beta.Text);
            }
            catch (Exception e)
            {
                edit_beta.Text = "";
            }

        }

        private void edit_Leave(object sender, EventArgs e)
        {
            parseBeta();
        }

        private void edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                parseBeta();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }

        }

        private void radioButton_R_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_R.Checked)
            {
                label_Vce_Rc.Text = "Rc";
                label_VeRe.Text = "Re";
            }
            else
            {
                label_Vce_Rc.Text = "Vce";
                label_VeRe.Text = "Ve";
            }
        }


        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
             {
                runTransCalc();
                e.Handled = true;
            }

        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }
        private void OnLoad(object sender, EventArgs e)
        {

        }

        private void OnSave(object sender, EventArgs e)
        {

        }
    }
}
