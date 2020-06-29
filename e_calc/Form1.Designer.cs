namespace forms1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        class AWG
        {
            public string name;
            public double value;
            public AWG(string name, double value)
            {
                this.name = name;
                this.value = value;
            }
            public override string ToString()
            {
                return name;
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.calcTab = new System.Windows.Forms.TabControl();
            this.transCalcPage = new System.Windows.Forms.TabPage();
            this.clearButton = new System.Windows.Forms.Button();
            this.calcButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.res_resistivity = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.res_thickness_mms = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.res_length_ft = new System.Windows.Forms.Label();
            this.res_length_m = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.res_lastLayerTurns = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.res_totalLayers = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.edit_turnsPerLayer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edit_N = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edit_coreH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edit_coreW = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edit_Wfactor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edit_bobbinH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edit_bobbinW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edit_bobbinL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.awgCombo = new System.Windows.Forms.ComboBox();
            this.biasPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_R = new System.Windows.Forms.RadioButton();
            this.radioButton_V = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.trackBar_R2 = new System.Windows.Forms.TrackBar();
            this.trackBar_R1 = new System.Windows.Forms.TrackBar();
            this.trackBar_Ve_Re = new System.Windows.Forms.TrackBar();
            this.trackBar_Vce_Rc = new System.Windows.Forms.TrackBar();
            this.trackBar_Ic = new System.Windows.Forms.TrackBar();
            this.trackBar_Vcc = new System.Windows.Forms.TrackBar();
            this.trackBar_Vbe = new System.Windows.Forms.TrackBar();
            this.trackBar_Beta = new System.Windows.Forms.TrackBar();
            this.label_Vce = new System.Windows.Forms.Label();
            this.label_Ve = new System.Windows.Forms.Label();
            this.label_Ir1 = new System.Windows.Forms.Label();
            this.label_Ir2 = new System.Windows.Forms.Label();
            this.label_Ib = new System.Windows.Forms.Label();
            this.button_bias = new System.Windows.Forms.Button();
            this.edit_R2 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.edit_R1 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.edit_Vce_Rc = new System.Windows.Forms.TextBox();
            this.label_Vce_Rc = new System.Windows.Forms.Label();
            this.edit_VeRe = new System.Windows.Forms.TextBox();
            this.label_VeRe = new System.Windows.Forms.Label();
            this.edit_Vbe = new System.Windows.Forms.TextBox();
            this.Vbe = new System.Windows.Forms.Label();
            this.edit_beta = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.edit_Ic = new System.Windows.Forms.TextBox();
            this.Ic = new System.Windows.Forms.Label();
            this.edit_Vcc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label_R4 = new System.Windows.Forms.Label();
            this.label_R3 = new System.Windows.Forms.Label();
            this.label_R2 = new System.Windows.Forms.Label();
            this.label_R1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.edit_Bmax = new System.Windows.Forms.TextBox();
            this.calcTab.SuspendLayout();
            this.transCalcPage.SuspendLayout();
            this.biasPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_R2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_R1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Ve_Re)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vce_Rc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Ic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Beta)).BeginInit();
            this.SuspendLayout();
            // 
            // calcTab
            // 
            this.calcTab.Controls.Add(this.transCalcPage);
            this.calcTab.Controls.Add(this.biasPage);
            this.calcTab.Location = new System.Drawing.Point(12, 12);
            this.calcTab.Name = "calcTab";
            this.calcTab.SelectedIndex = 0;
            this.calcTab.Size = new System.Drawing.Size(664, 411);
            this.calcTab.TabIndex = 0;
            this.calcTab.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.transCalcTab_DrawItem);
            // 
            // transCalcPage
            // 
            this.transCalcPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.transCalcPage.Controls.Add(this.edit_Bmax);
            this.transCalcPage.Controls.Add(this.label19);
            this.transCalcPage.Controls.Add(this.clearButton);
            this.transCalcPage.Controls.Add(this.calcButton);
            this.transCalcPage.Controls.Add(this.label16);
            this.transCalcPage.Controls.Add(this.res_resistivity);
            this.transCalcPage.Controls.Add(this.label14);
            this.transCalcPage.Controls.Add(this.res_thickness_mms);
            this.transCalcPage.Controls.Add(this.label15);
            this.transCalcPage.Controls.Add(this.res_length_ft);
            this.transCalcPage.Controls.Add(this.res_length_m);
            this.transCalcPage.Controls.Add(this.label12);
            this.transCalcPage.Controls.Add(this.res_lastLayerTurns);
            this.transCalcPage.Controls.Add(this.label13);
            this.transCalcPage.Controls.Add(this.res_totalLayers);
            this.transCalcPage.Controls.Add(this.label11);
            this.transCalcPage.Controls.Add(this.label10);
            this.transCalcPage.Controls.Add(this.edit_turnsPerLayer);
            this.transCalcPage.Controls.Add(this.label9);
            this.transCalcPage.Controls.Add(this.edit_N);
            this.transCalcPage.Controls.Add(this.label8);
            this.transCalcPage.Controls.Add(this.edit_coreH);
            this.transCalcPage.Controls.Add(this.label7);
            this.transCalcPage.Controls.Add(this.edit_coreW);
            this.transCalcPage.Controls.Add(this.label6);
            this.transCalcPage.Controls.Add(this.edit_Wfactor);
            this.transCalcPage.Controls.Add(this.label5);
            this.transCalcPage.Controls.Add(this.edit_bobbinH);
            this.transCalcPage.Controls.Add(this.label4);
            this.transCalcPage.Controls.Add(this.edit_bobbinW);
            this.transCalcPage.Controls.Add(this.label3);
            this.transCalcPage.Controls.Add(this.edit_bobbinL);
            this.transCalcPage.Controls.Add(this.label2);
            this.transCalcPage.Controls.Add(this.label1);
            this.transCalcPage.Controls.Add(this.awgCombo);
            this.transCalcPage.ForeColor = System.Drawing.Color.Black;
            this.transCalcPage.Location = new System.Drawing.Point(4, 22);
            this.transCalcPage.Name = "transCalcPage";
            this.transCalcPage.Padding = new System.Windows.Forms.Padding(3);
            this.transCalcPage.Size = new System.Drawing.Size(656, 385);
            this.transCalcPage.TabIndex = 0;
            this.transCalcPage.Text = "Trans Calc";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(331, 317);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(104, 23);
            this.clearButton.TabIndex = 60;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_click);
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(157, 317);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(121, 23);
            this.calcButton.TabIndex = 59;
            this.calcButton.Text = "Calculate";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(77, 308);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(485, 2);
            this.label16.TabIndex = 57;
            // 
            // res_resistivity
            // 
            this.res_resistivity.AutoSize = true;
            this.res_resistivity.Location = new System.Drawing.Point(414, 198);
            this.res_resistivity.Name = "res_resistivity";
            this.res_resistivity.Size = new System.Drawing.Size(10, 13);
            this.res_resistivity.TabIndex = 56;
            this.res_resistivity.Text = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(328, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Resistivity:";
            // 
            // res_thickness_mms
            // 
            this.res_thickness_mms.AutoSize = true;
            this.res_thickness_mms.Location = new System.Drawing.Point(414, 172);
            this.res_thickness_mms.Name = "res_thickness_mms";
            this.res_thickness_mms.Size = new System.Drawing.Size(10, 13);
            this.res_thickness_mms.TabIndex = 54;
            this.res_thickness_mms.Text = " ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(328, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "Thickness, mm:";
            // 
            // res_length_ft
            // 
            this.res_length_ft.AutoSize = true;
            this.res_length_ft.Location = new System.Drawing.Point(414, 146);
            this.res_length_ft.Name = "res_length_ft";
            this.res_length_ft.Size = new System.Drawing.Size(10, 13);
            this.res_length_ft.TabIndex = 52;
            this.res_length_ft.Text = " ";
            // 
            // res_length_m
            // 
            this.res_length_m.AutoSize = true;
            this.res_length_m.Location = new System.Drawing.Point(414, 120);
            this.res_length_m.Name = "res_length_m";
            this.res_length_m.Size = new System.Drawing.Size(10, 13);
            this.res_length_m.TabIndex = 50;
            this.res_length_m.Text = " ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(328, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Length, ft:";
            // 
            // res_lastLayerTurns
            // 
            this.res_lastLayerTurns.AutoSize = true;
            this.res_lastLayerTurns.Location = new System.Drawing.Point(414, 94);
            this.res_lastLayerTurns.Name = "res_lastLayerTurns";
            this.res_lastLayerTurns.Size = new System.Drawing.Size(10, 13);
            this.res_lastLayerTurns.TabIndex = 48;
            this.res_lastLayerTurns.Text = " ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(328, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "Length, m:";
            // 
            // res_totalLayers
            // 
            this.res_totalLayers.AutoSize = true;
            this.res_totalLayers.Location = new System.Drawing.Point(414, 67);
            this.res_totalLayers.Name = "res_totalLayers";
            this.res_totalLayers.Size = new System.Drawing.Size(10, 13);
            this.res_totalLayers.TabIndex = 46;
            this.res_totalLayers.Text = " ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Last layer turns:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Total layers:";
            // 
            // edit_turnsPerLayer
            // 
            this.edit_turnsPerLayer.Location = new System.Drawing.Point(157, 273);
            this.edit_turnsPerLayer.Name = "edit_turnsPerLayer";
            this.edit_turnsPerLayer.Size = new System.Drawing.Size(121, 20);
            this.edit_turnsPerLayer.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Turns per layer:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_N
            // 
            this.edit_N.Location = new System.Drawing.Point(157, 247);
            this.edit_N.Name = "edit_N";
            this.edit_N.Size = new System.Drawing.Size(121, 20);
            this.edit_N.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Turns:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_coreH
            // 
            this.edit_coreH.Location = new System.Drawing.Point(157, 221);
            this.edit_coreH.Name = "edit_coreH";
            this.edit_coreH.Size = new System.Drawing.Size(121, 20);
            this.edit_coreH.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Core H, cm:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_coreW
            // 
            this.edit_coreW.Location = new System.Drawing.Point(157, 195);
            this.edit_coreW.Name = "edit_coreW";
            this.edit_coreW.Size = new System.Drawing.Size(121, 20);
            this.edit_coreW.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Core W, cm:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_Wfactor
            // 
            this.edit_Wfactor.Location = new System.Drawing.Point(157, 169);
            this.edit_Wfactor.Name = "edit_Wfactor";
            this.edit_Wfactor.Size = new System.Drawing.Size(121, 20);
            this.edit_Wfactor.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "W factor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_bobbinH
            // 
            this.edit_bobbinH.Location = new System.Drawing.Point(157, 143);
            this.edit_bobbinH.Name = "edit_bobbinH";
            this.edit_bobbinH.Size = new System.Drawing.Size(121, 20);
            this.edit_bobbinH.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Bobbin H, cm:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_bobbinW
            // 
            this.edit_bobbinW.Location = new System.Drawing.Point(157, 117);
            this.edit_bobbinW.Name = "edit_bobbinW";
            this.edit_bobbinW.Size = new System.Drawing.Size(121, 20);
            this.edit_bobbinW.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Bobbin W, cm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_bobbinL
            // 
            this.edit_bobbinL.Location = new System.Drawing.Point(157, 91);
            this.edit_bobbinL.Name = "edit_bobbinL";
            this.edit_bobbinL.Size = new System.Drawing.Size(121, 20);
            this.edit_bobbinL.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Bobbin L, cm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "AWG:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // awgCombo
            // 
            this.awgCombo.FormattingEnabled = true;
            this.awgCombo.Location = new System.Drawing.Point(157, 64);
            this.awgCombo.Name = "awgCombo";
            this.awgCombo.Size = new System.Drawing.Size(121, 21);
            this.awgCombo.TabIndex = 27;
            // 
            // biasPage
            // 
            this.biasPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.biasPage.Controls.Add(this.groupBox1);
            this.biasPage.Controls.Add(this.label18);
            this.biasPage.Controls.Add(this.trackBar_R2);
            this.biasPage.Controls.Add(this.trackBar_R1);
            this.biasPage.Controls.Add(this.trackBar_Ve_Re);
            this.biasPage.Controls.Add(this.trackBar_Vce_Rc);
            this.biasPage.Controls.Add(this.trackBar_Ic);
            this.biasPage.Controls.Add(this.trackBar_Vcc);
            this.biasPage.Controls.Add(this.trackBar_Vbe);
            this.biasPage.Controls.Add(this.trackBar_Beta);
            this.biasPage.Controls.Add(this.label_Vce);
            this.biasPage.Controls.Add(this.label_Ve);
            this.biasPage.Controls.Add(this.label_Ir1);
            this.biasPage.Controls.Add(this.label_Ir2);
            this.biasPage.Controls.Add(this.label_Ib);
            this.biasPage.Controls.Add(this.button_bias);
            this.biasPage.Controls.Add(this.edit_R2);
            this.biasPage.Controls.Add(this.label26);
            this.biasPage.Controls.Add(this.edit_R1);
            this.biasPage.Controls.Add(this.label27);
            this.biasPage.Controls.Add(this.edit_Vce_Rc);
            this.biasPage.Controls.Add(this.label_Vce_Rc);
            this.biasPage.Controls.Add(this.edit_VeRe);
            this.biasPage.Controls.Add(this.label_VeRe);
            this.biasPage.Controls.Add(this.edit_Vbe);
            this.biasPage.Controls.Add(this.Vbe);
            this.biasPage.Controls.Add(this.edit_beta);
            this.biasPage.Controls.Add(this.label25);
            this.biasPage.Controls.Add(this.edit_Ic);
            this.biasPage.Controls.Add(this.Ic);
            this.biasPage.Controls.Add(this.edit_Vcc);
            this.biasPage.Controls.Add(this.label22);
            this.biasPage.Controls.Add(this.label_R4);
            this.biasPage.Controls.Add(this.label_R3);
            this.biasPage.Controls.Add(this.label_R2);
            this.biasPage.Controls.Add(this.label_R1);
            this.biasPage.Controls.Add(this.label17);
            this.biasPage.Location = new System.Drawing.Point(4, 22);
            this.biasPage.Name = "biasPage";
            this.biasPage.Padding = new System.Windows.Forms.Padding(3);
            this.biasPage.Size = new System.Drawing.Size(656, 385);
            this.biasPage.TabIndex = 1;
            this.biasPage.Text = "Bias";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_R);
            this.groupBox1.Controls.Add(this.radioButton_V);
            this.groupBox1.Location = new System.Drawing.Point(458, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(83, 32);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rc/Re";
            // 
            // radioButton_R
            // 
            this.radioButton_R.AutoSize = true;
            this.radioButton_R.Location = new System.Drawing.Point(47, 14);
            this.radioButton_R.Name = "radioButton_R";
            this.radioButton_R.Size = new System.Drawing.Size(33, 17);
            this.radioButton_R.TabIndex = 37;
            this.radioButton_R.TabStop = true;
            this.radioButton_R.Text = "R";
            this.radioButton_R.UseVisualStyleBackColor = true;
            this.radioButton_R.CheckedChanged += new System.EventHandler(this.radioButton_R_CheckedChanged);
            // 
            // radioButton_V
            // 
            this.radioButton_V.AutoSize = true;
            this.radioButton_V.Location = new System.Drawing.Point(9, 14);
            this.radioButton_V.Name = "radioButton_V";
            this.radioButton_V.Size = new System.Drawing.Size(32, 17);
            this.radioButton_V.TabIndex = 36;
            this.radioButton_V.TabStop = true;
            this.radioButton_V.Text = "V";
            this.radioButton_V.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(153, 127);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Vce = ";
            // 
            // trackBar_R2
            // 
            this.trackBar_R2.Location = new System.Drawing.Point(611, 89);
            this.trackBar_R2.Name = "trackBar_R2";
            this.trackBar_R2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_R2.Size = new System.Drawing.Size(45, 246);
            this.trackBar_R2.TabIndex = 34;
            this.trackBar_R2.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_R1
            // 
            this.trackBar_R1.Location = new System.Drawing.Point(560, 89);
            this.trackBar_R1.Name = "trackBar_R1";
            this.trackBar_R1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_R1.Size = new System.Drawing.Size(45, 246);
            this.trackBar_R1.TabIndex = 33;
            this.trackBar_R1.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Ve_Re
            // 
            this.trackBar_Ve_Re.Location = new System.Drawing.Point(511, 89);
            this.trackBar_Ve_Re.Name = "trackBar_Ve_Re";
            this.trackBar_Ve_Re.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Ve_Re.Size = new System.Drawing.Size(45, 246);
            this.trackBar_Ve_Re.TabIndex = 32;
            this.trackBar_Ve_Re.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Vce_Rc
            // 
            this.trackBar_Vce_Rc.Location = new System.Drawing.Point(461, 89);
            this.trackBar_Vce_Rc.Name = "trackBar_Vce_Rc";
            this.trackBar_Vce_Rc.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Vce_Rc.Size = new System.Drawing.Size(45, 246);
            this.trackBar_Vce_Rc.TabIndex = 31;
            this.trackBar_Vce_Rc.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Ic
            // 
            this.trackBar_Ic.Location = new System.Drawing.Point(411, 89);
            this.trackBar_Ic.Name = "trackBar_Ic";
            this.trackBar_Ic.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Ic.Size = new System.Drawing.Size(45, 246);
            this.trackBar_Ic.TabIndex = 30;
            this.trackBar_Ic.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Vcc
            // 
            this.trackBar_Vcc.Location = new System.Drawing.Point(361, 89);
            this.trackBar_Vcc.Name = "trackBar_Vcc";
            this.trackBar_Vcc.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Vcc.Size = new System.Drawing.Size(45, 246);
            this.trackBar_Vcc.TabIndex = 29;
            this.trackBar_Vcc.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Vbe
            // 
            this.trackBar_Vbe.Location = new System.Drawing.Point(311, 89);
            this.trackBar_Vbe.Name = "trackBar_Vbe";
            this.trackBar_Vbe.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Vbe.Size = new System.Drawing.Size(45, 246);
            this.trackBar_Vbe.TabIndex = 28;
            this.trackBar_Vbe.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Beta
            // 
            this.trackBar_Beta.Location = new System.Drawing.Point(261, 89);
            this.trackBar_Beta.Name = "trackBar_Beta";
            this.trackBar_Beta.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Beta.Size = new System.Drawing.Size(45, 246);
            this.trackBar_Beta.TabIndex = 27;
            this.trackBar_Beta.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label_Vce
            // 
            this.label_Vce.AutoSize = true;
            this.label_Vce.Location = new System.Drawing.Point(193, 127);
            this.label_Vce.Name = "label_Vce";
            this.label_Vce.Size = new System.Drawing.Size(26, 13);
            this.label_Vce.TabIndex = 26;
            this.label_Vce.Text = "Vce";
            // 
            // label_Ve
            // 
            this.label_Ve.AutoSize = true;
            this.label_Ve.Location = new System.Drawing.Point(193, 192);
            this.label_Ve.Name = "label_Ve";
            this.label_Ve.Size = new System.Drawing.Size(20, 13);
            this.label_Ve.TabIndex = 25;
            this.label_Ve.Text = "Ve";
            // 
            // label_Ir1
            // 
            this.label_Ir1.AutoSize = true;
            this.label_Ir1.Location = new System.Drawing.Point(20, 110);
            this.label_Ir1.Name = "label_Ir1";
            this.label_Ir1.Size = new System.Drawing.Size(19, 13);
            this.label_Ir1.TabIndex = 24;
            this.label_Ir1.Text = "Ir1";
            // 
            // label_Ir2
            // 
            this.label_Ir2.AutoSize = true;
            this.label_Ir2.Location = new System.Drawing.Point(20, 193);
            this.label_Ir2.Name = "label_Ir2";
            this.label_Ir2.Size = new System.Drawing.Size(19, 13);
            this.label_Ir2.TabIndex = 23;
            this.label_Ir2.Text = "Ir2";
            // 
            // label_Ib
            // 
            this.label_Ib.AutoSize = true;
            this.label_Ib.Location = new System.Drawing.Point(62, 135);
            this.label_Ib.Name = "label_Ib";
            this.label_Ib.Size = new System.Drawing.Size(16, 13);
            this.label_Ib.TabIndex = 22;
            this.label_Ib.Text = "Ib";
            // 
            // button_bias
            // 
            this.button_bias.Location = new System.Drawing.Point(261, 340);
            this.button_bias.Name = "button_bias";
            this.button_bias.Size = new System.Drawing.Size(100, 23);
            this.button_bias.TabIndex = 21;
            this.button_bias.Text = "Calculate";
            this.button_bias.UseVisualStyleBackColor = true;
            this.button_bias.Click += new System.EventHandler(this.buttion_bias_Click);
            // 
            // edit_R2
            // 
            this.edit_R2.Location = new System.Drawing.Point(611, 63);
            this.edit_R2.Name = "edit_R2";
            this.edit_R2.Size = new System.Drawing.Size(30, 20);
            this.edit_R2.TabIndex = 8;
            this.edit_R2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_R2.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(608, 47);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(21, 13);
            this.label26.TabIndex = 19;
            this.label26.Text = "R2";
            // 
            // edit_R1
            // 
            this.edit_R1.Location = new System.Drawing.Point(561, 63);
            this.edit_R1.Name = "edit_R1";
            this.edit_R1.Size = new System.Drawing.Size(30, 20);
            this.edit_R1.TabIndex = 7;
            this.edit_R1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_R1.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(561, 47);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(21, 13);
            this.label27.TabIndex = 17;
            this.label27.Text = "R1";
            // 
            // edit_Vce_Rc
            // 
            this.edit_Vce_Rc.Location = new System.Drawing.Point(461, 63);
            this.edit_Vce_Rc.Name = "edit_Vce_Rc";
            this.edit_Vce_Rc.Size = new System.Drawing.Size(30, 20);
            this.edit_Vce_Rc.TabIndex = 5;
            this.edit_Vce_Rc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Vce_Rc.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label_Vce_Rc
            // 
            this.label_Vce_Rc.AutoSize = true;
            this.label_Vce_Rc.Location = new System.Drawing.Point(455, 47);
            this.label_Vce_Rc.Name = "label_Vce_Rc";
            this.label_Vce_Rc.Size = new System.Drawing.Size(45, 13);
            this.label_Vce_Rc.TabIndex = 15;
            this.label_Vce_Rc.Text = "Vce/Rc";
            // 
            // edit_VeRe
            // 
            this.edit_VeRe.Location = new System.Drawing.Point(511, 63);
            this.edit_VeRe.Name = "edit_VeRe";
            this.edit_VeRe.Size = new System.Drawing.Size(30, 20);
            this.edit_VeRe.TabIndex = 6;
            this.edit_VeRe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_VeRe.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label_VeRe
            // 
            this.label_VeRe.AutoSize = true;
            this.label_VeRe.Location = new System.Drawing.Point(510, 47);
            this.label_VeRe.Name = "label_VeRe";
            this.label_VeRe.Size = new System.Drawing.Size(39, 13);
            this.label_VeRe.TabIndex = 13;
            this.label_VeRe.Text = "Ve/Re";
            // 
            // edit_Vbe
            // 
            this.edit_Vbe.Location = new System.Drawing.Point(311, 63);
            this.edit_Vbe.Name = "edit_Vbe";
            this.edit_Vbe.Size = new System.Drawing.Size(30, 20);
            this.edit_Vbe.TabIndex = 2;
            this.edit_Vbe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Vbe.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // Vbe
            // 
            this.Vbe.AutoSize = true;
            this.Vbe.Location = new System.Drawing.Point(315, 47);
            this.Vbe.Name = "Vbe";
            this.Vbe.Size = new System.Drawing.Size(26, 13);
            this.Vbe.TabIndex = 1;
            this.Vbe.Text = "Vbe";
            // 
            // edit_beta
            // 
            this.edit_beta.Location = new System.Drawing.Point(261, 62);
            this.edit_beta.Name = "edit_beta";
            this.edit_beta.Size = new System.Drawing.Size(30, 20);
            this.edit_beta.TabIndex = 1;
            this.edit_beta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_beta.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(262, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "Beta";
            // 
            // edit_Ic
            // 
            this.edit_Ic.Location = new System.Drawing.Point(411, 63);
            this.edit_Ic.Name = "edit_Ic";
            this.edit_Ic.Size = new System.Drawing.Size(30, 20);
            this.edit_Ic.TabIndex = 4;
            this.edit_Ic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Ic.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // Ic
            // 
            this.Ic.AutoSize = true;
            this.Ic.Location = new System.Drawing.Point(412, 47);
            this.Ic.Name = "Ic";
            this.Ic.Size = new System.Drawing.Size(37, 13);
            this.Ic.TabIndex = 7;
            this.Ic.Text = "Ic, mA";
            // 
            // edit_Vcc
            // 
            this.edit_Vcc.Location = new System.Drawing.Point(361, 63);
            this.edit_Vcc.Name = "edit_Vcc";
            this.edit_Vcc.Size = new System.Drawing.Size(30, 20);
            this.edit_Vcc.TabIndex = 3;
            this.edit_Vcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Vcc.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(362, 47);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 5;
            this.label22.Text = "Vcc";
            // 
            // label_R4
            // 
            this.label_R4.AutoSize = true;
            this.label_R4.Location = new System.Drawing.Point(198, 259);
            this.label_R4.Name = "label_R4";
            this.label_R4.Size = new System.Drawing.Size(21, 13);
            this.label_R4.TabIndex = 4;
            this.label_R4.Text = "R4";
            // 
            // label_R3
            // 
            this.label_R3.AutoSize = true;
            this.label_R3.Location = new System.Drawing.Point(198, 64);
            this.label_R3.Name = "label_R3";
            this.label_R3.Size = new System.Drawing.Size(21, 13);
            this.label_R3.TabIndex = 3;
            this.label_R3.Text = "R3";
            // 
            // label_R2
            // 
            this.label_R2.AutoSize = true;
            this.label_R2.Location = new System.Drawing.Point(82, 259);
            this.label_R2.Name = "label_R2";
            this.label_R2.Size = new System.Drawing.Size(21, 13);
            this.label_R2.TabIndex = 2;
            this.label_R2.Text = "R2";
            // 
            // label_R1
            // 
            this.label_R1.AutoSize = true;
            this.label_R1.Location = new System.Drawing.Point(82, 64);
            this.label_R1.Name = "label_R1";
            this.label_R1.Size = new System.Drawing.Size(21, 13);
            this.label_R1.TabIndex = 1;
            this.label_R1.Text = "R1";
            // 
            // label17
            // 
            this.label17.Image = ((System.Drawing.Image)(resources.GetObject("label17.Image")));
            this.label17.Location = new System.Drawing.Point(20, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(228, 307);
            this.label17.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(75, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "Bmax:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // edit_Bmax
            // 
            this.edit_Bmax.Location = new System.Drawing.Point(157, 38);
            this.edit_Bmax.Name = "edit_Bmax";
            this.edit_Bmax.Size = new System.Drawing.Size(121, 20);
            this.edit_Bmax.TabIndex = 62;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(688, 435);
            this.Controls.Add(this.calcTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "EE Calculators";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.calcTab.ResumeLayout(false);
            this.transCalcPage.ResumeLayout(false);
            this.transCalcPage.PerformLayout();
            this.biasPage.ResumeLayout(false);
            this.biasPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_R2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_R1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Ve_Re)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vce_Rc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Ic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Beta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl calcTab;
        private System.Windows.Forms.TabPage transCalcPage;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label res_resistivity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label res_thickness_mms;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label res_length_ft;
        private System.Windows.Forms.Label res_length_m;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label res_lastLayerTurns;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label res_totalLayers;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edit_turnsPerLayer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edit_N;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edit_coreH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edit_coreW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edit_Wfactor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edit_bobbinH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edit_bobbinW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edit_bobbinL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox awgCombo;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TabPage biasPage;
        private System.Windows.Forms.Button button_bias;
        private System.Windows.Forms.TextBox edit_R2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox edit_R1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox edit_Vce_Rc;
        private System.Windows.Forms.Label label_Vce_Rc;
        private System.Windows.Forms.TextBox edit_VeRe;
        private System.Windows.Forms.Label label_VeRe;
        private System.Windows.Forms.TextBox edit_Vbe;
        private System.Windows.Forms.Label Vbe;
        private System.Windows.Forms.TextBox edit_beta;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox edit_Ic;
        private System.Windows.Forms.Label Ic;
        private System.Windows.Forms.TextBox edit_Vcc;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label_R4;
        private System.Windows.Forms.Label label_R3;
        private System.Windows.Forms.Label label_R2;
        private System.Windows.Forms.Label label_R1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label_Ib;
        private System.Windows.Forms.Label label_Ir2;
        private System.Windows.Forms.Label label_Ir1;
        private System.Windows.Forms.Label label_Ve;
        private System.Windows.Forms.Label label_Vce;
        private System.Windows.Forms.TrackBar trackBar_Vbe;
        private System.Windows.Forms.TrackBar trackBar_Beta;
        private System.Windows.Forms.TrackBar trackBar_Ic;
        private System.Windows.Forms.TrackBar trackBar_Vcc;
        private System.Windows.Forms.TrackBar trackBar_R2;
        private System.Windows.Forms.TrackBar trackBar_R1;
        private System.Windows.Forms.TrackBar trackBar_Ve_Re;
        private System.Windows.Forms.TrackBar trackBar_Vce_Rc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_R;
        private System.Windows.Forms.RadioButton radioButton_V;
        private System.Windows.Forms.TextBox edit_Bmax;
        private System.Windows.Forms.Label label19;

    }
}

