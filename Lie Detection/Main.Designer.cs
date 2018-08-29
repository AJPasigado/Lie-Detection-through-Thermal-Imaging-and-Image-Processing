namespace Lie_Detection {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.EB_VideoFeedIB = new Emgu.CV.UI.ImageBox();
            this.EB_LBL1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EB_LBL2 = new System.Windows.Forms.Label();
            this.EB_AverageEyeBlinkLBL = new System.Windows.Forms.Label();
            this.EB_LBL4 = new System.Windows.Forms.Label();
            this.EB_LBL3 = new System.Windows.Forms.Label();
            this.EB_RealtimeLogTXBX = new System.Windows.Forms.TextBox();
            this.TI_VideoFeedIB = new Emgu.CV.UI.ImageBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.EB_BlinkedLBL = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.TI_AverageTempLBL = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TI_RealtimeLogTXBX = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.TI_CurrentTempLBL = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.EB_FromFileBTN = new System.Windows.Forms.Button();
            this.EB_OpenFileDBOX = new System.Windows.Forms.OpenFileDialog();
            this.EB_FramesTimer = new System.Windows.Forms.Timer(this.components);
            this.FadeTimer = new System.Windows.Forms.Timer(this.components);
            this.TI_FromFileBTN = new System.Windows.Forms.Button();
            this.TI_OpenFileDBOX = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.EB_VideoFeedIB)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TI_VideoFeedIB)).BeginInit();
            this.SuspendLayout();
            // 
            // EB_VideoFeedIB
            // 
            this.EB_VideoFeedIB.Location = new System.Drawing.Point(417, 124);
            this.EB_VideoFeedIB.Name = "EB_VideoFeedIB";
            this.EB_VideoFeedIB.Size = new System.Drawing.Size(300, 207);
            this.EB_VideoFeedIB.TabIndex = 2;
            this.EB_VideoFeedIB.TabStop = false;
            // 
            // EB_LBL1
            // 
            this.EB_LBL1.AutoSize = true;
            this.EB_LBL1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EB_LBL1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_LBL1.Location = new System.Drawing.Point(414, 397);
            this.EB_LBL1.Name = "EB_LBL1";
            this.EB_LBL1.Size = new System.Drawing.Size(143, 15);
            this.EB_LBL1.TabIndex = 3;
            this.EB_LBL1.Text = "NUMBER OF EYE BLINKS";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label37);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(766, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 844);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(105, 112);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(41, 32);
            this.label40.TabIndex = 34;
            this.label40.Text = "F8";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(47, 144);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(131, 15);
            this.label41.TabIndex = 33;
            this.label41.Text = "TO PRE-PROCESS DATA";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(43, 112);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 32);
            this.label42.TabIndex = 32;
            this.label42.Text = "Press";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(102, 646);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 32);
            this.label37.TabIndex = 31;
            this.label37.Text = "F3";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(44, 681);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 15);
            this.label38.TabIndex = 30;
            this.label38.Text = "TO QUIT";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(40, 646);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 32);
            this.label39.TabIndex = 29;
            this.label39.Text = "Press";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(102, 579);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 32);
            this.label19.TabIndex = 28;
            this.label19.Text = "F2";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(44, 614);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 15);
            this.label20.TabIndex = 27;
            this.label20.Text = "FOR ABOUT";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(40, 579);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 32);
            this.label21.TabIndex = 26;
            this.label21.Text = "Press";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(102, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 32);
            this.label4.TabIndex = 25;
            this.label4.Text = "F1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(44, 547);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "FOR HOW-TO";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(40, 512);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 32);
            this.label16.TabIndex = 23;
            this.label16.Text = "Press";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(103, 404);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 32);
            this.label15.TabIndex = 22;
            this.label15.Text = "F12";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(45, 439);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "TO STOP CURRENT SESSION";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(41, 404);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 32);
            this.label18.TabIndex = 19;
            this.label18.Text = "Press";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(103, 316);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 32);
            this.label11.TabIndex = 18;
            this.label11.Text = "F11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(45, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "AND/OR ANALYZE RESULT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(45, 349);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 15);
            this.label13.TabIndex = 16;
            this.label13.Text = "TO STOP CURRENT SESSION";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(41, 316);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 32);
            this.label14.TabIndex = 15;
            this.label14.Text = "Press";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(103, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 32);
            this.label7.TabIndex = 14;
            this.label7.Text = "F10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(45, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "FOR ANSWERING";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(41, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 32);
            this.label10.TabIndex = 11;
            this.label10.Text = "Press";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(46, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "CONTROLS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(103, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "F9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(45, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "TO START ASKING";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(41, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Press";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Periorbital Region Analysis";
            // 
            // EB_LBL2
            // 
            this.EB_LBL2.AutoSize = true;
            this.EB_LBL2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EB_LBL2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_LBL2.Location = new System.Drawing.Point(414, 414);
            this.EB_LBL2.Name = "EB_LBL2";
            this.EB_LBL2.Size = new System.Drawing.Size(41, 15);
            this.EB_LBL2.TabIndex = 6;
            this.EB_LBL2.Text = "TOTAL";
            // 
            // EB_AverageEyeBlinkLBL
            // 
            this.EB_AverageEyeBlinkLBL.AutoSize = true;
            this.EB_AverageEyeBlinkLBL.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EB_AverageEyeBlinkLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_AverageEyeBlinkLBL.Location = new System.Drawing.Point(406, 427);
            this.EB_AverageEyeBlinkLBL.Name = "EB_AverageEyeBlinkLBL";
            this.EB_AverageEyeBlinkLBL.Size = new System.Drawing.Size(56, 65);
            this.EB_AverageEyeBlinkLBL.TabIndex = 7;
            this.EB_AverageEyeBlinkLBL.Text = "0";
            // 
            // EB_LBL4
            // 
            this.EB_LBL4.AutoSize = true;
            this.EB_LBL4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EB_LBL4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_LBL4.Location = new System.Drawing.Point(414, 514);
            this.EB_LBL4.Name = "EB_LBL4";
            this.EB_LBL4.Size = new System.Drawing.Size(93, 15);
            this.EB_LBL4.TabIndex = 9;
            this.EB_LBL4.Text = "EYE BLINKS LOG";
            // 
            // EB_LBL3
            // 
            this.EB_LBL3.AutoSize = true;
            this.EB_LBL3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EB_LBL3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_LBL3.Location = new System.Drawing.Point(414, 497);
            this.EB_LBL3.Name = "EB_LBL3";
            this.EB_LBL3.Size = new System.Drawing.Size(62, 15);
            this.EB_LBL3.TabIndex = 8;
            this.EB_LBL3.Text = "REALTIME";
            // 
            // EB_RealtimeLogTXBX
            // 
            this.EB_RealtimeLogTXBX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EB_RealtimeLogTXBX.BackColor = System.Drawing.Color.White;
            this.EB_RealtimeLogTXBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EB_RealtimeLogTXBX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EB_RealtimeLogTXBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_RealtimeLogTXBX.Location = new System.Drawing.Point(413, 564);
            this.EB_RealtimeLogTXBX.Multiline = true;
            this.EB_RealtimeLogTXBX.Name = "EB_RealtimeLogTXBX";
            this.EB_RealtimeLogTXBX.ReadOnly = true;
            this.EB_RealtimeLogTXBX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EB_RealtimeLogTXBX.Size = new System.Drawing.Size(304, 223);
            this.EB_RealtimeLogTXBX.TabIndex = 10;
            // 
            // TI_VideoFeedIB
            // 
            this.TI_VideoFeedIB.Location = new System.Drawing.Point(51, 124);
            this.TI_VideoFeedIB.Name = "TI_VideoFeedIB";
            this.TI_VideoFeedIB.Size = new System.Drawing.Size(300, 207);
            this.TI_VideoFeedIB.TabIndex = 11;
            this.TI_VideoFeedIB.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label22.Location = new System.Drawing.Point(414, 96);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(127, 15);
            this.label22.TabIndex = 12;
            this.label22.Text = "EYE BLINK TRACKING";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label23.Location = new System.Drawing.Point(48, 96);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 15);
            this.label23.TabIndex = 13;
            this.label23.Text = "THERMAL IMAGING";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label24.Location = new System.Drawing.Point(414, 542);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 15);
            this.label24.TabIndex = 14;
            this.label24.Text = "TIME";
            // 
            // EB_BlinkedLBL
            // 
            this.EB_BlinkedLBL.AutoSize = true;
            this.EB_BlinkedLBL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EB_BlinkedLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_BlinkedLBL.Location = new System.Drawing.Point(608, 341);
            this.EB_BlinkedLBL.Name = "EB_BlinkedLBL";
            this.EB_BlinkedLBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EB_BlinkedLBL.Size = new System.Drawing.Size(116, 32);
            this.EB_BlinkedLBL.TabIndex = 15;
            this.EB_BlinkedLBL.Text = "BLINKED";
            this.EB_BlinkedLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EB_BlinkedLBL.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label25.Location = new System.Drawing.Point(48, 414);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(164, 15);
            this.label25.TabIndex = 17;
            this.label25.Text = "OF THE PERIORBITAL REGION";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label26.Location = new System.Drawing.Point(48, 397);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(201, 15);
            this.label26.TabIndex = 16;
            this.label26.Text = "AVERAGE TEMPERATURE (CELCIUS)";
            // 
            // TI_AverageTempLBL
            // 
            this.TI_AverageTempLBL.AutoSize = true;
            this.TI_AverageTempLBL.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TI_AverageTempLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.TI_AverageTempLBL.Location = new System.Drawing.Point(40, 427);
            this.TI_AverageTempLBL.Name = "TI_AverageTempLBL";
            this.TI_AverageTempLBL.Size = new System.Drawing.Size(125, 65);
            this.TI_AverageTempLBL.TabIndex = 18;
            this.TI_AverageTempLBL.Text = "0.00";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label28.Location = new System.Drawing.Point(48, 514);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(164, 15);
            this.label28.TabIndex = 20;
            this.label28.Text = "OF THE PERIORBITAL REGION";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label29.Location = new System.Drawing.Point(48, 497);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(147, 15);
            this.label29.TabIndex = 19;
            this.label29.Text = "REALTIME TEMPERATURE";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label30.Location = new System.Drawing.Point(48, 546);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 15);
            this.label30.TabIndex = 21;
            this.label30.Text = "FRAME TIME";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label31.Location = new System.Drawing.Point(237, 546);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(38, 15);
            this.label31.TabIndex = 22;
            this.label31.Text = "TEMP";
            // 
            // TI_RealtimeLogTXBX
            // 
            this.TI_RealtimeLogTXBX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TI_RealtimeLogTXBX.BackColor = System.Drawing.Color.White;
            this.TI_RealtimeLogTXBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TI_RealtimeLogTXBX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TI_RealtimeLogTXBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.TI_RealtimeLogTXBX.Location = new System.Drawing.Point(45, 567);
            this.TI_RealtimeLogTXBX.Multiline = true;
            this.TI_RealtimeLogTXBX.Name = "TI_RealtimeLogTXBX";
            this.TI_RealtimeLogTXBX.ReadOnly = true;
            this.TI_RealtimeLogTXBX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TI_RealtimeLogTXBX.Size = new System.Drawing.Size(306, 223);
            this.TI_RealtimeLogTXBX.TabIndex = 23;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label32.Location = new System.Drawing.Point(49, 357);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(120, 12);
            this.label32.TabIndex = 25;
            this.label32.Text = "OF THE PERIORBITAL REGION";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label33.Location = new System.Drawing.Point(49, 345);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(158, 12);
            this.label33.TabIndex = 24;
            this.label33.Text = "CURRENT TEMPERATURE (CELCIUS)";
            // 
            // TI_CurrentTempLBL
            // 
            this.TI_CurrentTempLBL.AutoSize = true;
            this.TI_CurrentTempLBL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TI_CurrentTempLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.TI_CurrentTempLBL.Location = new System.Drawing.Point(287, 339);
            this.TI_CurrentTempLBL.Name = "TI_CurrentTempLBL";
            this.TI_CurrentTempLBL.Size = new System.Drawing.Size(64, 32);
            this.TI_CurrentTempLBL.TabIndex = 26;
            this.TI_CurrentTempLBL.Text = "0.00";
            this.TI_CurrentTempLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label35.Location = new System.Drawing.Point(415, 357);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(120, 12);
            this.label35.TabIndex = 28;
            this.label35.Text = "OF THE PERIORBITAL REGION";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label36.Location = new System.Drawing.Point(415, 345);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 12);
            this.label36.TabIndex = 27;
            this.label36.Text = "CURRENT STATUS";
            // 
            // EB_FromFileBTN
            // 
            this.EB_FromFileBTN.BackColor = System.Drawing.Color.White;
            this.EB_FromFileBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EB_FromFileBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.EB_FromFileBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_FromFileBTN.Location = new System.Drawing.Point(630, 91);
            this.EB_FromFileBTN.Name = "EB_FromFileBTN";
            this.EB_FromFileBTN.Size = new System.Drawing.Size(88, 23);
            this.EB_FromFileBTN.TabIndex = 29;
            this.EB_FromFileBTN.Text = "FROM FILE";
            this.EB_FromFileBTN.UseVisualStyleBackColor = false;
            this.EB_FromFileBTN.Click += new System.EventHandler(this.EB_FromFileBTN_Click);
            // 
            // EB_OpenFileDBOX
            // 
            this.EB_OpenFileDBOX.FileName = "openFileDialog1";
            this.EB_OpenFileDBOX.Filter = "Video Files|*.mp4";
            // 
            // EB_FramesTimer
            // 
            this.EB_FramesTimer.Interval = 31;
            this.EB_FramesTimer.Tick += new System.EventHandler(this.EB_FramesTimer_Tick);
            // 
            // FadeTimer
            // 
            this.FadeTimer.Interval = 1;
            this.FadeTimer.Tick += new System.EventHandler(this.FadeTimer_Tick);
            // 
            // TI_FromFileBTN
            // 
            this.TI_FromFileBTN.BackColor = System.Drawing.Color.White;
            this.TI_FromFileBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TI_FromFileBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.TI_FromFileBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.TI_FromFileBTN.Location = new System.Drawing.Point(263, 92);
            this.TI_FromFileBTN.Name = "TI_FromFileBTN";
            this.TI_FromFileBTN.Size = new System.Drawing.Size(88, 23);
            this.TI_FromFileBTN.TabIndex = 30;
            this.TI_FromFileBTN.Text = "FROM FILE";
            this.TI_FromFileBTN.UseVisualStyleBackColor = false;
            this.TI_FromFileBTN.Click += new System.EventHandler(this.TI_FromFileBTN_Click);
            // 
            // TI_OpenFileDBOX
            // 
            this.TI_OpenFileDBOX.FileName = "openFileDialog1";
            this.TI_OpenFileDBOX.Filter = "Video Files|*.mp4";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 828);
            this.ControlBox = false;
            this.Controls.Add(this.TI_FromFileBTN);
            this.Controls.Add(this.EB_FromFileBTN);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.TI_CurrentTempLBL);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.TI_RealtimeLogTXBX);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.TI_AverageTempLBL);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.EB_BlinkedLBL);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.TI_VideoFeedIB);
            this.Controls.Add(this.EB_RealtimeLogTXBX);
            this.Controls.Add(this.EB_LBL4);
            this.Controls.Add(this.EB_LBL3);
            this.Controls.Add(this.EB_AverageEyeBlinkLBL);
            this.Controls.Add(this.EB_LBL2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EB_LBL1);
            this.Controls.Add(this.EB_VideoFeedIB);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1040, 830);
            this.Name = "Main";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TI_getFrames);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.EB_VideoFeedIB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TI_VideoFeedIB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox EB_VideoFeedIB;
        private System.Windows.Forms.Label EB_LBL1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EB_LBL2;
        private System.Windows.Forms.Label EB_AverageEyeBlinkLBL;
        private System.Windows.Forms.Label EB_LBL4;
        private System.Windows.Forms.Label EB_LBL3;
        private System.Windows.Forms.TextBox EB_RealtimeLogTXBX;
        private Emgu.CV.UI.ImageBox TI_VideoFeedIB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label EB_BlinkedLBL;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label TI_AverageTempLBL;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TI_RealtimeLogTXBX;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label TI_CurrentTempLBL;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button EB_FromFileBTN;
        private System.Windows.Forms.OpenFileDialog EB_OpenFileDBOX;
        private System.Windows.Forms.Timer EB_FramesTimer;
        private System.Windows.Forms.Timer FadeTimer;
        private System.Windows.Forms.Button TI_FromFileBTN;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.OpenFileDialog TI_OpenFileDBOX;
    }
}

