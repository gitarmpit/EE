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
            public int number;
            public string name;
            public double value;
            public AWG(string name, int number, double value)
            {
                this.name = name;
                this.number = number;
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
            this.res_turns_per_layer_2 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.res_turns_per_layer_1 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.res_turns_2 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.res_turns_1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.res_resistance_2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.res_thickness_mm_2 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.res_length_ft_2 = new System.Windows.Forms.Label();
            this.res_length_m_2 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.res_lastLayerTurns_2 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.res_totalLayers_2 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.edit_turnsPerLayer2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.edit_N2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.edit_Wfactor2 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.awgCombo2 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.edit_Bmax = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.calcButton = new System.Windows.Forms.Button();
            this.res_resistance_1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.res_thickness_mm_1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.res_length_ft_1 = new System.Windows.Forms.Label();
            this.res_length_m_1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.res_lastLayerTurns_1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.res_totalLayers_1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.edit_turnsPerLayer1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edit_N1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edit_coreW = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edit_coreH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edit_Wfactor1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edit_bobbinH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edit_bobbinW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edit_bobbinL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.awgCombo1 = new System.Windows.Forms.ComboBox();
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
            this.label33 = new System.Windows.Forms.Label();
            this.v_in = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.v_out = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.edit_mpath_W = new System.Windows.Forms.TextBox();
            this.edit_mpath_H = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.res_L1 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.edit_permeability = new System.Windows.Forms.TextBox();
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
            this.calcTab.Location = new System.Drawing.Point(18, 18);
            this.calcTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calcTab.Name = "calcTab";
            this.calcTab.SelectedIndex = 0;
            this.calcTab.Size = new System.Drawing.Size(1227, 686);
            this.calcTab.TabIndex = 0;
            this.calcTab.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.transCalcTab_DrawItem);
            // 
            // transCalcPage
            // 
            this.transCalcPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.transCalcPage.Controls.Add(this.edit_permeability);
            this.transCalcPage.Controls.Add(this.label45);
            this.transCalcPage.Controls.Add(this.res_L1);
            this.transCalcPage.Controls.Add(this.label44);
            this.transCalcPage.Controls.Add(this.edit_mpath_H);
            this.transCalcPage.Controls.Add(this.edit_mpath_W);
            this.transCalcPage.Controls.Add(this.label43);
            this.transCalcPage.Controls.Add(this.v_out);
            this.transCalcPage.Controls.Add(this.label36);
            this.transCalcPage.Controls.Add(this.v_in);
            this.transCalcPage.Controls.Add(this.label33);
            this.transCalcPage.Controls.Add(this.res_turns_per_layer_2);
            this.transCalcPage.Controls.Add(this.label34);
            this.transCalcPage.Controls.Add(this.res_turns_per_layer_1);
            this.transCalcPage.Controls.Add(this.label38);
            this.transCalcPage.Controls.Add(this.res_turns_2);
            this.transCalcPage.Controls.Add(this.label31);
            this.transCalcPage.Controls.Add(this.res_turns_1);
            this.transCalcPage.Controls.Add(this.label16);
            this.transCalcPage.Controls.Add(this.Save);
            this.transCalcPage.Controls.Add(this.label42);
            this.transCalcPage.Controls.Add(this.label41);
            this.transCalcPage.Controls.Add(this.res_resistance_2);
            this.transCalcPage.Controls.Add(this.label30);
            this.transCalcPage.Controls.Add(this.res_thickness_mm_2);
            this.transCalcPage.Controls.Add(this.label32);
            this.transCalcPage.Controls.Add(this.res_length_ft_2);
            this.transCalcPage.Controls.Add(this.res_length_m_2);
            this.transCalcPage.Controls.Add(this.label35);
            this.transCalcPage.Controls.Add(this.res_lastLayerTurns_2);
            this.transCalcPage.Controls.Add(this.label37);
            this.transCalcPage.Controls.Add(this.res_totalLayers_2);
            this.transCalcPage.Controls.Add(this.label39);
            this.transCalcPage.Controls.Add(this.label40);
            this.transCalcPage.Controls.Add(this.edit_turnsPerLayer2);
            this.transCalcPage.Controls.Add(this.label23);
            this.transCalcPage.Controls.Add(this.edit_N2);
            this.transCalcPage.Controls.Add(this.label24);
            this.transCalcPage.Controls.Add(this.edit_Wfactor2);
            this.transCalcPage.Controls.Add(this.label28);
            this.transCalcPage.Controls.Add(this.label29);
            this.transCalcPage.Controls.Add(this.awgCombo2);
            this.transCalcPage.Controls.Add(this.label21);
            this.transCalcPage.Controls.Add(this.label20);
            this.transCalcPage.Controls.Add(this.edit_Bmax);
            this.transCalcPage.Controls.Add(this.label19);
            this.transCalcPage.Controls.Add(this.clearButton);
            this.transCalcPage.Controls.Add(this.calcButton);
            this.transCalcPage.Controls.Add(this.res_resistance_1);
            this.transCalcPage.Controls.Add(this.label14);
            this.transCalcPage.Controls.Add(this.res_thickness_mm_1);
            this.transCalcPage.Controls.Add(this.label15);
            this.transCalcPage.Controls.Add(this.res_length_ft_1);
            this.transCalcPage.Controls.Add(this.res_length_m_1);
            this.transCalcPage.Controls.Add(this.label12);
            this.transCalcPage.Controls.Add(this.res_lastLayerTurns_1);
            this.transCalcPage.Controls.Add(this.label13);
            this.transCalcPage.Controls.Add(this.res_totalLayers_1);
            this.transCalcPage.Controls.Add(this.label11);
            this.transCalcPage.Controls.Add(this.label10);
            this.transCalcPage.Controls.Add(this.edit_turnsPerLayer1);
            this.transCalcPage.Controls.Add(this.label9);
            this.transCalcPage.Controls.Add(this.edit_N1);
            this.transCalcPage.Controls.Add(this.label8);
            this.transCalcPage.Controls.Add(this.edit_coreW);
            this.transCalcPage.Controls.Add(this.label7);
            this.transCalcPage.Controls.Add(this.edit_coreH);
            this.transCalcPage.Controls.Add(this.label6);
            this.transCalcPage.Controls.Add(this.edit_Wfactor1);
            this.transCalcPage.Controls.Add(this.label5);
            this.transCalcPage.Controls.Add(this.edit_bobbinH);
            this.transCalcPage.Controls.Add(this.label4);
            this.transCalcPage.Controls.Add(this.edit_bobbinW);
            this.transCalcPage.Controls.Add(this.label3);
            this.transCalcPage.Controls.Add(this.edit_bobbinL);
            this.transCalcPage.Controls.Add(this.label2);
            this.transCalcPage.Controls.Add(this.label1);
            this.transCalcPage.Controls.Add(this.awgCombo1);
            this.transCalcPage.ForeColor = System.Drawing.Color.Black;
            this.transCalcPage.Location = new System.Drawing.Point(4, 29);
            this.transCalcPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transCalcPage.Name = "transCalcPage";
            this.transCalcPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transCalcPage.Size = new System.Drawing.Size(1219, 653);
            this.transCalcPage.TabIndex = 0;
            this.transCalcPage.Text = "Trans Calc";
            this.transCalcPage.Click += new System.EventHandler(this.transCalcPage_Click);
            // 
            // res_turns_per_layer_2
            // 
            this.res_turns_per_layer_2.AutoSize = true;
            this.res_turns_per_layer_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_turns_per_layer_2.Location = new System.Drawing.Point(991, 291);
            this.res_turns_per_layer_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_turns_per_layer_2.Name = "res_turns_per_layer_2";
            this.res_turns_per_layer_2.Size = new System.Drawing.Size(15, 22);
            this.res_turns_per_layer_2.TabIndex = 135;
            this.res_turns_per_layer_2.Text = " ";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(865, 293);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(117, 20);
            this.label34.TabIndex = 133;
            this.label34.Text = "Turns per layer:";
            // 
            // res_turns_per_layer_1
            // 
            this.res_turns_per_layer_1.AutoSize = true;
            this.res_turns_per_layer_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_turns_per_layer_1.Location = new System.Drawing.Point(768, 318);
            this.res_turns_per_layer_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_turns_per_layer_1.Name = "res_turns_per_layer_1";
            this.res_turns_per_layer_1.Size = new System.Drawing.Size(15, 22);
            this.res_turns_per_layer_1.TabIndex = 136;
            this.res_turns_per_layer_1.Text = " ";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(644, 320);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(117, 20);
            this.label38.TabIndex = 134;
            this.label38.Text = "Turns per layer:";
            // 
            // res_turns_2
            // 
            this.res_turns_2.AutoSize = true;
            this.res_turns_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_turns_2.Location = new System.Drawing.Point(992, 271);
            this.res_turns_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_turns_2.Name = "res_turns_2";
            this.res_turns_2.Size = new System.Drawing.Size(15, 22);
            this.res_turns_2.TabIndex = 132;
            this.res_turns_2.Text = " ";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(866, 273);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 20);
            this.label31.TabIndex = 131;
            this.label31.Text = "Turns:";
            // 
            // res_turns_1
            // 
            this.res_turns_1.AutoSize = true;
            this.res_turns_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_turns_1.Location = new System.Drawing.Point(768, 285);
            this.res_turns_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_turns_1.Name = "res_turns_1";
            this.res_turns_1.Size = new System.Drawing.Size(15, 22);
            this.res_turns_1.TabIndex = 132;
            this.res_turns_1.Text = " ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(644, 285);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 20);
            this.label16.TabIndex = 131;
            this.label16.Text = "Turns:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(416, 575);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(182, 35);
            this.Save.TabIndex = 117;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.save_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(863, 253);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(140, 20);
            this.label42.TabIndex = 130;
            this.label42.Text = "Secondary results:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(641, 258);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(116, 20);
            this.label41.TabIndex = 129;
            this.label41.Text = "Primary results:";
            // 
            // res_resistance_2
            // 
            this.res_resistance_2.AutoSize = true;
            this.res_resistance_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_resistance_2.Location = new System.Drawing.Point(991, 458);
            this.res_resistance_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_resistance_2.Name = "res_resistance_2";
            this.res_resistance_2.Size = new System.Drawing.Size(15, 22);
            this.res_resistance_2.TabIndex = 128;
            this.res_resistance_2.Text = " ";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(863, 458);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(93, 20);
            this.label30.TabIndex = 127;
            this.label30.Text = "Resistance:";
            // 
            // res_thickness_mm_2
            // 
            this.res_thickness_mm_2.AutoSize = true;
            this.res_thickness_mm_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_thickness_mm_2.Location = new System.Drawing.Point(991, 430);
            this.res_thickness_mm_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_thickness_mm_2.Name = "res_thickness_mm_2";
            this.res_thickness_mm_2.Size = new System.Drawing.Size(15, 22);
            this.res_thickness_mm_2.TabIndex = 126;
            this.res_thickness_mm_2.Text = " ";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(863, 430);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(118, 20);
            this.label32.TabIndex = 125;
            this.label32.Text = "Thickness, mm:";
            // 
            // res_length_ft_2
            // 
            this.res_length_ft_2.AutoSize = true;
            this.res_length_ft_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_length_ft_2.Location = new System.Drawing.Point(994, 405);
            this.res_length_ft_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_length_ft_2.Name = "res_length_ft_2";
            this.res_length_ft_2.Size = new System.Drawing.Size(15, 22);
            this.res_length_ft_2.TabIndex = 124;
            this.res_length_ft_2.Text = " ";
            // 
            // res_length_m_2
            // 
            this.res_length_m_2.AutoSize = true;
            this.res_length_m_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_length_m_2.Location = new System.Drawing.Point(992, 371);
            this.res_length_m_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_length_m_2.Name = "res_length_m_2";
            this.res_length_m_2.Size = new System.Drawing.Size(15, 22);
            this.res_length_m_2.TabIndex = 122;
            this.res_length_m_2.Text = " ";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(866, 403);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 20);
            this.label35.TabIndex = 123;
            this.label35.Text = "Length, ft:";
            // 
            // res_lastLayerTurns_2
            // 
            this.res_lastLayerTurns_2.AutoSize = true;
            this.res_lastLayerTurns_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_lastLayerTurns_2.Location = new System.Drawing.Point(992, 342);
            this.res_lastLayerTurns_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_lastLayerTurns_2.Name = "res_lastLayerTurns_2";
            this.res_lastLayerTurns_2.Size = new System.Drawing.Size(15, 22);
            this.res_lastLayerTurns_2.TabIndex = 120;
            this.res_lastLayerTurns_2.Text = " ";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(866, 371);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 20);
            this.label37.TabIndex = 121;
            this.label37.Text = "Length, m:";
            // 
            // res_totalLayers_2
            // 
            this.res_totalLayers_2.AutoSize = true;
            this.res_totalLayers_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_totalLayers_2.Location = new System.Drawing.Point(994, 320);
            this.res_totalLayers_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_totalLayers_2.Name = "res_totalLayers_2";
            this.res_totalLayers_2.Size = new System.Drawing.Size(15, 22);
            this.res_totalLayers_2.TabIndex = 118;
            this.res_totalLayers_2.Text = " ";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(866, 340);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(121, 20);
            this.label39.TabIndex = 119;
            this.label39.Text = "Last layer turns:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(866, 320);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(93, 20);
            this.label40.TabIndex = 117;
            this.label40.Text = "Total layers:";
            // 
            // edit_turnsPerLayer2
            // 
            this.edit_turnsPerLayer2.Location = new System.Drawing.Point(893, 173);
            this.edit_turnsPerLayer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_turnsPerLayer2.Name = "edit_turnsPerLayer2";
            this.edit_turnsPerLayer2.Size = new System.Drawing.Size(180, 26);
            this.edit_turnsPerLayer2.TabIndex = 114;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(778, 177);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(117, 20);
            this.label23.TabIndex = 71;
            this.label23.Text = "Turns per layer:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_N2
            // 
            this.edit_N2.Location = new System.Drawing.Point(893, 133);
            this.edit_N2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_N2.Name = "edit_N2";
            this.edit_N2.Size = new System.Drawing.Size(180, 26);
            this.edit_N2.TabIndex = 113;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(778, 137);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 20);
            this.label24.TabIndex = 69;
            this.label24.Text = "Turns:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_Wfactor2
            // 
            this.edit_Wfactor2.Location = new System.Drawing.Point(893, 93);
            this.edit_Wfactor2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Wfactor2.Name = "edit_Wfactor2";
            this.edit_Wfactor2.Size = new System.Drawing.Size(180, 26);
            this.edit_Wfactor2.TabIndex = 112;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(778, 97);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 20);
            this.label28.TabIndex = 67;
            this.label28.Text = "W factor:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(778, 55);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(52, 20);
            this.label29.TabIndex = 66;
            this.label29.Text = "AWG:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // awgCombo2
            // 
            this.awgCombo2.FormattingEnabled = true;
            this.awgCombo2.Location = new System.Drawing.Point(893, 53);
            this.awgCombo2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.awgCombo2.Name = "awgCombo2";
            this.awgCombo2.Size = new System.Drawing.Size(180, 28);
            this.awgCombo2.TabIndex = 111;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(778, 13);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 20);
            this.label21.TabIndex = 64;
            this.label21.Text = "Secondary:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(395, 13);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 20);
            this.label20.TabIndex = 63;
            this.label20.Text = "Primary:";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // edit_Bmax
            // 
            this.edit_Bmax.Location = new System.Drawing.Point(139, 10);
            this.edit_Bmax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Bmax.Name = "edit_Bmax";
            this.edit_Bmax.Size = new System.Drawing.Size(180, 26);
            this.edit_Bmax.TabIndex = 101;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 16);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 20);
            this.label19.TabIndex = 61;
            this.label19.Text = "Bmax:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(418, 515);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(182, 35);
            this.clearButton.TabIndex = 116;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_click);
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(418, 458);
            this.calcButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(182, 35);
            this.calcButton.TabIndex = 115;
            this.calcButton.Text = "Calculate";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // res_resistance_1
            // 
            this.res_resistance_1.AutoSize = true;
            this.res_resistance_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_resistance_1.Location = new System.Drawing.Point(769, 489);
            this.res_resistance_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_resistance_1.Name = "res_resistance_1";
            this.res_resistance_1.Size = new System.Drawing.Size(15, 22);
            this.res_resistance_1.TabIndex = 56;
            this.res_resistance_1.Text = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(643, 489);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 20);
            this.label14.TabIndex = 55;
            this.label14.Text = "Resistance:";
            // 
            // res_thickness_mm_1
            // 
            this.res_thickness_mm_1.AutoSize = true;
            this.res_thickness_mm_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_thickness_mm_1.Location = new System.Drawing.Point(769, 458);
            this.res_thickness_mm_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_thickness_mm_1.Name = "res_thickness_mm_1";
            this.res_thickness_mm_1.Size = new System.Drawing.Size(15, 22);
            this.res_thickness_mm_1.TabIndex = 54;
            this.res_thickness_mm_1.Text = " ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(643, 458);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 20);
            this.label15.TabIndex = 53;
            this.label15.Text = "Thickness, mm:";
            // 
            // res_length_ft_1
            // 
            this.res_length_ft_1.AutoSize = true;
            this.res_length_ft_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_length_ft_1.Location = new System.Drawing.Point(768, 428);
            this.res_length_ft_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_length_ft_1.Name = "res_length_ft_1";
            this.res_length_ft_1.Size = new System.Drawing.Size(15, 22);
            this.res_length_ft_1.TabIndex = 52;
            this.res_length_ft_1.Text = " ";
            // 
            // res_length_m_1
            // 
            this.res_length_m_1.AutoSize = true;
            this.res_length_m_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_length_m_1.Location = new System.Drawing.Point(770, 403);
            this.res_length_m_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_length_m_1.Name = "res_length_m_1";
            this.res_length_m_1.Size = new System.Drawing.Size(15, 22);
            this.res_length_m_1.TabIndex = 50;
            this.res_length_m_1.Text = " ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(642, 428);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "Length, ft:";
            // 
            // res_lastLayerTurns_1
            // 
            this.res_lastLayerTurns_1.AutoSize = true;
            this.res_lastLayerTurns_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_lastLayerTurns_1.Location = new System.Drawing.Point(771, 381);
            this.res_lastLayerTurns_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_lastLayerTurns_1.Name = "res_lastLayerTurns_1";
            this.res_lastLayerTurns_1.Size = new System.Drawing.Size(15, 22);
            this.res_lastLayerTurns_1.TabIndex = 48;
            this.res_lastLayerTurns_1.Text = " ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(641, 403);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 49;
            this.label13.Text = "Length, m:";
            // 
            // res_totalLayers_1
            // 
            this.res_totalLayers_1.AutoSize = true;
            this.res_totalLayers_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_totalLayers_1.Location = new System.Drawing.Point(770, 349);
            this.res_totalLayers_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_totalLayers_1.Name = "res_totalLayers_1";
            this.res_totalLayers_1.Size = new System.Drawing.Size(15, 22);
            this.res_totalLayers_1.TabIndex = 46;
            this.res_totalLayers_1.Text = " ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(642, 383);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 20);
            this.label11.TabIndex = 47;
            this.label11.Text = "Last layer turns:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(644, 349);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Total layers:";
            // 
            // edit_turnsPerLayer1
            // 
            this.edit_turnsPerLayer1.Location = new System.Drawing.Point(509, 170);
            this.edit_turnsPerLayer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_turnsPerLayer1.Name = "edit_turnsPerLayer1";
            this.edit_turnsPerLayer1.Size = new System.Drawing.Size(180, 26);
            this.edit_turnsPerLayer1.TabIndex = 110;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(395, 176);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "Turns per layer:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_N1
            // 
            this.edit_N1.Location = new System.Drawing.Point(509, 130);
            this.edit_N1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_N1.Name = "edit_N1";
            this.edit_N1.Size = new System.Drawing.Size(180, 26);
            this.edit_N1.TabIndex = 109;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Turns:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_coreW
            // 
            this.edit_coreW.Location = new System.Drawing.Point(139, 170);
            this.edit_coreW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_coreW.Name = "edit_coreW";
            this.edit_coreW.Size = new System.Drawing.Size(180, 26);
            this.edit_coreW.TabIndex = 106;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 173);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Core W, cm:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_coreH
            // 
            this.edit_coreH.Location = new System.Drawing.Point(139, 208);
            this.edit_coreH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_coreH.Name = "edit_coreH";
            this.edit_coreH.Size = new System.Drawing.Size(180, 26);
            this.edit_coreH.TabIndex = 105;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Core H, cm:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_Wfactor1
            // 
            this.edit_Wfactor1.Location = new System.Drawing.Point(509, 90);
            this.edit_Wfactor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Wfactor1.Name = "edit_Wfactor1";
            this.edit_Wfactor1.Size = new System.Drawing.Size(180, 26);
            this.edit_Wfactor1.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "W factor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_bobbinH
            // 
            this.edit_bobbinH.Location = new System.Drawing.Point(139, 132);
            this.edit_bobbinH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_bobbinH.Name = "edit_bobbinH";
            this.edit_bobbinH.Size = new System.Drawing.Size(180, 26);
            this.edit_bobbinH.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Bobbin H, cm:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_bobbinW
            // 
            this.edit_bobbinW.Location = new System.Drawing.Point(139, 92);
            this.edit_bobbinW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_bobbinW.Name = "edit_bobbinW";
            this.edit_bobbinW.Size = new System.Drawing.Size(180, 26);
            this.edit_bobbinW.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Bobbin W, cm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_bobbinL
            // 
            this.edit_bobbinL.Location = new System.Drawing.Point(139, 52);
            this.edit_bobbinL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_bobbinL.Name = "edit_bobbinL";
            this.edit_bobbinL.Size = new System.Drawing.Size(180, 26);
            this.edit_bobbinL.TabIndex = 102;
            this.edit_bobbinL.TextChanged += new System.EventHandler(this.edit_bobbinL_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Bobbin L, cm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "AWG:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // awgCombo1
            // 
            this.awgCombo1.FormattingEnabled = true;
            this.awgCombo1.Location = new System.Drawing.Point(509, 50);
            this.awgCombo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.awgCombo1.Name = "awgCombo1";
            this.awgCombo1.Size = new System.Drawing.Size(180, 28);
            this.awgCombo1.TabIndex = 107;
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
            this.biasPage.Location = new System.Drawing.Point(4, 29);
            this.biasPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.biasPage.Name = "biasPage";
            this.biasPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.biasPage.Size = new System.Drawing.Size(1219, 653);
            this.biasPage.TabIndex = 1;
            this.biasPage.Text = "Bias";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_R);
            this.groupBox1.Controls.Add(this.radioButton_V);
            this.groupBox1.Location = new System.Drawing.Point(687, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(124, 49);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rc/Re";
            // 
            // radioButton_R
            // 
            this.radioButton_R.AutoSize = true;
            this.radioButton_R.Location = new System.Drawing.Point(70, 22);
            this.radioButton_R.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_R.Name = "radioButton_R";
            this.radioButton_R.Size = new System.Drawing.Size(46, 24);
            this.radioButton_R.TabIndex = 37;
            this.radioButton_R.TabStop = true;
            this.radioButton_R.Text = "R";
            this.radioButton_R.UseVisualStyleBackColor = true;
            this.radioButton_R.CheckedChanged += new System.EventHandler(this.radioButton_R_CheckedChanged);
            // 
            // radioButton_V
            // 
            this.radioButton_V.AutoSize = true;
            this.radioButton_V.Location = new System.Drawing.Point(14, 22);
            this.radioButton_V.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_V.Name = "radioButton_V";
            this.radioButton_V.Size = new System.Drawing.Size(45, 24);
            this.radioButton_V.TabIndex = 36;
            this.radioButton_V.TabStop = true;
            this.radioButton_V.Text = "V";
            this.radioButton_V.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(230, 195);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 20);
            this.label18.TabIndex = 35;
            this.label18.Text = "Vce = ";
            // 
            // trackBar_R2
            // 
            this.trackBar_R2.Location = new System.Drawing.Point(916, 137);
            this.trackBar_R2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_R2.Name = "trackBar_R2";
            this.trackBar_R2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_R2.Size = new System.Drawing.Size(69, 378);
            this.trackBar_R2.TabIndex = 34;
            this.trackBar_R2.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_R1
            // 
            this.trackBar_R1.Location = new System.Drawing.Point(840, 137);
            this.trackBar_R1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_R1.Name = "trackBar_R1";
            this.trackBar_R1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_R1.Size = new System.Drawing.Size(69, 378);
            this.trackBar_R1.TabIndex = 33;
            this.trackBar_R1.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Ve_Re
            // 
            this.trackBar_Ve_Re.Location = new System.Drawing.Point(766, 137);
            this.trackBar_Ve_Re.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_Ve_Re.Name = "trackBar_Ve_Re";
            this.trackBar_Ve_Re.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Ve_Re.Size = new System.Drawing.Size(69, 378);
            this.trackBar_Ve_Re.TabIndex = 32;
            this.trackBar_Ve_Re.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Vce_Rc
            // 
            this.trackBar_Vce_Rc.Location = new System.Drawing.Point(692, 137);
            this.trackBar_Vce_Rc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_Vce_Rc.Name = "trackBar_Vce_Rc";
            this.trackBar_Vce_Rc.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Vce_Rc.Size = new System.Drawing.Size(69, 378);
            this.trackBar_Vce_Rc.TabIndex = 31;
            this.trackBar_Vce_Rc.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Ic
            // 
            this.trackBar_Ic.Location = new System.Drawing.Point(616, 137);
            this.trackBar_Ic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_Ic.Name = "trackBar_Ic";
            this.trackBar_Ic.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Ic.Size = new System.Drawing.Size(69, 378);
            this.trackBar_Ic.TabIndex = 30;
            this.trackBar_Ic.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Vcc
            // 
            this.trackBar_Vcc.Location = new System.Drawing.Point(542, 137);
            this.trackBar_Vcc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_Vcc.Name = "trackBar_Vcc";
            this.trackBar_Vcc.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Vcc.Size = new System.Drawing.Size(69, 378);
            this.trackBar_Vcc.TabIndex = 29;
            this.trackBar_Vcc.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Vbe
            // 
            this.trackBar_Vbe.Location = new System.Drawing.Point(466, 137);
            this.trackBar_Vbe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_Vbe.Name = "trackBar_Vbe";
            this.trackBar_Vbe.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Vbe.Size = new System.Drawing.Size(69, 378);
            this.trackBar_Vbe.TabIndex = 28;
            this.trackBar_Vbe.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar_Beta
            // 
            this.trackBar_Beta.Location = new System.Drawing.Point(392, 137);
            this.trackBar_Beta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_Beta.Name = "trackBar_Beta";
            this.trackBar_Beta.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Beta.Size = new System.Drawing.Size(69, 378);
            this.trackBar_Beta.TabIndex = 27;
            this.trackBar_Beta.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label_Vce
            // 
            this.label_Vce.AutoSize = true;
            this.label_Vce.Location = new System.Drawing.Point(290, 195);
            this.label_Vce.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Vce.Name = "label_Vce";
            this.label_Vce.Size = new System.Drawing.Size(37, 20);
            this.label_Vce.TabIndex = 26;
            this.label_Vce.Text = "Vce";
            // 
            // label_Ve
            // 
            this.label_Ve.AutoSize = true;
            this.label_Ve.Location = new System.Drawing.Point(290, 295);
            this.label_Ve.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Ve.Name = "label_Ve";
            this.label_Ve.Size = new System.Drawing.Size(29, 20);
            this.label_Ve.TabIndex = 25;
            this.label_Ve.Text = "Ve";
            // 
            // label_Ir1
            // 
            this.label_Ir1.AutoSize = true;
            this.label_Ir1.Location = new System.Drawing.Point(30, 169);
            this.label_Ir1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Ir1.Name = "label_Ir1";
            this.label_Ir1.Size = new System.Drawing.Size(28, 20);
            this.label_Ir1.TabIndex = 24;
            this.label_Ir1.Text = "Ir1";
            // 
            // label_Ir2
            // 
            this.label_Ir2.AutoSize = true;
            this.label_Ir2.Location = new System.Drawing.Point(30, 297);
            this.label_Ir2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Ir2.Name = "label_Ir2";
            this.label_Ir2.Size = new System.Drawing.Size(28, 20);
            this.label_Ir2.TabIndex = 23;
            this.label_Ir2.Text = "Ir2";
            // 
            // label_Ib
            // 
            this.label_Ib.AutoSize = true;
            this.label_Ib.Location = new System.Drawing.Point(93, 208);
            this.label_Ib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Ib.Name = "label_Ib";
            this.label_Ib.Size = new System.Drawing.Size(23, 20);
            this.label_Ib.TabIndex = 22;
            this.label_Ib.Text = "Ib";
            // 
            // button_bias
            // 
            this.button_bias.Location = new System.Drawing.Point(392, 523);
            this.button_bias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_bias.Name = "button_bias";
            this.button_bias.Size = new System.Drawing.Size(150, 35);
            this.button_bias.TabIndex = 21;
            this.button_bias.Text = "Calculate";
            this.button_bias.UseVisualStyleBackColor = true;
            this.button_bias.Click += new System.EventHandler(this.buttion_bias_Click);
            // 
            // edit_R2
            // 
            this.edit_R2.Location = new System.Drawing.Point(916, 97);
            this.edit_R2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_R2.Name = "edit_R2";
            this.edit_R2.Size = new System.Drawing.Size(43, 26);
            this.edit_R2.TabIndex = 8;
            this.edit_R2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_R2.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(912, 72);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 20);
            this.label26.TabIndex = 19;
            this.label26.Text = "R2";
            // 
            // edit_R1
            // 
            this.edit_R1.Location = new System.Drawing.Point(842, 97);
            this.edit_R1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_R1.Name = "edit_R1";
            this.edit_R1.Size = new System.Drawing.Size(43, 26);
            this.edit_R1.TabIndex = 7;
            this.edit_R1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_R1.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(842, 72);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 20);
            this.label27.TabIndex = 17;
            this.label27.Text = "R1";
            // 
            // edit_Vce_Rc
            // 
            this.edit_Vce_Rc.Location = new System.Drawing.Point(692, 97);
            this.edit_Vce_Rc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Vce_Rc.Name = "edit_Vce_Rc";
            this.edit_Vce_Rc.Size = new System.Drawing.Size(43, 26);
            this.edit_Vce_Rc.TabIndex = 5;
            this.edit_Vce_Rc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Vce_Rc.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label_Vce_Rc
            // 
            this.label_Vce_Rc.AutoSize = true;
            this.label_Vce_Rc.Location = new System.Drawing.Point(682, 72);
            this.label_Vce_Rc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Vce_Rc.Name = "label_Vce_Rc";
            this.label_Vce_Rc.Size = new System.Drawing.Size(61, 20);
            this.label_Vce_Rc.TabIndex = 15;
            this.label_Vce_Rc.Text = "Vce/Rc";
            // 
            // edit_VeRe
            // 
            this.edit_VeRe.Location = new System.Drawing.Point(766, 97);
            this.edit_VeRe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_VeRe.Name = "edit_VeRe";
            this.edit_VeRe.Size = new System.Drawing.Size(43, 26);
            this.edit_VeRe.TabIndex = 6;
            this.edit_VeRe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_VeRe.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label_VeRe
            // 
            this.label_VeRe.AutoSize = true;
            this.label_VeRe.Location = new System.Drawing.Point(765, 72);
            this.label_VeRe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_VeRe.Name = "label_VeRe";
            this.label_VeRe.Size = new System.Drawing.Size(54, 20);
            this.label_VeRe.TabIndex = 13;
            this.label_VeRe.Text = "Ve/Re";
            // 
            // edit_Vbe
            // 
            this.edit_Vbe.Location = new System.Drawing.Point(466, 97);
            this.edit_Vbe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Vbe.Name = "edit_Vbe";
            this.edit_Vbe.Size = new System.Drawing.Size(43, 26);
            this.edit_Vbe.TabIndex = 2;
            this.edit_Vbe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Vbe.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // Vbe
            // 
            this.Vbe.AutoSize = true;
            this.Vbe.Location = new System.Drawing.Point(472, 72);
            this.Vbe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Vbe.Name = "Vbe";
            this.Vbe.Size = new System.Drawing.Size(38, 20);
            this.Vbe.TabIndex = 1;
            this.Vbe.Text = "Vbe";
            // 
            // edit_beta
            // 
            this.edit_beta.Location = new System.Drawing.Point(392, 95);
            this.edit_beta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_beta.Name = "edit_beta";
            this.edit_beta.Size = new System.Drawing.Size(43, 26);
            this.edit_beta.TabIndex = 1;
            this.edit_beta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_beta.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(393, 72);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(43, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "Beta";
            // 
            // edit_Ic
            // 
            this.edit_Ic.Location = new System.Drawing.Point(616, 97);
            this.edit_Ic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Ic.Name = "edit_Ic";
            this.edit_Ic.Size = new System.Drawing.Size(43, 26);
            this.edit_Ic.TabIndex = 4;
            this.edit_Ic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Ic.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // Ic
            // 
            this.Ic.AutoSize = true;
            this.Ic.Location = new System.Drawing.Point(618, 72);
            this.Ic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ic.Name = "Ic";
            this.Ic.Size = new System.Drawing.Size(54, 20);
            this.Ic.TabIndex = 7;
            this.Ic.Text = "Ic, mA";
            // 
            // edit_Vcc
            // 
            this.edit_Vcc.Location = new System.Drawing.Point(542, 97);
            this.edit_Vcc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_Vcc.Name = "edit_Vcc";
            this.edit_Vcc.Size = new System.Drawing.Size(43, 26);
            this.edit_Vcc.TabIndex = 3;
            this.edit_Vcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_KeyDown);
            this.edit_Vcc.Leave += new System.EventHandler(this.edit_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(543, 72);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 20);
            this.label22.TabIndex = 5;
            this.label22.Text = "Vcc";
            // 
            // label_R4
            // 
            this.label_R4.AutoSize = true;
            this.label_R4.Location = new System.Drawing.Point(297, 398);
            this.label_R4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_R4.Name = "label_R4";
            this.label_R4.Size = new System.Drawing.Size(30, 20);
            this.label_R4.TabIndex = 4;
            this.label_R4.Text = "R4";
            // 
            // label_R3
            // 
            this.label_R3.AutoSize = true;
            this.label_R3.Location = new System.Drawing.Point(297, 98);
            this.label_R3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_R3.Name = "label_R3";
            this.label_R3.Size = new System.Drawing.Size(30, 20);
            this.label_R3.TabIndex = 3;
            this.label_R3.Text = "R3";
            // 
            // label_R2
            // 
            this.label_R2.AutoSize = true;
            this.label_R2.Location = new System.Drawing.Point(123, 398);
            this.label_R2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_R2.Name = "label_R2";
            this.label_R2.Size = new System.Drawing.Size(30, 20);
            this.label_R2.TabIndex = 2;
            this.label_R2.Text = "R2";
            // 
            // label_R1
            // 
            this.label_R1.AutoSize = true;
            this.label_R1.Location = new System.Drawing.Point(123, 98);
            this.label_R1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_R1.Name = "label_R1";
            this.label_R1.Size = new System.Drawing.Size(30, 20);
            this.label_R1.TabIndex = 1;
            this.label_R1.Text = "R1";
            // 
            // label17
            // 
            this.label17.Image = ((System.Drawing.Image)(resources.GetObject("label17.Image")));
            this.label17.Location = new System.Drawing.Point(30, 5);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(342, 472);
            this.label17.TabIndex = 0;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(17, 418);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(36, 20);
            this.label33.TabIndex = 137;
            this.label33.Text = "Vin:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_in
            // 
            this.v_in.Location = new System.Drawing.Point(139, 418);
            this.v_in.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.v_in.Name = "v_in";
            this.v_in.Size = new System.Drawing.Size(180, 26);
            this.v_in.TabIndex = 138;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(17, 464);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(47, 20);
            this.label36.TabIndex = 139;
            this.label36.Text = "Vout:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // v_out
            // 
            this.v_out.Location = new System.Drawing.Point(139, 464);
            this.v_out.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.v_out.Name = "v_out";
            this.v_out.Size = new System.Drawing.Size(180, 26);
            this.v_out.TabIndex = 140;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(14, 249);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(185, 20);
            this.label43.TabIndex = 141;
            this.label43.Text = "Magnetic path:, WxH cm:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_mpath_W
            // 
            this.edit_mpath_W.Location = new System.Drawing.Point(198, 246);
            this.edit_mpath_W.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_mpath_W.Name = "edit_mpath_W";
            this.edit_mpath_W.Size = new System.Drawing.Size(60, 26);
            this.edit_mpath_W.TabIndex = 142;
            // 
            // edit_mpath_H
            // 
            this.edit_mpath_H.Location = new System.Drawing.Point(266, 246);
            this.edit_mpath_H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_mpath_H.Name = "edit_mpath_H";
            this.edit_mpath_H.Size = new System.Drawing.Size(53, 26);
            this.edit_mpath_H.TabIndex = 143;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(644, 509);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(42, 20);
            this.label44.TabIndex = 144;
            this.label44.Text = "L, H:";
            // 
            // res_L1
            // 
            this.res_L1.AutoSize = true;
            this.res_L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.res_L1.Location = new System.Drawing.Point(769, 515);
            this.res_L1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res_L1.Name = "res_L1";
            this.res_L1.Size = new System.Drawing.Size(15, 22);
            this.res_L1.TabIndex = 145;
            this.res_L1.Text = " ";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(14, 285);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(98, 20);
            this.label45.TabIndex = 146;
            this.label45.Text = "Permeability:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edit_permeability
            // 
            this.edit_permeability.Location = new System.Drawing.Point(139, 281);
            this.edit_permeability.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.edit_permeability.Name = "edit_permeability";
            this.edit_permeability.Size = new System.Drawing.Size(180, 26);
            this.edit_permeability.TabIndex = 147;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1267, 718);
            this.Controls.Add(this.calcTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Label res_resistance_1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label res_thickness_mm_1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label res_length_ft_1;
        private System.Windows.Forms.Label res_length_m_1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label res_lastLayerTurns_1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label res_totalLayers_1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edit_turnsPerLayer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edit_N1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edit_coreW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edit_coreH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edit_Wfactor1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edit_bobbinH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edit_bobbinW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edit_bobbinL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox awgCombo1;
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
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox edit_turnsPerLayer2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox edit_N2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox edit_Wfactor2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox awgCombo2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label res_resistance_2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label res_thickness_mm_2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label res_length_ft_2;
        private System.Windows.Forms.Label res_length_m_2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label res_lastLayerTurns_2;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label res_totalLayers_2;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label res_turns_1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label res_turns_2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label res_turns_per_layer_2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label res_turns_per_layer_1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox v_in;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox v_out;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox edit_mpath_H;
        private System.Windows.Forms.TextBox edit_mpath_W;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label res_L1;
        private System.Windows.Forms.TextBox edit_permeability;
        private System.Windows.Forms.Label label45;
    }
}

