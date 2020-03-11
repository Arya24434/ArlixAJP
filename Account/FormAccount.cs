using Arlix_SQL;
using Arlix_UI;
using ArlixAJP.Properties;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArlixAJP
{
    public partial class FormAccount : Form
    {
        #region Additional Set
        internal static FormAccount Forms;
        Account_UI account_UI = new Account_UI();
        SQLGetData sqLGetData = new SQLGetData();
        CancelEventArgs Stop = new CancelEventArgs();        

        #region Open FormAccount To DashBoard
        public FormAccount()
        {
            InitializeComponent();
            Forms = this;
        }
        #endregion

        #region MoveAble Borderless Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //private void panelAccountHead_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}

        private void FormAccount_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        public void GetUserInput()
        {
            if (textBoxAccountID.Text.Trim() != "")
            {
                account_UI.AccountID = int.Parse(textBoxAccountID.Text);
            }
            account_UI.AccountName = textBoxAccountName.Text;
            account_UI.AccountAlias = textBoxAccountAlias.Text;
            account_UI.AccountPhone = textBoxAccountPhone.Text;
            account_UI.AccountCompany = textBoxAccountCompany.Text;
            account_UI.AccountAddress = textBoxAccountAddress.Text;
            account_UI.AccountEmail = textBoxAccountEmail.Text;
            account_UI.AccountGender = textBoxAccountGender.Text;
            account_UI.AccountType = textBoxAccountType.Text;
            account_UI.AccountAddBy = Settings.Default.UserAccount;
            account_UI.AccountAddTime = DateTime.Now;
            account_UI.AccountUpdateBy = Settings.Default.UserAccount;
            account_UI.AccountUpdateTime = DateTime.Now;
            account_UI.AccountSearch = textBoxAccountSearch.Text;

        }

        public void ClearAllUserInput()
        {
            #region Clear All User Input
            textBoxAccountID.Text = null;
            textBoxAccountName.Text = null;
            textBoxAccountAlias.Text = null;
            textBoxAccountPhone.Text = null;
            textBoxAccountCompany.Text = null;
            textBoxAccountAddress.Text = null;
            textBoxAccountEmail.Text = null;
            textBoxAccountGender.Text = null;
            textBoxAccountType.Text = null;
            textBoxAccountNote.Text = null;
            textBoxAccountSearch.Text = null;

            DataTable dataTable = sqLGetData.AccountList();
            DataGridViewAccount(dataTable);
            #endregion
        }

        public void DataGridViewAccount(DataTable dataTable)
        {
            #region Fill Data Grid View
            try
            {
                dataGridViewAccount.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !! : " + ex.Message, "Fill Data Grid View Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Rename Header Data Grid View
            try
            {
                dataGridViewAccount.Columns[0].HeaderText = "ID";
                dataGridViewAccount.Columns[1].HeaderText = "Account Name";
                dataGridViewAccount.Columns[2].HeaderText = "Alias";
                dataGridViewAccount.Columns[3].HeaderText = "Phone";
                dataGridViewAccount.Columns[4].HeaderText = "Company";
                dataGridViewAccount.Columns[5].HeaderText = "Address";
                dataGridViewAccount.Columns[6].HeaderText = "Email";
                dataGridViewAccount.Columns[7].HeaderText = "Gender";
                dataGridViewAccount.Columns[8].HeaderText = "Type";
                dataGridViewAccount.Columns[9].HeaderText = "Note";
                dataGridViewAccount.Columns[10].HeaderText = "Add Time";
                dataGridViewAccount.Columns[11].HeaderText = "Add By";
                dataGridViewAccount.Columns[12].HeaderText = "Update Time";
                dataGridViewAccount.Columns[13].HeaderText = "Update By";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !! : " + ex.Message, "Rename Header Data Grid View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Auto Size Column Data Grid View
            try
            {
                foreach (DataGridViewColumn DataGridColumn in dataGridViewAccount.Columns)
                {
                    for (int i = 0; i < DataGridColumn.DataGridView.ColumnCount; i++)
                    {
                        //    //DataGridColumn.DataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        DataGridColumn.DataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        DataGridColumn.DataGridView.Columns[i].FillWeight = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !! : " + ex.Message, "Auto Size Column On Data Grid View", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        public void ClearError()
        {
            errorProviderAccount.Clear();
        }

        public void AccountAdd()
        {
            bool AddNewAccount = sqLGetData.AccountAdd(
            account_UI.AccountName, account_UI.AccountAlias, account_UI.AccountPhone,
            account_UI.AccountCompany, account_UI.AccountAddress, account_UI.AccountEmail, account_UI.AccountGender,
            account_UI.AccountType, account_UI.AccountAddTime, account_UI.AccountAddBy);
            if (AddNewAccount != true)
            {
                MessageBox.Show("Account Added Successfully");
                ClearAllUserInput();
            }
            else
            {
                MessageBox.Show("error");
            }
            DataTable dataTable = sqLGetData.AccountList();
            DataGridViewAccount(dataTable);
        }

        public void AccountInsert()
        {
            bool AddNewAccount = sqLGetData.AccountInsert(
            account_UI.AccountID, account_UI.AccountName, account_UI.AccountAlias, account_UI.AccountPhone,
            account_UI.AccountCompany, account_UI.AccountAddress, account_UI.AccountEmail, account_UI.AccountGender,
            account_UI.AccountType, account_UI.AccountAddTime, account_UI.AccountAddBy);
            if (AddNewAccount != true)
            {
                MessageBox.Show("Account Insert Successfully");

                ClearAllUserInput();
            }
            else
            {
                MessageBox.Show("error");
            }
            DataTable dataTable = sqLGetData.AccountList();
            DataGridViewAccount(dataTable);
        }

        public void AccountUpdate()
        {
            bool UpdateExistingAccount = sqLGetData.AccountUpdate(
            account_UI.AccountID, account_UI.AccountName, account_UI.AccountAlias, account_UI.AccountPhone,
            account_UI.AccountCompany, account_UI.AccountAddress, account_UI.AccountEmail, account_UI.AccountGender,
            account_UI.AccountType, account_UI.AccountUpdateTime, account_UI.AccountUpdateBy);
            if (UpdateExistingAccount != true)
            {
                MessageBox.Show("Account Updated Successfully");
                ClearAllUserInput();
            }
            else
            {
                MessageBox.Show("error");
            }
            DataTable dataTable = sqLGetData.AccountList();
            DataGridViewAccount(dataTable);
        }

        public bool AccountExist()
        {
            bool UpdateAccountExist = false;

            DataTable CheckAccountExist = sqLGetData.AccountExist(account_UI.AccountName, account_UI.AccountAlias);
            if (CheckAccountExist.Rows.Count > 0)
            {
                DataGridViewAccount(CheckAccountExist);

                DialogResult = MessageBox.Show("Account Already exist do you want to update?", "Message", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    UpdateAccountExist = true;
                }
                else
                {
                    UpdateAccountExist = false;
                }
            }

            return UpdateAccountExist;
        }

        #endregion Additional Set

        #region Action Set
        private void FormAccount_Load(object sender, EventArgs e)
        {
            DataTable dataTable = sqLGetData.AccountList();
            DataGridViewAccount(dataTable);
            FormDashBoard.Forms.ToolStripAccount.ForeColor = Color.DarkGreen;

        }

        private void FormAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearError();
        }

        private void buttonAccountSearch_Click(object sender, EventArgs e)
        {
            ClearError();

            if (string.IsNullOrEmpty(textBoxAccountSearch.Text))
            {
                errorProviderAccount.SetError(textBoxAccountSearch, "Info Required");
                DataTable dataTable = sqLGetData.AccountList();
                DataGridViewAccount(dataTable);
            }
            else
            {
                GetUserInput();
                DataTable dataTable = sqLGetData.AccountSearch(account_UI.AccountSearch.Trim());
                DataGridViewAccount(dataTable);
            }
        }

        private void buttonAccountClear_Click(object sender, EventArgs e)
        {
            ClearError();

            ClearAllUserInput();
        }

        private void dataGridViewAccount_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearError();

            #region Pass User Data To TextBox Input
            try
            {
                int TableAccountRow = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    textBoxAccountID.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[0].Value.ToString(); //.Trim();
                    textBoxAccountName.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[1].Value.ToString(); //.Trim();
                    textBoxAccountAlias.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[2].Value.ToString(); //.Trim();
                    textBoxAccountPhone.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[3].Value.ToString(); //.Trim();
                    textBoxAccountCompany.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[4].Value.ToString(); //.Trim();
                    textBoxAccountAddress.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[5].Value.ToString(); //.Trim();
                    textBoxAccountEmail.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[6].Value.ToString(); //.Trim();
                    textBoxAccountGender.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[7].Value.ToString(); //.Trim();
                    textBoxAccountType.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[8].Value.ToString(); //.Trim();
                    textBoxAccountNote.Text = dataGridViewAccount.Rows[TableAccountRow].Cells[9].Value.ToString(); //.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! : " + ex.Message, "Pass UserSelect Data To TextBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void buttonAccountReportDetail_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yes For Detail Account\n\nNo For All Account", "Report Selection", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if(textBoxAccountID.Text == null)
                {
                    Stop.Cancel = true; 
                }
                else
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType() == typeof(FormAccountReport)) //<<FormName
                        {
                            form.WindowState = FormWindowState.Normal;
                            form.BringToFront();
                            form.Focus();
                            return;
                        }
                    }

                    FormAccountReport formAccountReport = new FormAccountReport(true);
                    formAccountReport.Show();
                    formAccountReport.Activate();
                    formAccountReport.Focus();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(FormAccountReport)) //<<FormName
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.BringToFront();
                        form.Focus();
                        return;
                    }
                }

                FormAccountReport formAccountReport = new FormAccountReport(false);
                formAccountReport.Show();
                formAccountReport.Activate();
                formAccountReport.Focus();
            }
        }

        private void buttonAccountDelete_Click(object sender, EventArgs e)
        {
            ClearError();

            DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Delete This Account?\n" +
                "\nAccount Name : " + textBoxAccountName.Text, "Delete Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                GetUserInput();
                bool AccountDeleted = sqLGetData.AccountDelete(account_UI.AccountID);
                if (AccountDeleted == true)
                {
                    MessageBox.Show("Account " + account_UI.AccountName + " Deleted !");
                    ClearAllUserInput();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                Stop.Cancel = true;
            }

            DataTable dataTable = sqLGetData.AccountList();
            DataGridViewAccount(dataTable);

        }

        private void textBoxAccountID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountID.Text))
            {
                buttonAccountDelete.Enabled = false;
                buttonAccountUpdate.Enabled = false;
            }
            else
            {
                buttonAccountDelete.Enabled = true;
                buttonAccountUpdate.Enabled = true;
            }
        }

        private void buttonAccountUpdate_Click(object sender, EventArgs e)
        {
            ClearError();

            DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Update This Account?\n" +
                "\nAccount Name : " + textBoxAccountName.Text, "Update Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (textBoxAccountID.Enabled != true)
                {
                    GetUserInput();
                    AccountUpdate();
                }
                else
                {
                    MessageBox.Show("Your In Administrator Mode, You Can only update Existing Data");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                Stop.Cancel = true;
            }
        }

        private void buttonAccountAdd_Click(object sender, EventArgs e)
        {
            ClearError();

            if (string.IsNullOrEmpty(textBoxAccountName.Text))
            {
                errorProviderAccount.SetError(textBoxAccountName, "Name Required");
                Stop.Cancel = true;
            }

            GetUserInput();

            if (AccountExist() == true)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Update This Account?\n" +
                "\nAccount Name : " + textBoxAccountName.Text, "Update Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    account_UI.AccountID = Convert.ToInt32(dataGridViewAccount.Rows[0].Cells[0].Value.ToString());

                    AccountUpdate();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Stop.Cancel = true;
                }
            }
            else
            {
                if (textBoxAccountID.Enabled != true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Add This Account?\n" +
                    "\nAccount Name : " + textBoxAccountName.Text, "Add Account", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        AccountAdd();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Stop.Cancel = true;
                    }

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Insert This Account?\n" +
                    "\nAccount Name : " + textBoxAccountName.Text, "Insert Account", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        AccountInsert();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Stop.Cancel = true;
                    }
                }
            }
        }

        private void textBoxAccountNote_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearError();

            if (textBoxAccountID.Enabled != true)
            {
                MessageBox.Show("Administrator MODE!");
                textBoxAccountID.Enabled = true;
                textBoxAccountID.BackColor = Color.Green;
            }
            else
            {
                MessageBox.Show("User Mode");
                textBoxAccountID.Enabled = false;
                textBoxAccountID.BackColor = Color.Black;
            }
        }

        private void labelAccountSearch_Click(object sender, EventArgs e)
        {

        }
        #endregion Action Set
    }
}
