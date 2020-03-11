namespace ArlixAJP
{
    partial class FormDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashBoard));
            this.panelDashBoardBottom = new System.Windows.Forms.Panel();
            this.labelDashBoardDateAndTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.labelDashBoardUserName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.labelDashBoardCurrentUser = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.buttonDashBoardDateAndTime = new System.Windows.Forms.Button();
            this.buttonDashBoardCurrentUser = new System.Windows.Forms.Button();
            this.menuStripDashBoard = new System.Windows.Forms.MenuStrip();
            this.ToolStripSale = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSettingDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripApplicationHide = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripApplicationLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripApplicationClose = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerDashBoard = new System.Windows.Forms.Timer(this.components);
            this.panelDashBoardBottom.SuspendLayout();
            this.menuStripDashBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDashBoardBottom
            // 
            this.panelDashBoardBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelDashBoardBottom.Controls.Add(this.labelDashBoardDateAndTime);
            this.panelDashBoardBottom.Controls.Add(this.labelDashBoardUserName);
            this.panelDashBoardBottom.Controls.Add(this.labelDashBoardCurrentUser);
            this.panelDashBoardBottom.Controls.Add(this.buttonDashBoardDateAndTime);
            this.panelDashBoardBottom.Controls.Add(this.buttonDashBoardCurrentUser);
            this.panelDashBoardBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDashBoardBottom.Location = new System.Drawing.Point(0, 582);
            this.panelDashBoardBottom.Name = "panelDashBoardBottom";
            this.panelDashBoardBottom.Size = new System.Drawing.Size(984, 30);
            this.panelDashBoardBottom.TabIndex = 0;
            // 
            // labelDashBoardDateAndTime
            // 
            this.labelDashBoardDateAndTime.BackColor = System.Drawing.Color.Transparent;
            this.labelDashBoardDateAndTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelDashBoardDateAndTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDashBoardDateAndTime.ForeColor = System.Drawing.Color.White;
            this.labelDashBoardDateAndTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDashBoardDateAndTime.Location = new System.Drawing.Point(745, 0);
            this.labelDashBoardDateAndTime.Name = "labelDashBoardDateAndTime";
            this.labelDashBoardDateAndTime.Size = new System.Drawing.Size(202, 30);
            this.labelDashBoardDateAndTime.TabIndex = 2;
            this.labelDashBoardDateAndTime.Text = "Date And Time";
            this.labelDashBoardDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDashBoardUserName
            // 
            this.labelDashBoardUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelDashBoardUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDashBoardUserName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashBoardUserName.ForeColor = System.Drawing.Color.Yellow;
            this.labelDashBoardUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDashBoardUserName.Location = new System.Drawing.Point(118, 0);
            this.labelDashBoardUserName.Name = "labelDashBoardUserName";
            this.labelDashBoardUserName.Size = new System.Drawing.Size(118, 30);
            this.labelDashBoardUserName.TabIndex = 1;
            this.labelDashBoardUserName.Text = "Cahya Retdiansyah";
            this.labelDashBoardUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDashBoardUserName.TextChanged += new System.EventHandler(this.labelDashBoardUserName_TextChanged);
            // 
            // labelDashBoardCurrentUser
            // 
            this.labelDashBoardCurrentUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelDashBoardCurrentUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDashBoardCurrentUser.ForeColor = System.Drawing.Color.White;
            this.labelDashBoardCurrentUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDashBoardCurrentUser.Location = new System.Drawing.Point(37, 0);
            this.labelDashBoardCurrentUser.Name = "labelDashBoardCurrentUser";
            this.labelDashBoardCurrentUser.Size = new System.Drawing.Size(81, 30);
            this.labelDashBoardCurrentUser.TabIndex = 0;
            this.labelDashBoardCurrentUser.Text = "Current User :";
            this.labelDashBoardCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonDashBoardDateAndTime
            // 
            this.buttonDashBoardDateAndTime.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashBoardDateAndTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDashBoardDateAndTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDashBoardDateAndTime.FlatAppearance.BorderSize = 0;
            this.buttonDashBoardDateAndTime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonDashBoardDateAndTime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonDashBoardDateAndTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashBoardDateAndTime.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashBoardDateAndTime.Image")));
            this.buttonDashBoardDateAndTime.Location = new System.Drawing.Point(947, 0);
            this.buttonDashBoardDateAndTime.Name = "buttonDashBoardDateAndTime";
            this.buttonDashBoardDateAndTime.Size = new System.Drawing.Size(37, 30);
            this.buttonDashBoardDateAndTime.TabIndex = 6;
            this.buttonDashBoardDateAndTime.UseVisualStyleBackColor = false;
            // 
            // buttonDashBoardCurrentUser
            // 
            this.buttonDashBoardCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashBoardCurrentUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDashBoardCurrentUser.FlatAppearance.BorderSize = 0;
            this.buttonDashBoardCurrentUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonDashBoardCurrentUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonDashBoardCurrentUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashBoardCurrentUser.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashBoardCurrentUser.Image")));
            this.buttonDashBoardCurrentUser.Location = new System.Drawing.Point(0, 0);
            this.buttonDashBoardCurrentUser.Name = "buttonDashBoardCurrentUser";
            this.buttonDashBoardCurrentUser.Size = new System.Drawing.Size(37, 30);
            this.buttonDashBoardCurrentUser.TabIndex = 6;
            this.buttonDashBoardCurrentUser.UseVisualStyleBackColor = false;
            // 
            // menuStripDashBoard
            // 
            this.menuStripDashBoard.BackColor = System.Drawing.Color.White;
            this.menuStripDashBoard.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripDashBoard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSale,
            this.ToolStripProduct,
            this.ToolStripAccount,
            this.ToolStripSetting,
            this.ToolStripApplication});
            this.menuStripDashBoard.Location = new System.Drawing.Point(0, 0);
            this.menuStripDashBoard.Name = "menuStripDashBoard";
            this.menuStripDashBoard.Size = new System.Drawing.Size(984, 24);
            this.menuStripDashBoard.TabIndex = 4;
            // 
            // ToolStripSale
            // 
            this.ToolStripSale.ForeColor = System.Drawing.Color.Black;
            this.ToolStripSale.Name = "ToolStripSale";
            this.ToolStripSale.Size = new System.Drawing.Size(41, 20);
            this.ToolStripSale.Text = "Sale";
            // 
            // ToolStripProduct
            // 
            this.ToolStripProduct.ForeColor = System.Drawing.Color.Black;
            this.ToolStripProduct.Name = "ToolStripProduct";
            this.ToolStripProduct.Size = new System.Drawing.Size(61, 20);
            this.ToolStripProduct.Text = "Product";
            this.ToolStripProduct.Click += new System.EventHandler(this.ToolStripProduct_Click);
            // 
            // ToolStripAccount
            // 
            this.ToolStripAccount.ForeColor = System.Drawing.Color.Black;
            this.ToolStripAccount.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripAccount.Image")));
            this.ToolStripAccount.Name = "ToolStripAccount";
            this.ToolStripAccount.Size = new System.Drawing.Size(82, 20);
            this.ToolStripAccount.Text = "Account";
            this.ToolStripAccount.Click += new System.EventHandler(this.ToolStripAccount_Click);
            // 
            // ToolStripSetting
            // 
            this.ToolStripSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSettingDataBase});
            this.ToolStripSetting.ForeColor = System.Drawing.Color.Black;
            this.ToolStripSetting.Name = "ToolStripSetting";
            this.ToolStripSetting.Size = new System.Drawing.Size(57, 20);
            this.ToolStripSetting.Text = "Setting";
            // 
            // ToolStripSettingDataBase
            // 
            this.ToolStripSettingDataBase.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripSettingDataBase.Image")));
            this.ToolStripSettingDataBase.Name = "ToolStripSettingDataBase";
            this.ToolStripSettingDataBase.Size = new System.Drawing.Size(180, 22);
            this.ToolStripSettingDataBase.Text = "DataBase";
            this.ToolStripSettingDataBase.Click += new System.EventHandler(this.ToolStripSettingDataBase_Click);
            // 
            // ToolStripApplication
            // 
            this.ToolStripApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripApplicationHide,
            this.ToolStripApplicationLogOut,
            this.ToolStripApplicationClose});
            this.ToolStripApplication.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripApplication.ForeColor = System.Drawing.Color.Black;
            this.ToolStripApplication.Name = "ToolStripApplication";
            this.ToolStripApplication.Size = new System.Drawing.Size(82, 20);
            this.ToolStripApplication.Text = "Application";
            // 
            // ToolStripApplicationHide
            // 
            this.ToolStripApplicationHide.ForeColor = System.Drawing.Color.Green;
            this.ToolStripApplicationHide.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripApplicationHide.Image")));
            this.ToolStripApplicationHide.Name = "ToolStripApplicationHide";
            this.ToolStripApplicationHide.Size = new System.Drawing.Size(180, 22);
            this.ToolStripApplicationHide.Text = "Hide";
            this.ToolStripApplicationHide.Click += new System.EventHandler(this.ToolStripApplicationHide_Click);
            // 
            // ToolStripApplicationLogOut
            // 
            this.ToolStripApplicationLogOut.ForeColor = System.Drawing.Color.OrangeRed;
            this.ToolStripApplicationLogOut.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripApplicationLogOut.Image")));
            this.ToolStripApplicationLogOut.Name = "ToolStripApplicationLogOut";
            this.ToolStripApplicationLogOut.Size = new System.Drawing.Size(180, 22);
            this.ToolStripApplicationLogOut.Text = "Log Out";
            this.ToolStripApplicationLogOut.Click += new System.EventHandler(this.ToolStripApplicationLogOut_Click);
            // 
            // ToolStripApplicationClose
            // 
            this.ToolStripApplicationClose.ForeColor = System.Drawing.Color.Red;
            this.ToolStripApplicationClose.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripApplicationClose.Image")));
            this.ToolStripApplicationClose.Name = "ToolStripApplicationClose";
            this.ToolStripApplicationClose.Size = new System.Drawing.Size(180, 22);
            this.ToolStripApplicationClose.Text = "Close";
            this.ToolStripApplicationClose.Click += new System.EventHandler(this.ToolStripApplicationClose_Click);
            // 
            // TimerDashBoard
            // 
            this.TimerDashBoard.Interval = 1000;
            this.TimerDashBoard.Tick += new System.EventHandler(this.TimerDashBoard_Tick);
            // 
            // FormDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.menuStripDashBoard);
            this.Controls.Add(this.panelDashBoardBottom);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arlix AJP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDashBoard_FormClosing);
            this.Load += new System.EventHandler(this.FormDashBoard_Load);
            this.SizeChanged += new System.EventHandler(this.FormDashBoard_SizeChanged);
            this.panelDashBoardBottom.ResumeLayout(false);
            this.menuStripDashBoard.ResumeLayout(false);
            this.menuStripDashBoard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDashBoardBottom;
        private Bunifu.Framework.UI.BunifuCustomLabel labelDashBoardCurrentUser;
        private Bunifu.Framework.UI.BunifuCustomLabel labelDashBoardDateAndTime;
        private System.Windows.Forms.Button buttonDashBoardDateAndTime;
        private System.Windows.Forms.Button buttonDashBoardCurrentUser;
        private System.Windows.Forms.Timer TimerDashBoard;
        public Bunifu.Framework.UI.BunifuCustomLabel labelDashBoardUserName;
        public System.Windows.Forms.MenuStrip menuStripDashBoard;
        public System.Windows.Forms.ToolStripMenuItem ToolStripSale;
        public System.Windows.Forms.ToolStripMenuItem ToolStripProduct;
        public System.Windows.Forms.ToolStripMenuItem ToolStripAccount;
        public System.Windows.Forms.ToolStripMenuItem ToolStripSetting;
        public System.Windows.Forms.ToolStripMenuItem ToolStripSettingDataBase;
        public System.Windows.Forms.ToolStripMenuItem ToolStripApplication;
        public System.Windows.Forms.ToolStripMenuItem ToolStripApplicationHide;
        public System.Windows.Forms.ToolStripMenuItem ToolStripApplicationLogOut;
        public System.Windows.Forms.ToolStripMenuItem ToolStripApplicationClose;
    }
}

