using ArlixAJP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arlix_UI
{
    class Login_UI
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    class ClassHelper
    {
        public static bool IsFormOpen(string FormName)
        {
            bool IsOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == FormName)
                {
                    IsOpen = true;
                    break;
                }
            }
            return IsOpen;
        }

        public static bool IsFileExist(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SqlAddress_UI
    {
        public string Server { get; set; }
        public bool Security { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string DataBase { get; set; }
    }

    class Account_UI
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountAlias { get; set; }
        public string AccountPhone { get; set; }
        public string AccountCompany { get; set; }
        public string AccountAddress { get; set; }
        public string AccountEmail { get; set; }
        public string AccountGender { get; set; }
        public string AccountType { get; set; }
        public string AccountNote { get; set; }
        public DateTime AccountAddTime { get; set; }
        public string AccountAddBy { get; set; }
        public DateTime AccountUpdateTime { get; set; }
        public string AccountUpdateBy { get; set; }
        public string AccountSearch { get; set; }

    }

    class Product_UI
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryNote { get; set; }
        public string ProductType { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeNote { get; set; }
        public string ProductColor { get; set; }
        public int ProductColorID { get; set; }
        public string ProductColorName { get; set; }
        public string ProductColorNote { get; set; }
        public Decimal ProductPrice { get; set; }
        public Decimal ProductStock { get; set; }
        public string ProductNote { get; set; }
        public DateTime ProductAddTime { get; set; }
        public string ProductAddBy { get; set; }
        public DateTime ProductUpdateTime { get; set; }
        public string ProductUpdateBy { get; set; }
        public string ProductSearch { get; set; }
    }
}
