using Arlix_SQL;
using Arlix_UI;
using ArlixAJP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArlixAJP
{
    public partial class FormDBSetting : Form
    {
        #region Additional Set
        internal static FormDBSetting Forms;

        SqlAddress_UI sqlAddress_UI = new SqlAddress_UI();
        SQLGetData SQLDataBase_UI = new SQLGetData();

        private void GetUserInput()
        {
            sqlAddress_UI.Server = comboBoxDBSettingSelectServer.Text;
            if (checkBoxDBSettingWinSecurity.Checked)
            {
                sqlAddress_UI.Security = true;
            }
            else
            {
                sqlAddress_UI.Security = false;
            }
            sqlAddress_UI.UserName = textBoxDBSettingUserName.Text;
            sqlAddress_UI.PassWord = textBoxDBSettingPassWord.Text;
            if (string.IsNullOrEmpty(comboBoxDBSettingSelectDataBase.Text))
            {
                sqlAddress_UI.DataBase = "master";
            }
            else
            {
                sqlAddress_UI.DataBase = comboBoxDBSettingSelectDataBase.Text;
            }
        }

        #region Open FormDBSetting To DashBoard
        public FormDBSetting()
        {
            InitializeComponent();
            Forms = this;
            FormDashBoard.Forms.ToolStripSettingDataBase.ForeColor = Color.DarkGreen;
        }
        #endregion Open FormDBSetting To DashBoard
        #endregion Additional Set


        #region Action Set
        private void FormDBSetting_Load(object sender, EventArgs e)
        {
            #region Get SQL ServerList From UserSetting To Combobox
            comboBoxDBSettingSelectServer.Text = Settings.Default.SqlServer;
            comboBoxDBSettingSelectDataBase.Text = Settings.Default.SqlDataBase;
            if (checkBoxDBSettingWinSecurity.Checked == false)
            {
                textBoxDBSettingUserName.Text = Settings.Default.SqlUserName;
                textBoxDBSettingPassWord.Text = Settings.Default.SqlPassWord;
            }
            #endregion           
        }

        private void checkBoxDBSettingWinSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDBSettingWinSecurity.Checked)
            {
                checkBoxDBSettingWinSecurity.ForeColor = Color.White;
                checkBoxDBSettingShowPassWord.ForeColor = Color.Black;
                checkBoxDBSettingShowPassWord.Checked = false;
                checkBoxDBSettingShowPassWord.Enabled = false;
                labelDBSettingUserName.ForeColor = Color.Black;
                labelDBSettingPassWord.ForeColor = Color.Black;
                textBoxDBSettingUserName.Enabled = false;
                textBoxDBSettingPassWord.Enabled = false;
                textBoxDBSettingUserName.BackColor = Color.Green;
                textBoxDBSettingPassWord.BackColor = Color.Green;
                textBoxDBSettingUserName.Text = "";
                textBoxDBSettingPassWord.Text = "";
                errorProviderDBSetting.SetError(textBoxDBSettingUserName, null);
                errorProviderDBSetting.SetError(textBoxDBSettingPassWord, null);
            }
            else
            {
                checkBoxDBSettingWinSecurity.ForeColor = Color.Black;
                checkBoxDBSettingShowPassWord.ForeColor = Color.Blue;
                checkBoxDBSettingShowPassWord.Enabled = true;
                labelDBSettingUserName.ForeColor = Color.White;
                labelDBSettingPassWord.ForeColor = Color.White;
                textBoxDBSettingUserName.Enabled = true;
                textBoxDBSettingPassWord.Enabled = true;
                textBoxDBSettingUserName.BackColor = Color.White;
                textBoxDBSettingPassWord.BackColor = Color.White;
            }
        }
        
        private void buttonDBSettingSelectDataBase_Click(object sender, EventArgs e)
        {
            if (comboBoxDBSettingSelectDataBase.Items.Count != 0)
            {
                comboBoxDBSettingSelectDataBase.Focus();
                comboBoxDBSettingSelectDataBase.DroppedDown = true;
                errorProviderDBSetting.SetError(comboBoxDBSettingSelectDataBase, "DataBase Already Found!");
            }
            else
            {
                errorProviderDBSetting.SetError(textBoxDBSettingUserName, null);
                GetUserInput();
                comboBoxDBSettingSelectDataBase.Items.AddRange(SQLDataBase_UI.SetFindSqlDatabaseList(sqlAddress_UI.Server, sqlAddress_UI.DataBase, sqlAddress_UI.Security, sqlAddress_UI.UserName, sqlAddress_UI.PassWord));
            }
        }

        private void buttonDBSettingTest_Click(object sender, EventArgs e)
        {

            #region MakeSure DataBase Name Exist
            if (string.IsNullOrEmpty(comboBoxDBSettingSelectDataBase.Text))
            {
                buttonDBSettingSelectDataBase_Click(sender, e);
                comboBoxDBSettingSelectDataBase.Focus();
                comboBoxDBSettingSelectDataBase.DroppedDown = true;
                errorProviderDBSetting.SetError(comboBoxDBSettingSelectDataBase, "Input Or Select DataBase!");
            }
            #endregion

            #region Tess Connection
            GetUserInput();
            SQLDataBase_UI.TestConnectionToSqlDatabase(sqlAddress_UI.Server, sqlAddress_UI.DataBase, sqlAddress_UI.Security, sqlAddress_UI.UserName, sqlAddress_UI.PassWord);
            #endregion

        }

        private void checkBoxDBSettingShowPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDBSettingShowPassWord.Checked == false)
            {
                textBoxDBSettingPassWord.UseSystemPasswordChar = true;
            }
            else
            {
                textBoxDBSettingPassWord.UseSystemPasswordChar = false;
            }
        }

        private void comboBoxDBSettingSelectServer_Validating(object sender, CancelEventArgs e)
        {
            #region Server Name Error!
            if (string.IsNullOrEmpty(comboBoxDBSettingSelectServer.Text))
            {
                comboBoxDBSettingSelectServer.Focus();
                errorProviderDBSetting.SetError(comboBoxDBSettingSelectServer, "Server Name Error!");
            }
            else
            {
                errorProviderDBSetting.SetError(comboBoxDBSettingSelectServer, null);
            }
            #endregion
        }
        
        private void textBoxDBSettingUserName_Validating(object sender, CancelEventArgs e)
        {
            #region Security Error!
            if (checkBoxDBSettingWinSecurity.Checked == false)
            {
                if (string.IsNullOrEmpty(textBoxDBSettingUserName.Text))
                {
                    comboBoxDBSettingSelectServer.Focus();
                    errorProviderDBSetting.SetError(textBoxDBSettingUserName, "User Name Error!");
                }
                else
                {
                    errorProviderDBSetting.SetError(textBoxDBSettingUserName, null);
                }
            }
            #endregion
        }

        private void comboBoxDBSettingSelectDataBase_Click(object sender, EventArgs e)
        {
            errorProviderDBSetting.SetError(comboBoxDBSettingSelectDataBase, null);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Settings.Default.SqlServer = "";
            Settings.Default.SqlSecurity = true;
            Settings.Default.SqlUserName = "";
            Settings.Default.SqlPassWord = "";
            Settings.Default.SqlDataBase = "";

            Settings.Default.Save();

            comboBoxDBSettingSelectServer.Text = "";
            textBoxDBSettingUserName.Text = "";
            textBoxDBSettingPassWord.Text = "";
            comboBoxDBSettingSelectDataBase.Text = "";

            MessageBox.Show("Your Setting Was RESET!", "RESET Mode Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Settings.Default.Reload();
            Application.Restart();
        }

        private void buttonDBSettingDone_Click(object sender, EventArgs e)
        {
            GetUserInput();
            DialogResult TestedConnection = MessageBox.Show("Are You Sure Want To Save This Setting?\n\n" +
                "Click < Yes > To Save Seting . . .\n\n" +
                "Click < No > To Test The Connection Again . . .\n\n" +
                "Click < Cancle > To Clear The Input . . . ", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (TestedConnection == DialogResult.Yes)
            {
                Settings.Default.SqlServer = sqlAddress_UI.Server;
                Settings.Default.SqlSecurity = sqlAddress_UI.Security;
                Settings.Default.SqlUserName = sqlAddress_UI.UserName;
                Settings.Default.SqlPassWord = sqlAddress_UI.PassWord;
                Settings.Default.SqlDataBase = sqlAddress_UI.DataBase;
                Settings.Default.Save();
                if (sqlAddress_UI.Security == true)
                {
                    MessageBox.Show("Your Setting : \n\n" +
                    "DataSource = [ " + sqlAddress_UI.Server + " ]\n" +
                    "IntegratedSecurity = [ " + sqlAddress_UI.Security + " ]\n" +
                    "InitialCatalog = [ " + sqlAddress_UI.DataBase + " ]\n" +
                    "Has Been Saved!", "Setting Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Please Close This Application And Run Again!", "Restart The Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Settings.Default.Reload();
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Your Setting : \n\n" +
                    "DataSource = [ " + sqlAddress_UI.Server + " ]\n" +
                    "IntegratedSecurity = [ " + sqlAddress_UI.Security + " ]\n" +
                    "UserID = [ " + sqlAddress_UI.UserName + " ]\n" +
                    "Password = [ " + sqlAddress_UI.PassWord + " ]\n" +
                    "InitialCatalog = [ " + sqlAddress_UI.DataBase + " ]\n" +
                    "Has Been Saved!", "Setting Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Please Close This Application And Run Again!", "Restart The Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    Settings.Default.Reload();
                    Application.Restart();
                }

                Settings.Default.Reload();
            }
            else if (TestedConnection == DialogResult.No)
            {
                buttonDBSettingTest_Click(sender, e);
            }
            else
            {
                comboBoxDBSettingSelectServer.Text = "";
                checkBoxDBSettingWinSecurity.Checked = true;
                textBoxDBSettingUserName.Text = "";
                textBoxDBSettingPassWord.Text = "";
                checkBoxDBSettingShowPassWord.Checked = false;
                comboBoxDBSettingSelectDataBase.Text = "";
                comboBoxDBSettingSelectDataBase.Items.Clear();
            }
        }

        #endregion
    }
}
