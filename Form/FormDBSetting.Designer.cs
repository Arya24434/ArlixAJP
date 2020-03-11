namespace ArlixAJP
{
    partial class FormDBSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDBSetting));
            this.buttonDBSettingDone = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonDBSettingTest = new System.Windows.Forms.Button();
            this.groupBoxDBSettingSelectDataBase = new System.Windows.Forms.GroupBox();
            this.comboBoxDBSettingSelectDataBase = new System.Windows.Forms.ComboBox();
            this.buttonDBSettingSelectDataBase = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxDBSettingShowPassWord = new System.Windows.Forms.CheckBox();
            this.labelDBSettingPassWord = new System.Windows.Forms.Label();
            this.textBoxDBSettingPassWord = new System.Windows.Forms.TextBox();
            this.textBoxDBSettingUserName = new System.Windows.Forms.TextBox();
            this.labelDBSettingUserName = new System.Windows.Forms.Label();
            this.checkBoxDBSettingWinSecurity = new System.Windows.Forms.CheckBox();
            this.groupBoxDBSettingSelectServer = new System.Windows.Forms.GroupBox();
            this.comboBoxDBSettingSelectServer = new System.Windows.Forms.ComboBox();
            this.errorProviderDBSetting = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxDBSettingSelectDataBase.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxDBSettingSelectServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDBSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDBSettingDone
            // 
            this.buttonDBSettingDone.BackColor = System.Drawing.Color.Green;
            this.buttonDBSettingDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDBSettingDone.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDBSettingDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonDBSettingDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonDBSettingDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDBSettingDone.ForeColor = System.Drawing.Color.White;
            this.buttonDBSettingDone.Location = new System.Drawing.Point(224, 295);
            this.buttonDBSettingDone.Name = "buttonDBSettingDone";
            this.buttonDBSettingDone.Size = new System.Drawing.Size(88, 23);
            this.buttonDBSettingDone.TabIndex = 14;
            this.buttonDBSettingDone.Text = "Done";
            this.buttonDBSettingDone.UseVisualStyleBackColor = false;
            this.buttonDBSettingDone.Click += new System.EventHandler(this.buttonDBSettingDone_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Green;
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.ForeColor = System.Drawing.Color.White;
            this.buttonReset.Location = new System.Drawing.Point(118, 295);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(88, 23);
            this.buttonReset.TabIndex = 15;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonDBSettingTest
            // 
            this.buttonDBSettingTest.BackColor = System.Drawing.Color.Green;
            this.buttonDBSettingTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDBSettingTest.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDBSettingTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonDBSettingTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonDBSettingTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDBSettingTest.ForeColor = System.Drawing.Color.White;
            this.buttonDBSettingTest.Location = new System.Drawing.Point(12, 295);
            this.buttonDBSettingTest.Name = "buttonDBSettingTest";
            this.buttonDBSettingTest.Size = new System.Drawing.Size(88, 23);
            this.buttonDBSettingTest.TabIndex = 16;
            this.buttonDBSettingTest.Text = "Test";
            this.buttonDBSettingTest.UseVisualStyleBackColor = false;
            this.buttonDBSettingTest.Click += new System.EventHandler(this.buttonDBSettingTest_Click);
            // 
            // groupBoxDBSettingSelectDataBase
            // 
            this.groupBoxDBSettingSelectDataBase.BackColor = System.Drawing.Color.Green;
            this.groupBoxDBSettingSelectDataBase.Controls.Add(this.comboBoxDBSettingSelectDataBase);
            this.groupBoxDBSettingSelectDataBase.Controls.Add(this.buttonDBSettingSelectDataBase);
            this.groupBoxDBSettingSelectDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxDBSettingSelectDataBase.ForeColor = System.Drawing.Color.White;
            this.groupBoxDBSettingSelectDataBase.Location = new System.Drawing.Point(13, 225);
            this.groupBoxDBSettingSelectDataBase.Name = "groupBoxDBSettingSelectDataBase";
            this.groupBoxDBSettingSelectDataBase.Size = new System.Drawing.Size(300, 59);
            this.groupBoxDBSettingSelectDataBase.TabIndex = 13;
            this.groupBoxDBSettingSelectDataBase.TabStop = false;
            this.groupBoxDBSettingSelectDataBase.Text = "Select SQL DataBase Name";
            // 
            // comboBoxDBSettingSelectDataBase
            // 
            this.comboBoxDBSettingSelectDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDBSettingSelectDataBase.FormattingEnabled = true;
            this.comboBoxDBSettingSelectDataBase.Location = new System.Drawing.Point(19, 21);
            this.comboBoxDBSettingSelectDataBase.Name = "comboBoxDBSettingSelectDataBase";
            this.comboBoxDBSettingSelectDataBase.Size = new System.Drawing.Size(174, 23);
            this.comboBoxDBSettingSelectDataBase.TabIndex = 3;
            this.comboBoxDBSettingSelectDataBase.Click += new System.EventHandler(this.comboBoxDBSettingSelectDataBase_Click);
            // 
            // buttonDBSettingSelectDataBase
            // 
            this.buttonDBSettingSelectDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDBSettingSelectDataBase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDBSettingSelectDataBase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonDBSettingSelectDataBase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonDBSettingSelectDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDBSettingSelectDataBase.Location = new System.Drawing.Point(211, 21);
            this.buttonDBSettingSelectDataBase.Name = "buttonDBSettingSelectDataBase";
            this.buttonDBSettingSelectDataBase.Size = new System.Drawing.Size(69, 23);
            this.buttonDBSettingSelectDataBase.TabIndex = 1;
            this.buttonDBSettingSelectDataBase.Text = "Find";
            this.buttonDBSettingSelectDataBase.UseVisualStyleBackColor = true;
            this.buttonDBSettingSelectDataBase.Click += new System.EventHandler(this.buttonDBSettingSelectDataBase_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Green;
            this.groupBox2.Controls.Add(this.checkBoxDBSettingShowPassWord);
            this.groupBox2.Controls.Add(this.labelDBSettingPassWord);
            this.groupBox2.Controls.Add(this.textBoxDBSettingPassWord);
            this.groupBox2.Controls.Add(this.textBoxDBSettingUserName);
            this.groupBox2.Controls.Add(this.labelDBSettingUserName);
            this.groupBox2.Controls.Add(this.checkBoxDBSettingWinSecurity);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 142);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Windows Security";
            // 
            // checkBoxDBSettingShowPassWord
            // 
            this.checkBoxDBSettingShowPassWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDBSettingShowPassWord.Enabled = false;
            this.checkBoxDBSettingShowPassWord.ForeColor = System.Drawing.Color.Black;
            this.checkBoxDBSettingShowPassWord.Location = new System.Drawing.Point(106, 110);
            this.checkBoxDBSettingShowPassWord.Name = "checkBoxDBSettingShowPassWord";
            this.checkBoxDBSettingShowPassWord.Size = new System.Drawing.Size(150, 22);
            this.checkBoxDBSettingShowPassWord.TabIndex = 9;
            this.checkBoxDBSettingShowPassWord.Text = "Show Password";
            this.checkBoxDBSettingShowPassWord.UseVisualStyleBackColor = true;
            this.checkBoxDBSettingShowPassWord.CheckedChanged += new System.EventHandler(this.checkBoxDBSettingShowPassWord_CheckedChanged);
            // 
            // labelDBSettingPassWord
            // 
            this.labelDBSettingPassWord.ForeColor = System.Drawing.Color.Black;
            this.labelDBSettingPassWord.Location = new System.Drawing.Point(16, 80);
            this.labelDBSettingPassWord.Name = "labelDBSettingPassWord";
            this.labelDBSettingPassWord.Size = new System.Drawing.Size(84, 22);
            this.labelDBSettingPassWord.TabIndex = 11;
            this.labelDBSettingPassWord.Text = "Password";
            this.labelDBSettingPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDBSettingPassWord
            // 
            this.textBoxDBSettingPassWord.BackColor = System.Drawing.Color.Green;
            this.textBoxDBSettingPassWord.Enabled = false;
            this.textBoxDBSettingPassWord.Location = new System.Drawing.Point(106, 80);
            this.textBoxDBSettingPassWord.Name = "textBoxDBSettingPassWord";
            this.textBoxDBSettingPassWord.Size = new System.Drawing.Size(175, 22);
            this.textBoxDBSettingPassWord.TabIndex = 10;
            this.textBoxDBSettingPassWord.UseSystemPasswordChar = true;
            // 
            // textBoxDBSettingUserName
            // 
            this.textBoxDBSettingUserName.BackColor = System.Drawing.Color.Green;
            this.textBoxDBSettingUserName.Enabled = false;
            this.textBoxDBSettingUserName.Location = new System.Drawing.Point(106, 49);
            this.textBoxDBSettingUserName.Name = "textBoxDBSettingUserName";
            this.textBoxDBSettingUserName.Size = new System.Drawing.Size(175, 22);
            this.textBoxDBSettingUserName.TabIndex = 7;
            this.textBoxDBSettingUserName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDBSettingUserName_Validating);
            // 
            // labelDBSettingUserName
            // 
            this.labelDBSettingUserName.ForeColor = System.Drawing.Color.Black;
            this.labelDBSettingUserName.Location = new System.Drawing.Point(16, 49);
            this.labelDBSettingUserName.Name = "labelDBSettingUserName";
            this.labelDBSettingUserName.Size = new System.Drawing.Size(84, 22);
            this.labelDBSettingUserName.TabIndex = 8;
            this.labelDBSettingUserName.Text = "User Name";
            this.labelDBSettingUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxDBSettingWinSecurity
            // 
            this.checkBoxDBSettingWinSecurity.Checked = true;
            this.checkBoxDBSettingWinSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDBSettingWinSecurity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDBSettingWinSecurity.Location = new System.Drawing.Point(19, 21);
            this.checkBoxDBSettingWinSecurity.Name = "checkBoxDBSettingWinSecurity";
            this.checkBoxDBSettingWinSecurity.Size = new System.Drawing.Size(150, 22);
            this.checkBoxDBSettingWinSecurity.TabIndex = 6;
            this.checkBoxDBSettingWinSecurity.Text = "Use Windows Security";
            this.checkBoxDBSettingWinSecurity.UseVisualStyleBackColor = true;
            this.checkBoxDBSettingWinSecurity.CheckedChanged += new System.EventHandler(this.checkBoxDBSettingWinSecurity_CheckedChanged);
            // 
            // groupBoxDBSettingSelectServer
            // 
            this.groupBoxDBSettingSelectServer.BackColor = System.Drawing.Color.Green;
            this.groupBoxDBSettingSelectServer.Controls.Add(this.comboBoxDBSettingSelectServer);
            this.groupBoxDBSettingSelectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxDBSettingSelectServer.ForeColor = System.Drawing.Color.White;
            this.groupBoxDBSettingSelectServer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDBSettingSelectServer.Name = "groupBoxDBSettingSelectServer";
            this.groupBoxDBSettingSelectServer.Size = new System.Drawing.Size(300, 59);
            this.groupBoxDBSettingSelectServer.TabIndex = 11;
            this.groupBoxDBSettingSelectServer.TabStop = false;
            this.groupBoxDBSettingSelectServer.Text = "Select SQL Address";
            // 
            // comboBoxDBSettingSelectServer
            // 
            this.comboBoxDBSettingSelectServer.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxDBSettingSelectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDBSettingSelectServer.FormattingEnabled = true;
            this.comboBoxDBSettingSelectServer.Location = new System.Drawing.Point(19, 21);
            this.comboBoxDBSettingSelectServer.Name = "comboBoxDBSettingSelectServer";
            this.comboBoxDBSettingSelectServer.Size = new System.Drawing.Size(262, 23);
            this.comboBoxDBSettingSelectServer.TabIndex = 3;
            this.comboBoxDBSettingSelectServer.Text = "AJP_OFFICE\\SQLAJP";
            this.comboBoxDBSettingSelectServer.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxDBSettingSelectServer_Validating);
            // 
            // errorProviderDBSetting
            // 
            this.errorProviderDBSetting.ContainerControl = this;
            this.errorProviderDBSetting.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProviderDBSetting.Icon")));
            // 
            // FormDBSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(323, 328);
            this.Controls.Add(this.buttonDBSettingDone);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonDBSettingTest);
            this.Controls.Add(this.groupBoxDBSettingSelectDataBase);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxDBSettingSelectServer);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDBSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Data Base";
            this.Load += new System.EventHandler(this.FormDBSetting_Load);
            this.groupBoxDBSettingSelectDataBase.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxDBSettingSelectServer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDBSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDBSettingDone;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonDBSettingTest;
        private System.Windows.Forms.GroupBox groupBoxDBSettingSelectDataBase;
        private System.Windows.Forms.ComboBox comboBoxDBSettingSelectDataBase;
        private System.Windows.Forms.Button buttonDBSettingSelectDataBase;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.CheckBox checkBoxDBSettingShowPassWord;
        internal System.Windows.Forms.Label labelDBSettingPassWord;
        internal System.Windows.Forms.TextBox textBoxDBSettingPassWord;
        internal System.Windows.Forms.TextBox textBoxDBSettingUserName;
        internal System.Windows.Forms.Label labelDBSettingUserName;
        internal System.Windows.Forms.CheckBox checkBoxDBSettingWinSecurity;
        private System.Windows.Forms.GroupBox groupBoxDBSettingSelectServer;
        private System.Windows.Forms.ComboBox comboBoxDBSettingSelectServer;
        private System.Windows.Forms.ErrorProvider errorProviderDBSetting;
    }
}