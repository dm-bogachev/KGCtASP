namespace KGCtASP
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.bOpenFile = new System.Windows.Forms.Button();
            this.lFilePath = new System.Windows.Forms.Label();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lbGCodeData = new System.Windows.Forms.ListBox();
            this.lbASData = new System.Windows.Forms.ListBox();
            this.bParse = new System.Windows.Forms.Button();
            this.lGCodeData = new System.Windows.Forms.Label();
            this.lASData = new System.Windows.Forms.Label();
            this.pbFileLoaded = new System.Windows.Forms.ProgressBar();
            this.lbFileLoaded = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.lFileParsed = new System.Windows.Forms.Label();
            this.pbFileParsed = new System.Windows.Forms.ProgressBar();
            this.ofdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.cbNoFeeder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(75, 12);
            this.tbFilePath.Multiline = true;
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(346, 23);
            this.tbFilePath.TabIndex = 0;
            // 
            // bOpenFile
            // 
            this.bOpenFile.Location = new System.Drawing.Point(427, 12);
            this.bOpenFile.Name = "bOpenFile";
            this.bOpenFile.Size = new System.Drawing.Size(75, 23);
            this.bOpenFile.TabIndex = 1;
            this.bOpenFile.Text = "Open File";
            this.bOpenFile.UseVisualStyleBackColor = true;
            this.bOpenFile.Click += new System.EventHandler(this.bOpenFile_Click);
            // 
            // lFilePath
            // 
            this.lFilePath.AutoSize = true;
            this.lFilePath.Location = new System.Drawing.Point(12, 17);
            this.lFilePath.Name = "lFilePath";
            this.lFilePath.Size = new System.Drawing.Size(50, 13);
            this.lFilePath.TabIndex = 2;
            this.lFilePath.Text = "File path:";
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.FileName = "openFileDialog1";
            this.ofdOpenFile.Filter = "GCode files|*.gcode|txt files|*.txt|All files|*.*";
            this.ofdOpenFile.RestoreDirectory = true;
            // 
            // lbGCodeData
            // 
            this.lbGCodeData.FormattingEnabled = true;
            this.lbGCodeData.HorizontalScrollbar = true;
            this.lbGCodeData.Location = new System.Drawing.Point(15, 110);
            this.lbGCodeData.Name = "lbGCodeData";
            this.lbGCodeData.Size = new System.Drawing.Size(308, 446);
            this.lbGCodeData.TabIndex = 3;
            // 
            // lbASData
            // 
            this.lbASData.FormattingEnabled = true;
            this.lbASData.HorizontalScrollbar = true;
            this.lbASData.Location = new System.Drawing.Point(329, 110);
            this.lbASData.Name = "lbASData";
            this.lbASData.Size = new System.Drawing.Size(335, 446);
            this.lbASData.TabIndex = 4;
            // 
            // bParse
            // 
            this.bParse.Enabled = false;
            this.bParse.Location = new System.Drawing.Point(508, 12);
            this.bParse.Name = "bParse";
            this.bParse.Size = new System.Drawing.Size(75, 23);
            this.bParse.TabIndex = 5;
            this.bParse.Text = "Parse";
            this.bParse.UseVisualStyleBackColor = true;
            this.bParse.Click += new System.EventHandler(this.bParse_Click);
            // 
            // lGCodeData
            // 
            this.lGCodeData.AutoSize = true;
            this.lGCodeData.Location = new System.Drawing.Point(12, 94);
            this.lGCodeData.Name = "lGCodeData";
            this.lGCodeData.Size = new System.Drawing.Size(140, 13);
            this.lGCodeData.TabIndex = 6;
            this.lGCodeData.Text = "GCode data (first 1024 lines)";
            // 
            // lASData
            // 
            this.lASData.AutoSize = true;
            this.lASData.Location = new System.Drawing.Point(329, 94);
            this.lASData.Name = "lASData";
            this.lASData.Size = new System.Drawing.Size(121, 13);
            this.lASData.TabIndex = 7;
            this.lASData.Text = "AS data (first 1024 lines)";
            // 
            // pbFileLoaded
            // 
            this.pbFileLoaded.Location = new System.Drawing.Point(81, 54);
            this.pbFileLoaded.Name = "pbFileLoaded";
            this.pbFileLoaded.Size = new System.Drawing.Size(242, 23);
            this.pbFileLoaded.TabIndex = 8;
            // 
            // lbFileLoaded
            // 
            this.lbFileLoaded.AutoSize = true;
            this.lbFileLoaded.Location = new System.Drawing.Point(12, 60);
            this.lbFileLoaded.Name = "lbFileLoaded";
            this.lbFileLoaded.Size = new System.Drawing.Size(63, 13);
            this.lbFileLoaded.TabIndex = 10;
            this.lbFileLoaded.Text = "File loading:";
            // 
            // bSave
            // 
            this.bSave.Enabled = false;
            this.bSave.Location = new System.Drawing.Point(589, 12);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 11;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lFileParsed
            // 
            this.lFileParsed.AutoSize = true;
            this.lFileParsed.Location = new System.Drawing.Point(329, 60);
            this.lFileParsed.Name = "lFileParsed";
            this.lFileParsed.Size = new System.Drawing.Size(63, 13);
            this.lFileParsed.TabIndex = 13;
            this.lFileParsed.Text = "File parsing:";
            // 
            // pbFileParsed
            // 
            this.pbFileParsed.Location = new System.Drawing.Point(398, 54);
            this.pbFileParsed.Name = "pbFileParsed";
            this.pbFileParsed.Size = new System.Drawing.Size(266, 23);
            this.pbFileParsed.TabIndex = 12;
            // 
            // ofdSaveFile
            // 
            this.ofdSaveFile.Filter = "AS Sourcecode|*as";
            // 
            // cbNoFeeder
            // 
            this.cbNoFeeder.AutoSize = true;
            this.cbNoFeeder.Checked = true;
            this.cbNoFeeder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNoFeeder.Location = new System.Drawing.Point(541, 87);
            this.cbNoFeeder.Name = "cbNoFeeder";
            this.cbNoFeeder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbNoFeeder.Size = new System.Drawing.Size(123, 17);
            this.cbNoFeeder.TabIndex = 14;
            this.cbNoFeeder.Text = "Disable feeder value";
            this.cbNoFeeder.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 577);
            this.Controls.Add(this.cbNoFeeder);
            this.Controls.Add(this.lFileParsed);
            this.Controls.Add(this.pbFileParsed);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lbFileLoaded);
            this.Controls.Add(this.pbFileLoaded);
            this.Controls.Add(this.lASData);
            this.Controls.Add(this.lGCodeData);
            this.Controls.Add(this.bParse);
            this.Controls.Add(this.lbASData);
            this.Controls.Add(this.lbGCodeData);
            this.Controls.Add(this.lFilePath);
            this.Controls.Add(this.bOpenFile);
            this.Controls.Add(this.tbFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Kawasaki GCode to AS Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button bOpenFile;
        private System.Windows.Forms.Label lFilePath;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.ListBox lbGCodeData;
        private System.Windows.Forms.ListBox lbASData;
        private System.Windows.Forms.Button bParse;
        private System.Windows.Forms.Label lGCodeData;
        private System.Windows.Forms.Label lASData;
        private System.Windows.Forms.Label lbFileLoaded;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ProgressBar pbFileLoaded;
        private System.Windows.Forms.Label lFileParsed;
        private System.Windows.Forms.ProgressBar pbFileParsed;
        private System.Windows.Forms.SaveFileDialog ofdSaveFile;
        private System.Windows.Forms.CheckBox cbNoFeeder;
    }
}

