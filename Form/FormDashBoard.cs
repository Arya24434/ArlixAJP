using ArlixAJP.Properties;
using Arlix_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Arlix_SQL;

namespace ArlixAJP
{
    public partial class FormDashBoard : Form
    {
        #region Additional Set
        internal static FormDashBoard Forms; // << Remote Member
        SQLGetData SQLDataBase_UI = new SQLGetData();
        public string UserAccount = Settings.Default.UserAccount; // << Current User

        #region Change MenuStrip Colour        
        private class DashBoardMenuStripNewColors : ToolStripProfessionalRenderer
        {
            public DashBoardMenuStripNewColors() : base(new Colors()) { }
        }

        private class Colors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.White; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Green; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.White; }
            }
        }
        #endregion Change MenuStrip Colour   

        #region Code To ShowForm Inside DashBoard
        private void CloseAllChildForm()
        {
            #region Close All From Inside DashBoard
            foreach (Form form in this.MdiChildren)
            {
                if (!form.Focused)
                {
                    form.Visible = false;
                    form.Dispose();
                }
            }
            #endregion Close All From Inside DashBoard
        }

        private void ShowFormDBSetting()
        {
            #region Show Form DBSetting
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormDBSetting))
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }            

            FormDBSetting formDBSetting = new FormDBSetting { MdiParent = this };
            formDBSetting.Show();
            formDBSetting.Activate();
            formDBSetting.Focus();

            #endregion Show Form DBSetting
        }

        private void ShowFormLogin()
        {
            #region Show Form Login
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormLogin)) //<<FormName
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }

            FormLogin formLogin = new FormLogin { MdiParent = this };
            formLogin.Show();
            formLogin.Activate();
            formLogin.Focus();
            #endregion Show Form Login
        }

        private void ShowFormAccount()
        {
            #region Show Form Account
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormAccount)) //<<FormName
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    form.Focus();
                    return;
                }
            }

            FormAccount formAccount = new FormAccount { MdiParent = this };
            formAccount.Show();
            formAccount.Activate();
            formAccount.Focus();
            #endregion Show Form Account
        }
        #endregion

        #region Disable Function Before Login
        private void CheckUserAccount()
        {
            if (Settings.Default.UserAccount == string.Empty)
            {
                ToolStripSale.Enabled = false;
                ToolStripProduct.Enabled = false;
                ToolStripAccount.Enabled = false;
            }
            else
            {
                ToolStripSale.Enabled = true;
                ToolStripProduct.Enabled = true;
                ToolStripAccount.Enabled = true;
            }
        }
        #endregion

        public FormDashBoard()
        {
            #region Preparing Form DashBoard
            InitializeComponent();
            Forms = this;
            menuStripDashBoard.Renderer = new DashBoardMenuStripNewColors();
            #endregion Preparing Form DashBoard
        }
        #endregion

        #region Action Set
        private void FormDashBoard_Load(object sender, EventArgs e)
        {
            TimerDashBoard.Enabled = true;

            #region Set BackGround Image MDI Container
            string DashBoardBackImage = Settings.Default.DashBoardBackImage;
            Image image;
            if (ClassHelper.IsFileExist(DashBoardBackImage) != true)
            {
                image = new Bitmap(DashBoardBackImage);
            }
            else
            {
                MessageBox.Show("Error! >> " + DashBoardBackImage +
                "\n \nFile BackGround Image Not Found! \n \n" +
                "Back To Default BackGround", "DashBoard BackGround File Path", MessageBoxButtons.OK, MessageBoxIcon.Error);

                image = new Bitmap(1000, 1000);
                Graphics graphics = Graphics.FromImage(image);
                Region region = new Region(new Rectangle(0, 0, 1000, 1000));
                graphics.FillRegion(Brushes.White, region);
            }

            try
            {
                Controls.OfType<MdiClient>().FirstOrDefault().BackgroundImage = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Set BackGround Container \n \n"
                    + ex.Message, "Set BackGround DashBoard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Check Connection And Login
            if (SQLDataBase_UI.IsServerConnected() != true)
            {
                MessageBox.Show("Can't Connect To DataBase!\n\nPlease Setting DataBase First!", "DataBase Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                ShowFormDBSetting();

            }
            else
            {              

                CheckUserAccount();

                ShowFormLogin();

            }
            #endregion Check Connection And Login
        }

        private void TimerDashBoard_Tick(object sender, EventArgs e)
        {
            labelDashBoardDateAndTime.Text = DateTime.Now.ToString("dddd, dd / MMMM / yyyy, > HH:mm <");
        }

        private void FormDashBoard_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void FormDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(
            "Are You Sure Want To Close This Application?", "Arlix AJP",
            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                TimerDashBoard.Enabled = false;

                foreach (Form form in this.MdiChildren)
                {
                    form.Visible = false;
                    form.Dispose();
                }

                try
                {
                    Settings.Default.UserAccount = string.Empty;
                    Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LogOut Error ! \n\n" + ex.Message, "Clear UserAccount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private void ToolStripApplicationClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripApplicationHide_Click(object sender, EventArgs e)
        {
            #region Hide DashBoard
            this.WindowState = FormWindowState.Minimized;
            ToolStripApplication.HideDropDown();
            #endregion
        }

        private void ToolStripApplicationLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Application Will Restart . . .\n\nAre You Sure Want to LogOut ?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                CloseAllChildForm();

                Settings.Default.UserAccount = "";
                Settings.Default.Save();

                labelDashBoardUserName.Text = "Please Login!";

                ShowFormLogin();
            }
        }

        private void ToolStripAccount_Click(object sender, EventArgs e)
        {
            #region Show FormAccount Inside DashBoard
            ShowFormAccount();
            #endregion
        }

        private void ToolStripSettingDataBase_Click(object sender, EventArgs e)
        {
            ShowFormDBSetting();
        }

        private void ToolStripProduct_Click(object sender, EventArgs e)
        {
            #region Show FormProduct Inside DashBoard
            //FormProduct formProduct = new FormProduct();
            //ShowForm(formProduct);
            #endregion
        }

        private void labelDashBoardUserName_TextChanged(object sender, EventArgs e)
        {
            CheckUserAccount();
        }

        #endregion
    }
}
