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
using GroupBox = System.Windows.Forms.GroupBox;
using TextBox = System.Windows.Forms.TextBox;

namespace forms1
{
    public partial class MainForm : Form
    {
        private Bias bias;
        private TransCalc tc;
        // Units that require conversion:
        private double transCalc_H;
        private List<string> tc_warnings;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton_V.Select();

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

            tc = new TransCalc();
            SetUnitRadioButtons();
            button_saveResults.Enabled = false;
            radiobutton_mains_US.Select();
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            runTransCalc();
        }

        private trans_calc_input_text buildInput()
        {
            trans_calc_input_text strin = new trans_calc_input_text();
            if (radiobutton_mains_US.Checked)
            {
                strin.Vin = "120";
            }
            else
            {
                strin.Vin = "220";
            }

            strin.Bmax = edit_Bmax.Text;
            strin.permeability = edit_permeability.Text;
            strin.Iex = edit_Iex.Text;
            if (transCalc_H > 0.00000001)
            {
                strin.H = transCalc_H.ToString();
            }
            else
            {
                strin.H = "";
            }
            strin.core_W = edit_coreSize_W.Text;
            strin.core_H = edit_coreSize_H.Text;
            strin.core_L = edit_coreSize_L.Text;
            strin.Ae_W = edit_Ae_W.Text;
            strin.Ae_H = edit_Ae_H.Text;
            strin.mpath_W = edit_mpath_W.Text;
            strin.mpath_H = edit_mpath_H.Text;
            strin.window_size = edit_windowSize.Text;
            strin.coupling_coeff = edit_couplingCoeff.Text;
            strin.stackingFactor = edit_stackingFactor.Text;
            strin.insulationThickness = edit_insulationThickness.Text;
            strin.Vout = edit_Vout.Text;
            strin.Iout_max = edit_Iout_max.Text;
            strin.awg1 = edit_awg1.Text;
            strin.wfactor1 = edit_Wfactor1.Text;
            strin.N1 = edit_N1.Text;
            strin.N_per_layer1 = edit_N_PerLayer1.Text;
            strin.ampacity1 = edit_ampacity1.Text;
            strin.ampacity2 = edit_ampacity2.Text;
            strin.pf = edit_power_factor_1.Text;

            strin.awg2 = edit_awg2.Text;
            strin.wfactor2 = edit_Wfactor2.Text;
            strin.N2 = edit_N2.Text;
            strin.N_per_layer2 = edit_N_PerLayer2.Text;
            strin.maxTemp = edit_max_temp.Text;
            strin.max_eq_R = edit_max_eq_R.Text;
            strin.isVoutAtFullLoad = checkBox_fullLoad.Checked;

            return strin;
        }

        private void runTransCalc()
        {
            ClearResults();
            try
            {
                res_warnings.Text = "";
                if (edit_max_temp.Text == "")
                {
                    edit_max_temp.Text = "20";
                }

                if (edit_couplingCoeff.Text == "")
                {
                    edit_couplingCoeff.Text = "1";
                }

                if (edit_stackingFactor.Text == "")
                {
                    edit_stackingFactor.Text = "1";
                }

                trans_calc_input_text strin = buildInput();

                trans_calc_result_text result = tc.Calculate(strin);

                SetResultUnits();

                res_length_m_1.Text = result.length_m_1;
                res_length_ft_1.Text = result.length_ft_1;
                res_thickness_mm_1.Text = result.buildup_mm_1;
                res_resistance_1.Text = result.R_1;
                res_turns_1.Text = result.N_1;
                res_turns_per_layer_1.Text = result.N_per_layer_1;
                res_totalLayers_1.Text = result.totalLayers_1;
                res_lastLayerTurns_1.Text = result.lastLayerTurns_1;
                res_mpath_m.Text = result.mpath_l_m;
                res_max_current_1.Text = result.awg_max_current_amp_1;
                res_L1.Text = result.L_1;
                res_Bmax.Text = result.B_max;
                res_H.Text = result.H;
                res_Iex.Text = result.I_ex;
                res_permeability.Text = result.permeability;
                res_weight_g1.Text = result.weight_1;
                res_length_m_2.Text = result.length_m_2;
                res_length_ft_2.Text = result.length_ft_2;
                res_thickness_mm_2.Text = result.buildup_mm_2;
                res_resistance_2.Text = result.R_2;
                res_turns_2.Text = result.N_2;
                res_turns_per_layer_2.Text = result.N_per_layer_2;
                res_totalLayers_2.Text = result.totalLayers_2;
                res_lastLayerTurns_2.Text = result.lastLayerTurns_2;
                res_max_current_2.Text = result.awg_max_current_amp_2;
                res_L2.Text = result.L_2;
                res_Vout_idle.Text = result.Vout_idle;
                res_Vout_imax.Text = result.Vout_load;
                res_Iout.Text = result.Iout_max;
                res_total_thickness_mm.Text = result.total_thickness_mm;
                res_weight_g2.Text = result.weight_2;
                res_turns_ratio.Text = result.turns_ratio;
                res_csa_ratio.Text = result.wire_csa_ratio;
                res_wire_total_mass.Text = result.wire_total_weight;
                res_wire_weight_ratio.Text = result.wire_weight_ratio;
                res_Ip_full_load.Text = result.Ip_full_load;
                res_powerVA.Text = result.power_VA;
                res_total_eq_R.Text = result.total_eq_R;
                res_regulation.Text = result.regulation;

                tc_warnings = new List<string>();
                tc_warnings = result.warnings;
                foreach (string msg in result.warnings)
                {
                    res_warnings.Text += msg + "\n";    
                }

                if (res_total_thickness_mm.Text != TransCalc.EmptyValue)
                {
                    res_total_thickness_mm.ForeColor =
                        result.IsWindowExceeded ? Color.Red : Color.FromArgb(0, 180, 0);
                }

                if (res_total_eq_R.Text != TransCalc.EmptyValue)
                {
                    res_total_eq_R.ForeColor =
                        result.IsMaxResistanceExceeded ? Color.Red : Color.FromArgb(0, 180, 0);
                }

                if (res_Ip_full_load.Text != TransCalc.EmptyValue)
                {
                    res_Ip_full_load.ForeColor =
                        result.IsAmpacity1Exceeded ? Color.Red : Color.FromArgb(0, 180, 0);
                    res_max_current_1.ForeColor =
                        result.IsAmpacity1Exceeded ? Color.Red : Color.FromArgb(0, 180, 0);
                }

                if (res_Iout.Text != TransCalc.EmptyValue)
                {
                    res_Iout.ForeColor =
                        result.IsAmpacity2Exceeded ? Color.Red : Color.FromArgb(0, 180, 0);
                    res_max_current_2.ForeColor =
                        result.IsAmpacity2Exceeded ? Color.Red : Color.FromArgb(0, 180, 0);
                }

                button_saveResults.Enabled = true;
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
            edit_Bmax.Text = "";
            edit_H.Text = "";
            edit_permeability.Text = "";
            edit_Iex.Text = "";
            edit_coreSize_L.Text = "";
            edit_coreSize_W.Text = "";
            edit_coreSize_H.Text = "";
            edit_Ae_W.Text = "";
            edit_Ae_H.Text = "";
            edit_mpath_H.Text = "";
            edit_mpath_W.Text = "";
            edit_windowSize.Text = "";
            edit_couplingCoeff.Text = "";
            edit_stackingFactor.Text = "";
            edit_insulationThickness.Text = "";
            edit_Vout.Text = "";
            edit_Iout_max.Text = "";
            edit_max_temp.Text = "";

            edit_awg1.Text = "";
            edit_Wfactor1.Text = "";
            edit_N1.Text = "";
            edit_N_PerLayer1.Text = "";
            edit_power_factor_1.Text = "";
            edit_ampacity1.Text = "";

            edit_awg2.Text = "";
            edit_Wfactor2.Text = "";
            edit_N2.Text = "";
            edit_N_PerLayer2.Text = "";
            edit_ampacity2.Text = "";
            transCalc_H = 0;
            edit_max_eq_R.Text = "";

            ClearResults();
        }

        private void ClearResults()
        {

            res_turns_1.Text = TransCalc.EmptyValue;
            res_turns_per_layer_1.Text = TransCalc.EmptyValue;
            res_totalLayers_1.Text = TransCalc.EmptyValue;
            res_lastLayerTurns_1.Text = TransCalc.EmptyValue;
            res_length_m_1.Text = TransCalc.EmptyValue;
            res_length_ft_1.Text = TransCalc.EmptyValue;
            res_thickness_mm_1.Text = TransCalc.EmptyValue;
            res_resistance_1.Text = TransCalc.EmptyValue;
            res_mpath_m.Text = TransCalc.EmptyValue;
            res_L1.Text = TransCalc.EmptyValue;
            res_Bmax.Text = TransCalc.EmptyValue;
            res_permeability.Text = TransCalc.EmptyValue;
            res_H.Text = TransCalc.EmptyValue;
            res_Iex.Text = TransCalc.EmptyValue;
            res_Ip_full_load.Text = TransCalc.EmptyValue;
            res_Ip_full_load.ForeColor = Color.Black;
            res_max_current_1.Text = TransCalc.EmptyValue;
            res_max_current_1.ForeColor = Color.Black;
            res_weight_g1.Text = TransCalc.EmptyValue;

            res_turns_2.Text = TransCalc.EmptyValue;
            res_turns_per_layer_2.Text = TransCalc.EmptyValue;
            res_totalLayers_2.Text = TransCalc.EmptyValue;
            res_lastLayerTurns_2.Text = TransCalc.EmptyValue;
            res_length_m_2.Text = TransCalc.EmptyValue;
            res_length_ft_2.Text = TransCalc.EmptyValue;
            res_thickness_mm_2.Text = TransCalc.EmptyValue;
            res_resistance_2.Text = TransCalc.EmptyValue;
            res_total_thickness_mm.Text = TransCalc.EmptyValue;
            res_total_thickness_mm.ForeColor = Color.Black;
            res_L2.Text = TransCalc.EmptyValue;
            res_Vout_idle.Text = TransCalc.EmptyValue;
            res_Vout_imax.Text = TransCalc.EmptyValue;
            res_Iout.Text = TransCalc.EmptyValue;
            res_max_current_2.Text = TransCalc.EmptyValue;
            res_max_current_2.ForeColor = Color.Black;
            res_weight_g2.Text = TransCalc.EmptyValue;
            res_turns_ratio.Text = TransCalc.EmptyValue;
            res_wire_weight_ratio.Text = TransCalc.EmptyValue;
            res_wire_total_mass.Text = TransCalc.EmptyValue;
            res_powerVA.Text = TransCalc.EmptyValue;
            res_csa_ratio.Text = TransCalc.EmptyValue;
            res_regulation.Text = TransCalc.EmptyValue;
            res_total_eq_R.Text = TransCalc.EmptyValue;
            res_warnings.Text = "";
            button_saveResults.Enabled = false;
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
                SetTranscalc_H(edit_H.Text);
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
        private void OnLoadSettings(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tc input file|*.tcin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        trans_calc_input_text input = tc.Load(openFileDialog.FileName);
                        if (input.Vin == "120")
                        {
                            radiobutton_mains_US.Select();
                        }
                        else if (input.Vin == "220")
                        {
                            radiobutton_mains_EU.Select();
                        }
                        else
                        {
                            throw new Exception($"Unexpected mains voltage: {input.Vin}");
                        }

                        checkBox_fullLoad.Checked = input.isVoutAtFullLoad;

                        edit_Bmax.Text = input.Bmax;
                        edit_permeability.Text = input.permeability;
                        edit_Iex.Text = input.Iex;
                        transCalc_H = double.Parse(input.H, NumberStyles.Float);
                        if (transCalc_H > 0.000000001)
                        {
                            edit_H.Text = String.Format("{0:0.##}", transCalc_H);
                        }

                        edit_coreSize_W.Text = input.core_W;
                        edit_coreSize_H.Text = input.core_H;
                        edit_coreSize_L.Text = input.core_L;
                        edit_Ae_W.Text = input.Ae_W;
                        edit_Ae_H.Text = input.Ae_H;
                        edit_mpath_W.Text = input.mpath_W;
                        edit_mpath_H.Text = input.mpath_H;
                        edit_windowSize.Text = input.window_size;
                        edit_couplingCoeff.Text = input.coupling_coeff;
                        edit_stackingFactor.Text = input.stackingFactor;
                        edit_insulationThickness.Text = input.insulationThickness;
                        edit_Vout.Text = input.Vout;
                        edit_Iout_max.Text = input.Iout_max;

                        edit_awg1.Text = input.awg1;
                        edit_Wfactor1.Text = input.wfactor1;
                        edit_N1.Text = input.N1;
                        edit_N_PerLayer1.Text = input.N_per_layer1;
                        edit_ampacity1.Text = input.ampacity1;
                        edit_power_factor_1.Text = input.pf;

                        edit_awg2.Text = input.awg2;
                        edit_Wfactor2.Text = input.wfactor2;
                        edit_N2.Text = input.N2;
                        edit_N_PerLayer2.Text = input.N_per_layer2;
                        edit_ampacity2.Text = input.ampacity2;

                        edit_max_temp.Text = input.maxTemp;
                        edit_max_eq_R.Text = input.max_eq_R;

                        SetUnitRadioButtons();
                            
                        button_saveResults.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void SetUnitRadioButtons()
        {
            if (tc.IsTempUnitsC)
            {
                radioButton_tempC.Select();
                label_units_maxtemp.Text = "C:";
            }
            else
            {
                radioButton_tempF.Select();
                label_units_maxtemp.Text = "F:";
            }

            if (tc.H_Units == TransCalc.H_UNITS.AMP_TURNS_M)
            {
                radioButton_H_amp_t_m.Select();

            }
            else if (tc.H_Units == TransCalc.H_UNITS.AMP_TURNS_IN)
            {
                radioButton_H_amp_t_in.Select();
            }
            else
            {
                radioButton_H_oe.Select();
            }

            label_units_H.Text = tc.HUnitlsLabel;
            res_label_units_H.Text = tc.HUnitlsLabel;

            if (tc.IsMassUnits_g)
            {
                radioButton_weight_g.Select();
            }
            else
            {
                radioButton_weight_lbs.Select();
            }

            res_label_units_weight1.Text = tc.MassUnitsLabel + ":";
            res_label_units_weight2.Text = tc.MassUnitsLabel + ":";
            res_label_units_total_weight.Text = tc.MassUnitsLabel + ":";
        }

        private void OnSaveSettings(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save settings in a *csv file";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Tc input file|*.tcin";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                trans_calc_input_text strin = buildInput();
                tc.SaveSettings(strin, saveFileDialog.FileName);
            }
        }
        private void OnSaveResults(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save settings in a tc file";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Tc output file|*.tcout";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                trans_calc_input_text strin = buildInput();
                trans_calc_result_text result = new trans_calc_result_text();
                result.length_m_1 = res_length_m_1.Text;
                result.length_ft_1 = res_length_ft_1.Text;
                result.buildup_mm_1 = res_thickness_mm_1.Text;
                result.R_1 = res_resistance_1.Text;
                result.N_1 = res_turns_1.Text;
                result.N_per_layer_1 = res_turns_per_layer_1.Text;
                result.totalLayers_1 = res_totalLayers_1.Text;
                result.lastLayerTurns_1 = res_lastLayerTurns_1.Text;
                result.mpath_l_m = res_mpath_m.Text;
                result.awg_max_current_amp_1 = res_max_current_1.Text;
                result.L_1 = res_L1.Text;
                result.B_max = res_Bmax.Text;
                result.H = res_H.Text;
                result.I_ex = res_Iex.Text;
                result.permeability = res_permeability.Text;
                result.weight_1 = res_weight_g1.Text;
                result.length_m_2 = res_length_m_2.Text;
                result.length_ft_2 = res_length_ft_2.Text;
                result.buildup_mm_2 = res_thickness_mm_2.Text;
                result.R_2 = res_resistance_2.Text;
                result.N_2 = res_turns_2.Text;
                result.N_per_layer_2 = res_turns_per_layer_2.Text;
                result.totalLayers_2 = res_totalLayers_2.Text;
                result.lastLayerTurns_2 = res_lastLayerTurns_2.Text;
                result.awg_max_current_amp_2 = res_max_current_2.Text;
                result.L_2 = res_L2.Text;
                result.Vout_idle = res_Vout_idle.Text;
                result.Vout_load = res_Vout_imax.Text;
                result.Iout_max = res_Iout.Text;
                result.total_thickness_mm = res_total_thickness_mm.Text;
                result.weight_2 = res_weight_g2.Text;
                result.turns_ratio = res_turns_ratio.Text;
                result.wire_csa_ratio = res_csa_ratio.Text;
                result.wire_total_weight = res_wire_total_mass.Text;
                result.wire_weight_ratio = res_wire_weight_ratio.Text;
                result.Ip_full_load = res_Ip_full_load.Text;
                result.power_VA = res_powerVA.Text;
                result.total_eq_R = res_total_eq_R.Text;
                result.regulation = res_regulation.Text;
                result.warnings = tc_warnings;
                tc.SaveResults(strin, result, saveFileDialog.FileName);
            }
        }
        private void Temp_OnCheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_tempC.Checked != tc.IsTempUnitsC)
            {
                if (edit_max_temp.Text != "")
                {
                    edit_max_temp.Text = tc.UpdateTempText(edit_max_temp.Text);
                }
                tc.IsTempUnitsC = radioButton_tempC.Checked;
                label_units_maxtemp.Text = tc.TempUnitsLabel + ":";
            }
        }

        private void SetResultUnits()
        {
            res_label_units_weight1.Text = tc.MassUnitsLabel + ":";
            res_label_units_weight2.Text = tc.MassUnitsLabel + ":";
            res_label_units_total_weight.Text = tc.MassUnitsLabel + ":";
            res_label_units_H.Text = tc.HUnitlsLabel;
        }

        private void Weight_OnCheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_weight_g.Checked != tc.IsMassUnits_g)
            {
                tc.IsMassUnits_g = radioButton_weight_g.Checked;
            }

        }

        private void H_OnCheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rb = sender as System.Windows.Forms.RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    if (radioButton_H_amp_t_m.Checked)
                    {
                        transCalc_H = tc.Convert_H(transCalc_H, TransCalc.H_UNITS.AMP_TURNS_M);
                    }
                    else if (radioButton_H_amp_t_in.Checked)
                    {
                        transCalc_H = tc.Convert_H(transCalc_H, TransCalc.H_UNITS.AMP_TURNS_IN);
                    }
                    else if (radioButton_H_oe.Checked)
                    {
                        transCalc_H = tc.Convert_H(transCalc_H, TransCalc.H_UNITS.OERSTEDS);
                    }
                    
                    label_units_H.Text = tc.HUnitlsLabel;

                    if (transCalc_H > 0.000000001)
                    {
                        edit_H.Text = String.Format("{0:0.##}", transCalc_H);
                    }
                }
            }
        }

        private void SetTranscalc_H(string sval)
        {
            try
            {
                if (edit_H.Text != "")
                {
                    transCalc_H = double.Parse(edit_H.Text, NumberStyles.Float);
                }
                else
                {
                    transCalc_H = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("H: " + ex.Message);
            }

        }

        private void H_OnLeave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Modified)
            {
                SetTranscalc_H(edit_H.Text);
            }
        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.DarkGray);
        }
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(Color.FromArgb (245, 245, 245));

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left + 5, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left + 5, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + 5 + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
    }
}
