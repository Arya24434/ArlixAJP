namespace ArlixAJP
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.LabelLoginPTAjp = new System.Windows.Forms.Label();
            this.TextBoxLoginPassWord = new System.Windows.Forms.TextBox();
            this.TextBoxLoginUserName = new System.Windows.Forms.TextBox();
            this.LabelLoginPassword = new System.Windows.Forms.Label();
            this.LabelLoginUserName = new System.Windows.Forms.Label();
            this.CheckBoxLoginShowPassword = new System.Windows.Forms.CheckBox();
            this.ButtonLoginClose = new System.Windows.Forms.Button();
            this.ButtonLoginLogin = new System.Windows.Forms.Button();
            this.ButtonLoginLogo = new System.Windows.Forms.Button();
            this.errorProviderLogin = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelLoginPTAjp
            // 
            this.LabelLoginPTAjp.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLoginPTAjp.ForeColor = System.Drawing.Color.Green;
            this.LabelLoginPTAjp.Location = new System.Drawing.Point(13, 105);
            this.LabelLoginPTAjp.Name = "LabelLoginPTAjp";
            this.LabelLoginPTAjp.Size = new System.Drawing.Size(285, 26);
            this.LabelLoginPTAjp.TabIndex = 24;
            this.LabelLoginPTAjp.Text = "| PT. Adent Jaya Plasindo |";
            // 
            // TextBoxLoginPassWord
            // 
            this.TextBoxLoginPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxLoginPassWord.Location = new System.Drawing.Point(97, 184);
            this.TextBoxLoginPassWord.Name = "TextBoxLoginPassWord";
            this.TextBoxLoginPassWord.Size = new System.Drawing.Size(177, 22);
            this.TextBoxLoginPassWord.TabIndex = 18;
            this.TextBoxLoginPassWord.Text = "Admin";
            this.TextBoxLoginPassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLoginPassWord.UseSystemPasswordChar = true;
            this.TextBoxLoginPassWord.TextChanged += new System.EventHandler(this.TextBoxLoginPassWord_TextChanged);
            this.TextBoxLoginPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxLoginPassWord_KeyDown);
            this.TextBoxLoginPassWord.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxLoginPassWord_Validating);
            // 
            // TextBoxLoginUserName
            // 
            this.TextBoxLoginUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxLoginUserName.Location = new System.Drawing.Point(97, 152);
            this.TextBoxLoginUserName.Name = "TextBoxLoginUserName";
            this.TextBoxLoginUserName.Size = new System.Drawing.Size(177, 22);
            this.TextBoxLoginUserName.TabIndex = 17;
            this.TextBoxLoginUserName.Text = "Admin";
            this.TextBoxLoginUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxLoginUserName.TextChanged += new System.EventHandler(this.TextBoxLoginUserName_TextChanged);
            this.TextBoxLoginUserName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxLoginUserName_Validating);
            // 
            // LabelLoginPassword
            // 
            this.LabelLoginPassword.Location = new System.Drawing.Point(26, 184);
            this.LabelLoginPassword.Name = "LabelLoginPassword";
            this.LabelLoginPassword.Size = new System.Drawing.Size(65, 22);
            this.LabelLoginPassword.TabIndex = 20;
            this.LabelLoginPassword.Text = "Password";
            this.LabelLoginPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelLoginUserName
            // 
            this.LabelLoginUserName.Location = new System.Drawing.Point(25, 152);
            this.LabelLoginUserName.Name = "LabelLoginUserName";
            this.LabelLoginUserName.Size = new System.Drawing.Size(65, 22);
            this.LabelLoginUserName.TabIndex = 21;
            this.LabelLoginUserName.Text = "User Name";
            this.LabelLoginUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBoxLoginShowPassword
            // 
            this.CheckBoxLoginShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLoginShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxLoginShowPassword.ForeColor = System.Drawing.Color.Navy;
            this.CheckBoxLoginShowPassword.Location = new System.Drawing.Point(97, 212);
            this.CheckBoxLoginShowPassword.Name = "CheckBoxLoginShowPassword";
            this.CheckBoxLoginShowPassword.Size = new System.Drawing.Size(161, 19);
            this.CheckBoxLoginShowPassword.TabIndex = 22;
            this.CheckBoxLoginShowPassword.Text = "Check To Show Password";
            this.CheckBoxLoginShowPassword.UseVisualStyleBackColor = true;
            this.CheckBoxLoginShowPassword.CheckedChanged += new System.EventHandler(this.CheckBoxLoginShowPassword_CheckedChanged);
            // 
            // ButtonLoginClose
            // 
            this.ButtonLoginClose.BackColor = System.Drawing.Color.Navy;
            this.ButtonLoginClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoginClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonLoginClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.ButtonLoginClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.ButtonLoginClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoginClose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLoginClose.ForeColor = System.Drawing.Color.White;
            this.ButtonLoginClose.Location = new System.Drawing.Point(24, 250);
            this.ButtonLoginClose.Name = "ButtonLoginClose";
            this.ButtonLoginClose.Size = new System.Drawing.Size(80, 30);
            this.ButtonLoginClose.TabIndex = 23;
            this.ButtonLoginClose.Text = "Close";
            this.ButtonLoginClose.UseVisualStyleBackColor = false;
            this.ButtonLoginClose.Click += new System.EventHandler(this.ButtonLoginClose_Click);
            // 
            // ButtonLoginLogin
            // 
            this.ButtonLoginLogin.BackColor = System.Drawing.Color.Green;
            this.ButtonLoginLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoginLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonLoginLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.ButtonLoginLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.ButtonLoginLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoginLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLoginLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLoginLogin.Location = new System.Drawing.Point(194, 250);
            this.ButtonLoginLogin.Name = "ButtonLoginLogin";
            this.ButtonLoginLogin.Size = new System.Drawing.Size(80, 30);
            this.ButtonLoginLogin.TabIndex = 19;
            this.ButtonLoginLogin.Text = "Login";
            this.ButtonLoginLogin.UseVisualStyleBackColor = false;
            this.ButtonLoginLogin.Click += new System.EventHandler(this.ButtonLoginLogin_Click);
            // 
            // ButtonLoginLogo
            // 
            this.ButtonLoginLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoginLogo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonLoginLogo.FlatAppearance.BorderSize = 0;
            this.ButtonLoginLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.ButtonLoginLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonLoginLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoginLogo.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLoginLogo.Image")));
            this.ButtonLoginLogo.Location = new System.Drawing.Point(111, 15);
            this.ButtonLoginLogo.Name = "ButtonLoginLogo";
            this.ButtonLoginLogo.Size = new System.Drawing.Size(80, 70);
            this.ButtonLoginLogo.TabIndex = 16;
            this.ButtonLoginLogo.TabStop = false;
            this.ButtonLoginLogo.UseVisualStyleBackColor = true;
            // 
            // errorProviderLogin
            // 
            this.errorProviderLogin.ContainerControl = this;
            this.errorProviderLogin.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProviderLogin.Icon")));
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 296);
            this.Controls.Add(this.LabelLoginPTAjp);
            this.Controls.Add(this.TextBoxLoginPassWord);
            this.Controls.Add(this.TextBoxLoginUserName);
            this.Controls.Add(this.LabelLoginPassword);
            this.Controls.Add(this.LabelLoginUserName);
            this.Controls.Add(this.CheckBoxLoginShowPassword);
            this.Controls.Add(this.ButtonLoginClose);
            this.Controls.Add(this.ButtonLoginLogin);
            this.Controls.Add(this.ButtonLoginLogo);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelLoginPTAjp;
        private System.Windows.Forms.TextBox TextBoxLoginPassWord;
        private System.Windows.Forms.TextBox TextBoxLoginUserName;
        private System.Windows.Forms.Label LabelLoginPassword;
        private System.Windows.Forms.Label LabelLoginUserName;
        private System.Windows.Forms.CheckBox CheckBoxLoginShowPassword;
        private System.Windows.Forms.Button ButtonLoginClose;
        private System.Windows.Forms.Button ButtonLoginLogin;
        private System.Windows.Forms.Button ButtonLoginLogo;
        private System.Windows.Forms.ErrorProvider errorProviderLogin;
    }
}