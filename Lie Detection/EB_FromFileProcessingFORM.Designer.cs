﻿namespace Lie_Detection
{
    partial class EB_FromFileProcessingFORM
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EB_RealtimeLogTXBX = new System.Windows.Forms.TextBox();
            this.DoneBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EB_RealtimeLogTXBX
            // 
            this.EB_RealtimeLogTXBX.BackColor = System.Drawing.Color.White;
            this.EB_RealtimeLogTXBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EB_RealtimeLogTXBX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EB_RealtimeLogTXBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.EB_RealtimeLogTXBX.Location = new System.Drawing.Point(36, 150);
            this.EB_RealtimeLogTXBX.Multiline = true;
            this.EB_RealtimeLogTXBX.Name = "EB_RealtimeLogTXBX";
            this.EB_RealtimeLogTXBX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EB_RealtimeLogTXBX.Size = new System.Drawing.Size(487, 310);
            this.EB_RealtimeLogTXBX.TabIndex = 11;
            this.EB_RealtimeLogTXBX.WordWrap = false;
            // 
            // DoneBTN
            // 
            this.DoneBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DoneBTN.FlatAppearance.BorderSize = 0;
            this.DoneBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.DoneBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.DoneBTN.Location = new System.Drawing.Point(36, 484);
            this.DoneBTN.Name = "DoneBTN";
            this.DoneBTN.Size = new System.Drawing.Size(487, 33);
            this.DoneBTN.TabIndex = 32;
            this.DoneBTN.Text = "DONE";
            this.DoneBTN.UseVisualStyleBackColor = false;
            this.DoneBTN.Click += new System.EventHandler(this.DoneBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 30);
            this.label1.TabIndex = 33;
            this.label1.Text = "Result Formatting";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.textBox1.Location = new System.Drawing.Point(34, 76);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(487, 68);
            this.textBox1.TabIndex = 34;
            this.textBox1.Text = "Insert the following to their desired positions:\r\n\r\n=== WATCHING/ASKING ===\r\n=== " +
    "ANSWERING ===\r\n";
            // 
            // EB_FromFileProcessingFORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.DoneBTN;
            this.ClientSize = new System.Drawing.Size(558, 551);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoneBTN);
            this.Controls.Add(this.EB_RealtimeLogTXBX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EB_FromFileProcessingFORM";
            this.Load += new System.EventHandler(this.EB_FromFileProcessingFORM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EB_RealtimeLogTXBX;
        private System.Windows.Forms.Button DoneBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}