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
    public partial class FormLogin : Form
    {
        #region  Additional Set        
        Login_UI login_UI = new Login_UI();
        SQLGetData sqLGetData = new SQLGetData();
        CancelEventArgs Stop = new CancelEventArgs();

        #region Open FormLogin To DashBoard
        public FormLogin()
        {
            InitializeComponent();
        }
        #endregion Open FormLogin To DashBoard

        private void GetUserInput()
        {
            login_UI.UserName = TextBoxLoginUserName.Text.Trim();
            login_UI.PassWord = TextBoxLoginPassWord.Text.Trim();
        }
        #endregion Additional Set

        #region Action Set
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void ButtonLoginClose_Click(object sender, EventArgs e)
        {
            #region Close Button Pressed
            if (ButtonLoginClose.Text == "Reset")
            {
                TextBoxLoginUserName.Text = "";
                TextBoxLoginPassWord.Text = "";
                CheckBoxLoginShowPassword.Checked = false;

                ButtonLoginClose.Text = "Close";
                ButtonLoginClose.BackColor = Color.Navy;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Green;
                ButtonLoginClose.FlatAppearance.MouseDownBackColor = Color.Navy;
                ButtonLoginClose.ForeColor = Color.White;
                TextBoxLoginUserName.Select();
            }
            else
            {
                //DialogResult CloseAjpApp = MessageBox.Show("Anda Yakin Ingin Keluar Dari Aplikasi?", "System Close Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (CloseAjpApp == DialogResult.OK)
                //{

                //}
                Application.Exit();
            }
            #endregion
        }

        private void TextBoxLoginUserName_TextChanged(object sender, EventArgs e)
        {
            #region UserName Typed
            if (!string.IsNullOrEmpty(TextBoxLoginUserName.Text))
            {
                ButtonLoginClose.Text = "Reset";
                ButtonLoginClose.BackColor = Color.Yellow;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Red;
                ButtonLoginClose.ForeColor = Color.Black;
            }
            else if (!string.IsNullOrEmpty(TextBoxLoginPassWord.Text))
            {
                ButtonLoginClose.Text = "Reset";
                ButtonLoginClose.BackColor = Color.Yellow;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Red;
                ButtonLoginClose.ForeColor = Color.Black;
            }
            else
            {
                ButtonLoginClose.Text = "Close";
                ButtonLoginClose.BackColor = Color.Navy;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Green;
                ButtonLoginClose.ForeColor = Color.White;
            }
            #endregion
        }

        private void TextBoxLoginPassWord_TextChanged(object sender, EventArgs e)
        {
            #region PassWord Typed
            if (!string.IsNullOrEmpty(TextBoxLoginPassWord.Text))
            {
                ButtonLoginClose.Text = "Reset";
                ButtonLoginClose.BackColor = Color.Yellow;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Red;
                ButtonLoginClose.ForeColor = Color.Black;
            }
            else if (!string.IsNullOrEmpty(TextBoxLoginUserName.Text))
            {
                ButtonLoginClose.Text = "Reset";
                ButtonLoginClose.BackColor = Color.Yellow;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Red;
                ButtonLoginClose.ForeColor = Color.Black;
            }
            else
            {
                ButtonLoginClose.Text = "Close";
                ButtonLoginClose.BackColor = Color.Navy;
                ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Green;
                ButtonLoginClose.ForeColor = Color.White;
            }
            #endregion
        }

        private void CheckBoxLoginShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            #region Reveal/Hide PassWord 
            if (CheckBoxLoginShowPassword.Checked == false)
            {
                CheckBoxLoginShowPassword.Text = "Check To Show Password";
                TextBoxLoginPassWord.UseSystemPasswordChar = true;
            }
            else
            {
                CheckBoxLoginShowPassword.Text = "UnCheck To Hide Password";
                TextBoxLoginPassWord.UseSystemPasswordChar = false;
            }
            #endregion
        }

        private void TextBoxLoginPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            #region While PassWord Typed, And Enter Key is Pressed
            if (e.KeyCode == Keys.Enter)
            {
                ButtonLoginLogin.PerformClick();
            }
            #endregion
        }

        private void TextBoxLoginUserName_Validating(object sender, CancelEventArgs e)
        {
            #region UserName is Empty
            Stop.Cancel = false;
            if (string.IsNullOrEmpty(TextBoxLoginUserName.Text))
            {
                Stop.Cancel = true;
                TextBoxLoginUserName.Focus();
                errorProviderLogin.SetError(TextBoxLoginUserName, "UserName Tidak Boleh Kosong!");
            }
            else
            {
                errorProviderLogin.SetError(TextBoxLoginUserName, null);
            }
            #endregion
        }

        private void TextBoxLoginPassWord_Validating(object sender, CancelEventArgs e)
        {
            #region PassWord is Empty
            Stop.Cancel = false;
            if (string.IsNullOrEmpty(TextBoxLoginPassWord.Text))
            {
                Stop.Cancel = true;
                TextBoxLoginPassWord.Focus();
                errorProviderLogin.SetError(TextBoxLoginPassWord, "Password Tidak Boleh Kosong!");
            }
            else
            {
                errorProviderLogin.SetError(TextBoxLoginPassWord, null);
            }
            #endregion
        }

        private void ButtonLoginLogin_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                GetUserInput();

                int LoginResult = sqLGetData.LoginResult(login_UI.UserName, login_UI.PassWord);

                if (LoginResult == 1)
                {
                    //MessageBox.Show("Login Berhasil!!");

                    Settings.Default.UserAccount = login_UI.UserName;
                    Settings.Default.Save();

                    FormDashBoard.Forms.labelDashBoardUserName.Text = Settings.Default.UserAccount;
                    this.Hide();
                }
                else
                {
                    DialogResult LoginFailedAjp = MessageBox.Show("Username atau Password yang Anda masukan. Tidak terdaftar!" +
                    "\n\nKlik YES untuk mencoba input data kembali . . . \nWARNING! Kolom Username dan Password akan di KOSONG kan!" +
                    "\n\nKlik CANCLE untuk merubah data Username dan Password yang ada input sebelumnya . . . " +
                    "\n\nKlik NO untuk membuat Username dan Password Baru", "System Login Failed! Retry?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (LoginFailedAjp == DialogResult.Yes)
                    {
                        TextBoxLoginUserName.Text = "";
                        TextBoxLoginPassWord.Text = "";
                        CheckBoxLoginShowPassword.Checked = false;

                        ButtonLoginClose.Text = "Close";
                        ButtonLoginClose.BackColor = Color.Navy;
                        ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Green;
                        ButtonLoginClose.FlatAppearance.MouseDownBackColor = Color.Navy;
                        ButtonLoginClose.ForeColor = Color.White;
                        TextBoxLoginUserName.Select();
                    }
                    if (LoginFailedAjp == DialogResult.No)
                    {
                        TextBoxLoginUserName.Text = "";
                        TextBoxLoginPassWord.Text = "";
                        CheckBoxLoginShowPassword.Checked = false;

                        ButtonLoginClose.Text = "Close";
                        ButtonLoginClose.BackColor = Color.Navy;
                        ButtonLoginClose.FlatAppearance.MouseOverBackColor = Color.Green;
                        ButtonLoginClose.FlatAppearance.MouseDownBackColor = Color.Navy;
                        ButtonLoginClose.ForeColor = Color.White;
                        TextBoxLoginUserName.Select();

                        MessageBox.Show("Open Feature Registration");
                    }
                }
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Settings.Default.UserAccount = "";
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Clearing Current User Login !" + ex.Message, "LogOut Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Action Set
    }
}
