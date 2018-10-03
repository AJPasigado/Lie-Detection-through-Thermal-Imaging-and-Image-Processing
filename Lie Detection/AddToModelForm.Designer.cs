namespace Lie_Detection {
    partial class AddToModelForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EBTI_SummaryGRD = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.DoneBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EBTI_SummaryGRD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 30);
            this.label1.TabIndex = 34;
            this.label1.Text = "Add Data to Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Eye Blink and Thermal Slope Data";
            // 
            // EBTI_SummaryGRD
            // 
            this.EBTI_SummaryGRD.AllowUserToResizeColumns = false;
            this.EBTI_SummaryGRD.AllowUserToResizeRows = false;
            this.EBTI_SummaryGRD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EBTI_SummaryGRD.BackgroundColor = System.Drawing.Color.White;
            this.EBTI_SummaryGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EBTI_SummaryGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.EBTI_SummaryGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EBTI_SummaryGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EBTI_SummaryGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.EBTI_SummaryGRD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EBTI_SummaryGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.EBTI_SummaryGRD.EnableHeadersVisualStyles = false;
            this.EBTI_SummaryGRD.GridColor = System.Drawing.Color.White;
            this.EBTI_SummaryGRD.Location = new System.Drawing.Point(35, 103);
            this.EBTI_SummaryGRD.Name = "EBTI_SummaryGRD";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EBTI_SummaryGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.EBTI_SummaryGRD.RowHeadersVisible = false;
            this.EBTI_SummaryGRD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.EBTI_SummaryGRD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EBTI_SummaryGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EBTI_SummaryGRD.Size = new System.Drawing.Size(525, 340);
            this.EBTI_SummaryGRD.TabIndex = 58;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Eye Blink Slope";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Temperature Slope";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn7.Items.AddRange(new object[] {
            "TRUTH",
            "LIE"});
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CancelBTN
            // 
            this.CancelBTN.BackColor = System.Drawing.Color.White;
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.CancelBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.CancelBTN.Location = new System.Drawing.Point(309, 471);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(252, 33);
            this.CancelBTN.TabIndex = 60;
            this.CancelBTN.Text = "CANCEL";
            this.CancelBTN.UseVisualStyleBackColor = false;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // DoneBTN
            // 
            this.DoneBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DoneBTN.FlatAppearance.BorderSize = 0;
            this.DoneBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.DoneBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.DoneBTN.Location = new System.Drawing.Point(33, 471);
            this.DoneBTN.Name = "DoneBTN";
            this.DoneBTN.Size = new System.Drawing.Size(255, 33);
            this.DoneBTN.TabIndex = 59;
            this.DoneBTN.Text = "DONE";
            this.DoneBTN.UseVisualStyleBackColor = false;
            this.DoneBTN.Click += new System.EventHandler(this.DoneBTN_Click);
            // 
            // AddToModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 540);
            this.ControlBox = false;
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.DoneBTN);
            this.Controls.Add(this.EBTI_SummaryGRD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddToModelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddToModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EBTI_SummaryGRD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView EBTI_SummaryGRD;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button DoneBTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn7;
    }
}