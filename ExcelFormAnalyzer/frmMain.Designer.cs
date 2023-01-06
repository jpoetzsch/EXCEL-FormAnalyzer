namespace ExcelFormAnalyzer
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.butConvert = new System.Windows.Forms.Button();
            this.rtfConv = new System.Windows.Forms.RichTextBox();
            this.ButFormatierungenEntfernen = new System.Windows.Forms.Button();
            this.ButCopyToClipboard = new System.Windows.Forms.Button();
            this.ButZwischenablageEinfuegen = new System.Windows.Forms.Button();
            this.dgvFunktionen = new System.Windows.Forms.DataGridView();
            this.colFunktionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtfRaw = new System.Windows.Forms.RichTextBox();
            this.rbTabulator = new System.Windows.Forms.RadioButton();
            this.rbLeerzeichen = new System.Windows.Forms.RadioButton();
            this.cboAnzLeerzeichen = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunktionen)).BeginInit();
            this.SuspendLayout();
            // 
            // butConvert
            // 
            this.butConvert.Location = new System.Drawing.Point(12, 163);
            this.butConvert.Name = "butConvert";
            this.butConvert.Size = new System.Drawing.Size(75, 23);
            this.butConvert.TabIndex = 2;
            this.butConvert.Text = "convert";
            this.butConvert.UseVisualStyleBackColor = true;
            this.butConvert.Click += new System.EventHandler(this.ButConvert_Click);
            // 
            // rtfConv
            // 
            this.rtfConv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfConv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(254)))), ((int)(((byte)(211)))));
            this.rtfConv.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfConv.Location = new System.Drawing.Point(12, 192);
            this.rtfConv.Name = "rtfConv";
            this.rtfConv.Size = new System.Drawing.Size(334, 496);
            this.rtfConv.TabIndex = 3;
            this.rtfConv.Text = "";
            this.rtfConv.WordWrap = false;
            this.rtfConv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtfConv_MouseClick);
            // 
            // ButFormatierungenEntfernen
            // 
            this.ButFormatierungenEntfernen.Location = new System.Drawing.Point(93, 162);
            this.ButFormatierungenEntfernen.Name = "ButFormatierungenEntfernen";
            this.ButFormatierungenEntfernen.Size = new System.Drawing.Size(202, 24);
            this.ButFormatierungenEntfernen.TabIndex = 5;
            this.ButFormatierungenEntfernen.Text = "Formatierungen entfernen";
            this.ButFormatierungenEntfernen.UseVisualStyleBackColor = true;
            this.ButFormatierungenEntfernen.Click += new System.EventHandler(this.ButFormatierungenEntfernen_Click);
            // 
            // ButCopyToClipboard
            // 
            this.ButCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButCopyToClipboard.BackgroundImage = global::ExcelFormAnalyzer.Properties.Resources.Copy;
            this.ButCopyToClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButCopyToClipboard.Location = new System.Drawing.Point(12, 694);
            this.ButCopyToClipboard.Name = "ButCopyToClipboard";
            this.ButCopyToClipboard.Size = new System.Drawing.Size(36, 36);
            this.ButCopyToClipboard.TabIndex = 6;
            this.ButCopyToClipboard.UseVisualStyleBackColor = true;
            this.ButCopyToClipboard.Click += new System.EventHandler(this.ButCopyToClipboard_Click);
            // 
            // ButZwischenablageEinfuegen
            // 
            this.ButZwischenablageEinfuegen.BackgroundImage = global::ExcelFormAnalyzer.Properties.Resources.Paste;
            this.ButZwischenablageEinfuegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButZwischenablageEinfuegen.Location = new System.Drawing.Point(12, 5);
            this.ButZwischenablageEinfuegen.Name = "ButZwischenablageEinfuegen";
            this.ButZwischenablageEinfuegen.Size = new System.Drawing.Size(36, 36);
            this.ButZwischenablageEinfuegen.TabIndex = 4;
            this.ButZwischenablageEinfuegen.UseVisualStyleBackColor = true;
            this.ButZwischenablageEinfuegen.Click += new System.EventHandler(this.ButZwischenablageEinfuegen_Click);
            // 
            // dgvFunktionen
            // 
            this.dgvFunktionen.AllowUserToAddRows = false;
            this.dgvFunktionen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFunktionen.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvFunktionen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunktionen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFunktionName,
            this.colLevel});
            this.dgvFunktionen.Location = new System.Drawing.Point(372, 192);
            this.dgvFunktionen.Name = "dgvFunktionen";
            this.dgvFunktionen.RowHeadersWidth = 25;
            this.dgvFunktionen.Size = new System.Drawing.Size(255, 496);
            this.dgvFunktionen.TabIndex = 7;
            this.dgvFunktionen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvFunktionen_MouseClick);
            // 
            // colFunktionName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.colFunktionName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colFunktionName.HeaderText = "Funktion";
            this.colFunktionName.Name = "colFunktionName";
            this.colFunktionName.Width = 150;
            // 
            // colLevel
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLevel.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLevel.HeaderText = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.Width = 60;
            // 
            // rtfRaw
            // 
            this.rtfRaw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfRaw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(234)))));
            this.rtfRaw.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfRaw.HideSelection = false;
            this.rtfRaw.Location = new System.Drawing.Point(12, 47);
            this.rtfRaw.Name = "rtfRaw";
            this.rtfRaw.Size = new System.Drawing.Size(615, 107);
            this.rtfRaw.TabIndex = 8;
            this.rtfRaw.Text = "";
            this.rtfRaw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtfRaw_MouseClick);
            // 
            // rbTabulator
            // 
            this.rbTabulator.AutoSize = true;
            this.rbTabulator.Checked = true;
            this.rbTabulator.Location = new System.Drawing.Point(362, 165);
            this.rbTabulator.Name = "rbTabulator";
            this.rbTabulator.Size = new System.Drawing.Size(70, 17);
            this.rbTabulator.TabIndex = 9;
            this.rbTabulator.TabStop = true;
            this.rbTabulator.Text = "Tabulator";
            this.rbTabulator.UseVisualStyleBackColor = true;
            this.rbTabulator.CheckedChanged += new System.EventHandler(this.rbTabulator_CheckedChanged);
            // 
            // rbLeerzeichen
            // 
            this.rbLeerzeichen.AutoSize = true;
            this.rbLeerzeichen.Location = new System.Drawing.Point(452, 165);
            this.rbLeerzeichen.Name = "rbLeerzeichen";
            this.rbLeerzeichen.Size = new System.Drawing.Size(83, 17);
            this.rbLeerzeichen.TabIndex = 10;
            this.rbLeerzeichen.Text = "Leerzeichen";
            this.rbLeerzeichen.UseVisualStyleBackColor = true;
            this.rbLeerzeichen.CheckedChanged += new System.EventHandler(this.rbLeerzeichen_CheckedChanged);
            // 
            // cboAnzLeerzeichen
            // 
            this.cboAnzLeerzeichen.FormattingEnabled = true;
            this.cboAnzLeerzeichen.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cboAnzLeerzeichen.Location = new System.Drawing.Point(541, 164);
            this.cboAnzLeerzeichen.Name = "cboAnzLeerzeichen";
            this.cboAnzLeerzeichen.Size = new System.Drawing.Size(41, 21);
            this.cboAnzLeerzeichen.TabIndex = 11;
            this.cboAnzLeerzeichen.SelectedIndexChanged += new System.EventHandler(this.cboAnzLeerzeichen_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 734);
            this.Controls.Add(this.cboAnzLeerzeichen);
            this.Controls.Add(this.rbLeerzeichen);
            this.Controls.Add(this.rbTabulator);
            this.Controls.Add(this.rtfRaw);
            this.Controls.Add(this.dgvFunktionen);
            this.Controls.Add(this.ButCopyToClipboard);
            this.Controls.Add(this.ButFormatierungenEntfernen);
            this.Controls.Add(this.ButZwischenablageEinfuegen);
            this.Controls.Add(this.rtfConv);
            this.Controls.Add(this.butConvert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Excel-Formel-Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunktionen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butConvert;
        private System.Windows.Forms.RichTextBox rtfConv;
        private System.Windows.Forms.Button ButZwischenablageEinfuegen;
        private System.Windows.Forms.Button ButFormatierungenEntfernen;
        private System.Windows.Forms.Button ButCopyToClipboard;
        private System.Windows.Forms.DataGridView dgvFunktionen;
        private System.Windows.Forms.RichTextBox rtfRaw;
        private System.Windows.Forms.RadioButton rbTabulator;
        private System.Windows.Forms.RadioButton rbLeerzeichen;
        private System.Windows.Forms.ComboBox cboAnzLeerzeichen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFunktionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
    }
}

