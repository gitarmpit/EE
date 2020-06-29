using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
//            AcceptButton = button_bias;
            this.awgCombo.Items.AddRange(new AWG[] {
            new AWG("AWG 35", 0.14 ),
            new AWG("AWG 34", 0.16 ),
            new AWG("AWG 33", 0.18 ),
            new AWG("AWG 32", 0.20 ),
            new AWG("AWG 30", 0.25 ),
            new AWG("AWG 28", 0.33 ),
            new AWG("AWG 26", 0.41 ),
            new AWG("AWG 25", 0.46 ),
            new AWG("AWG 24", 0.51 ),
            new AWG("AWG 22", 0.64 ),
            new AWG("AWG 20", 0.81 ),
            new AWG("AWG 18", 1.02 ),
            new AWG("AWG 16", 1.29 ),
            new AWG("AWG 14", 1.63 ),
            new AWG("AWG 13", 1.83 ),
            new AWG("AWG 12", 2.05 ),
            new AWG("AWG 10", 2.59 )
            });

            this.awgCombo.SelectedIndex = 9;


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
        
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            try
            {
                TransCalc tc = new TransCalc();
                double d = ((AWG)awgCombo.SelectedItem).value;
                trans_calc_result res = tc.calculate(edit_Bmax.Text, d, edit_bobbinL.Text, edit_bobbinW.Text,
                    edit_bobbinH.Text, edit_Wfactor.Text, edit_N.Text, edit_coreW.Text, edit_coreH.Text,
                    edit_turnsPerLayer.Text);

                res_length_m.Text = res.res_length_m;
                res_length_ft.Text = res.res_length_ft;
                res_thickness_mms.Text = res.res_thickness_mms;
                res_resistivity.Text = res.res_resistivity;
                res_totalLayers.Text = res.res_totalLayers;
                res_lastLayerTurns.Text = res.res_lastLayerTurns;

                edit_turnsPerLayer.Text = res.edit_turnsPerLayer;
                edit_N.Text = res.edit_N;
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
            edit_coreH.Text = "";
            edit_coreW.Text = "";
            edit_N.Text = "";
            edit_Wfactor.Text = "";
            edit_turnsPerLayer.Text = "";
            res_lastLayerTurns.Text = "";
            res_length_ft.Text = "";
            res_length_m.Text = "";
            res_resistivity.Text = "";
            res_thickness_mms.Text = "";
            res_totalLayers.Text = "";

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


    }
}
