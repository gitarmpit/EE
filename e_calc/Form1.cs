using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace forms1
{
    public partial class Form1 : Form
    {
        Bias bias;
        public Form1()
        {
            InitializeComponent();
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<AWG> awgValues = new List<AWG>(); 
            awgValues.AddRange(new AWG[] {
            new AWG("AWG 35", 35, 0.14224),
            new AWG("AWG 34", 34, 0.16002 ),
            new AWG("AWG 33", 33, 0.18034 ),
            new AWG("AWG 32", 32, 0.2032 ),
            new AWG("AWG 30", 30, 0.254 ),
            new AWG("AWG 28", 28, 0.32004 ),
            new AWG("AWG 26", 26, 0.40386 ), 
            new AWG("AWG 25", 25, 0.45466 ),
            new AWG("AWG 24", 24, 0.51054 ),
            new AWG("AWG 22", 22, 0.64516 ),
            new AWG("AWG 20", 20, 0.8128 ),
            new AWG("AWG 18", 18, 1.02362 ),
            new AWG("AWG 16", 16, 1.29032 ),
            new AWG("AWG 14", 14, 1.62814 ),
            new AWG("AWG 13", 13, 1.8288  ),
            new AWG("AWG 12", 12, 2.05232 ),
            new AWG("AWG 10", 10, 2.58826 ),
            new AWG("AWG 8",  8, 3.2639 )
            });

            this.awgCombo1.Items.AddRange(awgValues.ToArray());
            this.awgCombo2.Items.AddRange(awgValues.ToArray());

            this.awgCombo1.SelectedIndex = 9;
            this.awgCombo2.SelectedIndex = 9;

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
                string[] values = csv.Split(',');
                if (values.Length == 10)
                {
                    edit_Bmax.Text = values[0];
                    edit_bobbinL.Text = values[1];
                    edit_bobbinW.Text = values[2];
                    edit_bobbinH.Text = values[3];
                    edit_coreH.Text = values[4];
                    edit_coreW.Text = values[5];

                    awgCombo1.SelectedItem = parseAWG(values[6]);
                    edit_Wfactor1.Text = values[7];

                    awgCombo2.SelectedItem = parseAWG(values[8]);
                    edit_Wfactor2.Text = values[9];
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

        private AWG parseAWG(string sawg)
        {
            var awg = awgCombo1.Items.Cast<AWG>().Where(a => a.name == sawg).FirstOrDefault();
            if (awg == null)
            {
                throw new Exception($"Error parsing AWG: {sawg}");
            }
            return awg;

        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            try
            {
                TransCalc tc = new TransCalc();
                double awg1 = ((AWG)awgCombo1.SelectedItem).value;
                double awg2 = ((AWG)awgCombo2.SelectedItem).value;

                trans_calc_input input = tc.convertToInput(edit_Bmax.Text,
                    edit_bobbinL.Text, edit_bobbinW.Text, edit_bobbinH.Text,
                    edit_coreH.Text, edit_coreW.Text,
                    awg1, edit_Wfactor1.Text, edit_N1.Text, edit_turnsPerLayer1.Text,
                    awg2, edit_Wfactor2.Text, edit_N2.Text, edit_turnsPerLayer2.Text);

                // Calculate primary
                trans_calc_result res1 = tc.calculate(input.common, input.primary);

                res_length_m_1.Text = String.Format("{0:0.##}", res1.res_length_m);
                res_length_ft_1.Text = String.Format("{0:0.##}", res1.res_length_ft);
                res_thickness_mm_1.Text = String.Format("{0:0.##}", res1.res_thickness_mms);
                res_resistance_1.Text = String.Format("{0:0.##}", res1.res_resistance);
                res_turns_1.Text = res1.res_N.ToString();
                res_turns_per_layer_1.Text = res1.res_N_per_layer.ToString();
                res_totalLayers_1.Text = res1.res_totalLayers.ToString();
                res_lastLayerTurns_1.Text = 
                    (res1.res_lastLayerTurns != 0) ? res1.res_lastLayerTurns.ToString() : "";

                //Calculate secondary if configured 
                if (!input.processSecondary)
                {
                    return;
                }

                input.common.H += res1.res_thickness_mms/1000;
                input.common.W += res1.res_thickness_mms/1000;
                trans_calc_result res2 = tc.calculate(input.common, input.secondary);

                res_length_m_2.Text = String.Format("{0:0.##}", res2.res_length_m);
                res_length_ft_2.Text = String.Format("{0:0.##}", res2.res_length_ft);
                res_thickness_mm_2.Text = String.Format("{0:0.##}", res2.res_thickness_mms);
                res_resistance_2.Text = String.Format("{0:0.##}", res2.res_resistance);
                res_turns_2.Text = res2.res_N.ToString();
                res_turns_per_layer_2.Text = res2.res_N_per_layer.ToString();
                res_totalLayers_2.Text = res2.res_totalLayers.ToString();
                res_lastLayerTurns_2.Text =
                    (res2.res_lastLayerTurns != 0) ? res2.res_lastLayerTurns.ToString() : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void transCalcTab_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = calcTab.TabPages[e.Index];
            //e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void clearButton_click(object sender, EventArgs e)
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void transCalcPage_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void edit_bobbinL_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {

        }
    }
}
