using ArlixAJP.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arlix_SQL
{
    class SqlConnections
    {
        #region SqlAddress 
        public static string SqlAddress()
        { 
            string sqlAddress;

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            if (Settings.Default.SqlSecurity == true)
            {
                sqlConnectionStringBuilder.DataSource = Settings.Default.SqlServer;
                sqlConnectionStringBuilder.InitialCatalog = Settings.Default.SqlDataBase;
                sqlConnectionStringBuilder.IntegratedSecurity = Settings.Default.SqlSecurity;
                sqlAddress = sqlConnectionStringBuilder.ToString();

                return sqlAddress;
            }
            else
            {
                sqlConnectionStringBuilder.DataSource = Settings.Default.SqlServer;
                sqlConnectionStringBuilder.InitialCatalog = Settings.Default.SqlDataBase;
                sqlConnectionStringBuilder.IntegratedSecurity = Settings.Default.SqlSecurity;
                sqlConnectionStringBuilder.UserID = Settings.Default.SqlUserName;
                sqlConnectionStringBuilder.Password = Settings.Default.SqlPassWord;
                sqlAddress = sqlConnectionStringBuilder.ToString();

                return sqlAddress;
            }
        }
        #endregion SqlAddress

        #region SetSqlAddress
        public static string SetSqlAddress(string ServerName, string InitialCatalog, bool WindowsAuthentication, string UserName, string PassWord)
        {
            string sqlAddress;

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            if (WindowsAuthentication == true)
            {
                sqlConnectionStringBuilder.DataSource = ServerName;
                sqlConnectionStringBuilder.InitialCatalog = InitialCatalog;
                sqlConnectionStringBuilder.IntegratedSecurity = WindowsAuthentication;
                sqlAddress = sqlConnectionStringBuilder.ToString();

                return sqlAddress;
            }
            else
            {
                sqlConnectionStringBuilder.DataSource = ServerName;
                sqlConnectionStringBuilder.InitialCatalog = InitialCatalog;
                sqlConnectionStringBuilder.IntegratedSecurity = WindowsAuthentication;
                sqlConnectionStringBuilder.UserID = UserName;
                sqlConnectionStringBuilder.Password = PassWord;
                sqlAddress = sqlConnectionStringBuilder.ToString();

                return sqlAddress;
            }
        }
        #endregion SetSqlAddress
    }

    class SQLGetData
    {
        public static DataTable TrimDataTable(DataTable dataTable)
        {
            foreach(DataColumn dataColumn in dataTable.Columns) //Trim Columns
            {
                dataColumn.ColumnName = dataColumn.ColumnName.Trim();
            }

            foreach(DataRow dataRow in dataTable.Rows) //Trim String Data
            {
                foreach(DataColumn dataColumn in dataTable.Columns)
                {
                    if(dataColumn.DataType == typeof(string))
                    {
                        object o = dataRow[dataColumn];
                        if(!Convert.IsDBNull(o) && o != null)
                        {
                            dataRow[dataColumn] = o.ToString().Trim();
                        }

                    }
                }
            }
            return dataTable;
        }

        #region Check Connection With DataBase
        public bool IsServerConnected()
        {
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        #endregion Check Connection With DataBase

        #region Setting Find Sql Server DataBase
        public string[] SetFindSqlDatabaseList(string ServerName, string InitialCatalog, bool WindowsAuthentication, string UserName, string PassWord)
        {
            string _SqlConnection;
            _SqlConnection = SqlConnections.SetSqlAddress(ServerName, InitialCatalog, WindowsAuthentication, UserName, PassWord);

            SqlConnection sqlConnection = new SqlConnection(_SqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select name from sysdatabases", sqlConnection);

            try
            {
                DataTable dataTable = new DataTable("Databases");
                int rowsAffected = dataAdapter.Fill(dataTable);
                if (dataTable == null || rowsAffected <= 0)
                {
                    return null;
                }

                int Find = -1;
                string[] databases = new string[dataTable.Rows.Count];
                foreach (DataRow r in dataTable.Rows)
                {
                    databases[System.Math.Max(System.Threading.Interlocked.Increment(ref Find), Find - 1)] = r["name"].ToString();
                }
                dataAdapter.Dispose();
                Array.Sort(databases);
                return databases;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Can't Find Database List:\n" + ex.Message, "Find DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        #endregion Setting Find Sql Server DataBase

        #region Test Connection To Sql DataBase
        public void TestConnectionToSqlDatabase(string ServerName, string InitialCatalog, bool WindowsAuthentication, string UserName, string PassWord)
        {
            string _SqlConnection;
            _SqlConnection = SqlConnections.SetSqlAddress(ServerName, InitialCatalog, WindowsAuthentication, UserName, PassWord);

            SqlConnection sqlConnection = new SqlConnection(_SqlConnection);

            try
            {
                sqlConnection.Open();

                if (InitialCatalog == "master")
                {
                    MessageBox.Show("Connection To: ( " + ServerName + " ) is Success!\n\n" +
                        "Please Select DataBase From The DataBase List!"
                        , "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Connection to database ; ( " + InitialCatalog + " ) was successful", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the database\n\n" + ex.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Test Connection To Sql DataBase

        #region Get Login Data
        public int LoginResult(string UserName, string PassWord)
        {
            int LoginResult = 0;
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("LoginResult", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@Username", UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", PassWord);
                    sqlConnection.Open();
                    LoginResult = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            return LoginResult;
        }
        #endregion

        #region Account Manager

        #region Account List
        public DataTable AccountList()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountList", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Account Search
        public DataTable AccountSearch(string AccountSearch)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountSearch", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@AccountSearch", AccountSearch);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Account Exist  
        public DataTable AccountExist(string AccountName, string AccountAlias)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountExist", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@AccountName", AccountName);
                    sqlCommand.Parameters.AddWithValue("@AccountAlias", AccountAlias);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Account Update  
        public Boolean AccountUpdate(int AccountID, string AccountName, string AccountAlias,
                                        string AccountPhone, string AccountCompany, string AccountAddress,
                                        string AccountEmail, string AccountGender, string AccountType,
                                        DateTime AccountUpdateTime, string AccountUpdateBy)
        {
            bool AccountUpdated = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountUpdate", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@AccountID", AccountID);
                    sqlCommand.Parameters.AddWithValue("@AccountName", AccountName);
                    sqlCommand.Parameters.AddWithValue("@AccountAlias", AccountAlias);
                    sqlCommand.Parameters.AddWithValue("@AccountPhone", AccountPhone);
                    sqlCommand.Parameters.AddWithValue("@AccountCompany", AccountCompany);
                    sqlCommand.Parameters.AddWithValue("@AccountAddress", AccountAddress);
                    sqlCommand.Parameters.AddWithValue("@AccountEmail", AccountEmail);
                    sqlCommand.Parameters.AddWithValue("@AccountGender", AccountGender);
                    sqlCommand.Parameters.AddWithValue("@AccountType", AccountType);
                    sqlCommand.Parameters.AddWithValue("@AccountUpdateTime", AccountUpdateTime);
                    sqlCommand.Parameters.AddWithValue("@AccountUpdateBy", AccountUpdateBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowUpdated = sqlCommand.ExecuteNonQuery();
                    if (AccountRowUpdated > 0)
                    {
                        AccountUpdated = true;
                    }
                    else
                    {
                        AccountUpdated = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return AccountUpdated;
        }
        #endregion

        #region Account Add New 
        public Boolean AccountAdd(string AccountName, string AccountAlias, string AccountPhone,
                                    string AccountCompany, string AccountAddress, string AccountEmail,
                                    string AccountGender, string AccountType, DateTime AccountAddTime,
                                    string AccountAddBy)
        {
            bool AccountAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountAdd", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@AccountName", AccountName);
                    sqlCommand.Parameters.AddWithValue("@AccountAlias", AccountAlias);
                    sqlCommand.Parameters.AddWithValue("@AccountPhone", AccountPhone);
                    sqlCommand.Parameters.AddWithValue("@AccountCompany", AccountCompany);
                    sqlCommand.Parameters.AddWithValue("@AccountAddress", AccountAddress);
                    sqlCommand.Parameters.AddWithValue("@AccountEmail", AccountEmail);
                    sqlCommand.Parameters.AddWithValue("@AccountGender", AccountGender);
                    sqlCommand.Parameters.AddWithValue("@AccountType", AccountType);
                    sqlCommand.Parameters.AddWithValue("@AccountAddTime", AccountAddTime);
                    sqlCommand.Parameters.AddWithValue("@AccountAddBy", AccountAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowAdded = sqlCommand.ExecuteNonQuery();
                    if (AccountRowAdded > 0)
                    {
                        //Query Sucessfull
                        AccountAdded = true;
                    }
                    else
                    {
                        //Query Failed
                        AccountAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return AccountAdded;
        }
        #endregion

        #region Account Insert
        public Boolean AccountInsert(int AccountID, string AccountName, string AccountAlias,
                                        string AccountPhone, string AccountCompany, string AccountAddress,
                                        string AccountEmail, string AccountGender, string AccountType,
                                        DateTime AccountAddTime, string AccountAddBy)
        {
            bool AccountInserted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountInsert", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@AccountID", AccountID);
                    sqlCommand.Parameters.AddWithValue("@AccountName", AccountName);
                    sqlCommand.Parameters.AddWithValue("@AccountAlias", AccountAlias);
                    sqlCommand.Parameters.AddWithValue("@AccountPhone", AccountPhone);
                    sqlCommand.Parameters.AddWithValue("@AccountCompany", AccountCompany);
                    sqlCommand.Parameters.AddWithValue("@AccountAddress", AccountAddress);
                    sqlCommand.Parameters.AddWithValue("@AccountEmail", AccountEmail);
                    sqlCommand.Parameters.AddWithValue("@AccountGender", AccountGender);
                    sqlCommand.Parameters.AddWithValue("@AccountType", AccountType);
                    sqlCommand.Parameters.AddWithValue("@AccountAddTime", AccountAddTime);
                    sqlCommand.Parameters.AddWithValue("@AccountAddBy", AccountAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowInserted = sqlCommand.ExecuteNonQuery();
                    if (AccountRowInserted > 0)
                    {
                        //Query Sucessfull
                        AccountInserted = true;
                    }
                    else
                    {
                        //Query Failed
                        AccountInserted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return AccountInserted;
        }
        #endregion

        #region Account Delete  
        public Boolean AccountDelete(int AccountID)
        {
            bool AccountDeleted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("AccountDelete", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@AccountID", AccountID);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowDeleted = sqlCommand.ExecuteNonQuery();
                    if (AccountRowDeleted > 0)
                    {
                        //Query Sucessfull
                        AccountDeleted = true;
                    }
                    else
                    {
                        //Query Failed
                        AccountDeleted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return AccountDeleted;
        }
        #endregion

        #endregion

        #region Product Manager

        #region PRODUCT
        #region Product List
        public DataTable ProductList()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductList", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Product Data List From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Add New 
        public Boolean ProductAdd(string ProductName, string ProductCategory, string ProductType,
                                    string ProductColor, Decimal ProductPrice, Decimal ProductStock,
                                    string ProductNote, DateTime ProductAddTime, string ProductAddBy)
        {
            bool ProductAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductAdd", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductName", ProductName);
                    sqlCommand.Parameters.AddWithValue("@ProductCategory", ProductCategory);
                    sqlCommand.Parameters.AddWithValue("@ProductType", ProductType);
                    sqlCommand.Parameters.AddWithValue("@ProductColor", ProductColor);
                    sqlCommand.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                    sqlCommand.Parameters.AddWithValue("@ProductStock", ProductStock);
                    sqlCommand.Parameters.AddWithValue("@ProductNote", ProductNote);
                    sqlCommand.Parameters.AddWithValue("@ProductAddTime", ProductAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductAddBy", ProductAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int ProductRowAdded = sqlCommand.ExecuteNonQuery();
                    if (ProductRowAdded > 0)
                    {
                        //Query Sucessfull
                        ProductAdded = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductAdded;
        }
        #endregion

        #region Product Insert
        public Boolean ProductInsert(int ProductID, string ProductName, string ProductCategory,
                                        string ProductType, string ProductColor, Decimal ProductPrice,
                                        Decimal ProductStock, string ProductNote, DateTime ProductAddTime, string ProductAddBy)
        {
            bool ProductInserted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductInsert", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                    sqlCommand.Parameters.AddWithValue("@ProductName", ProductName);
                    sqlCommand.Parameters.AddWithValue("@ProductCategory", ProductCategory);
                    sqlCommand.Parameters.AddWithValue("@ProductType", ProductType);
                    sqlCommand.Parameters.AddWithValue("@ProductColor", ProductColor);
                    sqlCommand.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                    sqlCommand.Parameters.AddWithValue("@ProductStock", ProductStock);
                    sqlCommand.Parameters.AddWithValue("@ProductNote", ProductNote);
                    sqlCommand.Parameters.AddWithValue("@ProductAddTime", ProductAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductAddBy", ProductAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int CategoryRowInserted = sqlCommand.ExecuteNonQuery();
                    if (CategoryRowInserted > 0)
                    {
                        //Query Sucessfull
                        ProductInserted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductInserted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductInserted;
        }
        #endregion

        #region Product Exist  
        public DataTable ProductExist(string ProductName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductExist", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductName", ProductName);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Product Exist In DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Delete  
        public Boolean ProductDelete(int ProductID)
        {
            bool ProductDelete = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductDelete", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int ProductRowDeleted = sqlCommand.ExecuteNonQuery();
                    if (ProductRowDeleted > 0)
                    {
                        //Query Sucessfull
                        ProductDelete = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductDelete = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductDelete;
        }
        #endregion

        #region Product Update  
        public Boolean ProductUpdate(
            int ProductID, string ProductName, string ProductCategory,
            string ProductType, string ProductColor, string ProductNote,
            Decimal ProductPrice, Decimal ProductStock, DateTime ProductUpdateTime,
            string ProductUpdateBy)
        {
            bool ProductUpdated = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductUpdate", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                    sqlCommand.Parameters.AddWithValue("@ProductName", ProductName);
                    sqlCommand.Parameters.AddWithValue("@ProductCategory", ProductCategory);
                    sqlCommand.Parameters.AddWithValue("@ProductType", ProductType);
                    sqlCommand.Parameters.AddWithValue("@ProductColor", ProductColor);
                    sqlCommand.Parameters.AddWithValue("@ProductNote", ProductNote);
                    sqlCommand.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                    sqlCommand.Parameters.AddWithValue("@ProductStock", ProductStock);
                    sqlCommand.Parameters.AddWithValue("@ProductUpdateTime", ProductUpdateTime);
                    sqlCommand.Parameters.AddWithValue("@ProductUpdateBy", ProductUpdateBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowUpdated = sqlCommand.ExecuteNonQuery();
                    if (AccountRowUpdated > 0)
                    {
                        //Query Sucessfull
                        ProductUpdated = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductUpdated = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductUpdated;
        }
        #endregion

        #region Product Search
        public DataTable ProductSearch(string ProductSearch)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductSearch", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductSearch", ProductSearch);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion
        #endregion

        #region PRODUCT CATEGORY
        #region Product Category List
        public DataTable ProductCategoryList()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategoryList", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    //TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Category Data List From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Category Exist  
        public DataTable ProductCategoryExist(string ProductCategoryName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategoryExist", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryName", ProductCategoryName);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    //TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Category Exist In DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Category Add New 
        public Boolean ProductCategoryAdd(string ProductCategoryName, string ProductCategoryNote,
                                            DateTime ProductCategoryAddTime, string ProductCategoryAddBy)
        {
            bool ProductCategoryAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategoryAdd", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryName", ProductCategoryName);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryNote", ProductCategoryNote);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryAddTime", ProductCategoryAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryAddBy", ProductCategoryAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int CategoryRowAdded = sqlCommand.ExecuteNonQuery();
                    if (CategoryRowAdded > 0)
                    {
                        //Query Sucessfull
                        ProductCategoryAdded = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductCategoryAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductCategoryAdded;
        }
        #endregion

        #region Product Category Insert
        public Boolean ProductCategoryInsert(int ProductCategoryID, string ProductCategoryName, string ProductCategoryNote,
                                                DateTime ProductCategoryAddTime, string ProductCategoryAddBy)
        {
            bool ProductCategoryInserted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategoryInsert", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryName", ProductCategoryName);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryNote", ProductCategoryNote);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryAddTime", ProductCategoryAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryAddBy", ProductCategoryAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int CategoryRowInserted = sqlCommand.ExecuteNonQuery();
                    if (CategoryRowInserted > 0)
                    {
                        //Query Sucessfull
                        ProductCategoryInserted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductCategoryInserted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductCategoryInserted;
        }
        #endregion

        #region Product Category Delete  
        public Boolean ProductCategoryDelete(int ProductCategoryID)
        {
            bool ProductCategoryDeleted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategoryDelete", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowDeleted = sqlCommand.ExecuteNonQuery();
                    if (AccountRowDeleted > 0)
                    {
                        //Query Sucessfull
                        ProductCategoryDeleted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductCategoryDeleted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductCategoryDeleted;
        }
        #endregion

        #region Product Category Search
        public DataTable ProductCategorySearch(string ProductCategorySearch)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategorySearch", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductCategorySearch", ProductCategorySearch);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Category Update  
        public Boolean ProductCategoryUpdate(
            int ProductCategoryID, string ProductCategoryName, string ProductCategoryNote,
            DateTime ProductCategoryUpdateTime, string ProductCategoryUpdateBy)
        {
            bool ProductUpdated = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductCategoryUpdate", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryName", ProductCategoryName);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryNote", ProductCategoryNote);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryUpdateTime", ProductCategoryUpdateTime);
                    sqlCommand.Parameters.AddWithValue("@ProductCategoryUpdateBy", ProductCategoryUpdateBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowUpdated = sqlCommand.ExecuteNonQuery();
                    if (AccountRowUpdated > 0)
                    {
                        //Query Sucessfull
                        ProductUpdated = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductUpdated = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductUpdated;
        }
        #endregion
        #endregion

        #region PRODUCT TYPE
        #region Product Type List
        public DataTable ProductTypeList()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeList", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Type Data List From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Type Exist  
        public DataTable ProductTypeExist(string ProductTypeName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeExist", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductTypeName", ProductTypeName);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Type Exist In DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Type Add New 
        public Boolean ProductTypeAdd(string ProductTypeName, string ProductTypeNote,
                                            DateTime ProductTypeAddTime, string ProductTypeAddBy)
        {
            bool ProductTypeAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeAdd", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductTypeName", ProductTypeName);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeNote", ProductTypeNote);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeAddTime", ProductTypeAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeAddBy", ProductTypeAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int TypeRowAdded = sqlCommand.ExecuteNonQuery();
                    if (TypeRowAdded > 0)
                    {
                        //Query Sucessfull
                        ProductTypeAdded = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductTypeAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductTypeAdded;
        }
        #endregion

        #region Product Type Insert
        public Boolean ProductTypeInsert(int ProductTypeID, string ProductTypeName, string ProductTypeNote,
                                                DateTime ProductTypeAddTime, string ProductTypeAddBy)
        {
            bool ProductTypeInserted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeInsert", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductTypeID", ProductTypeID);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeName", ProductTypeName);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeNote", ProductTypeNote);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeAddTime", ProductTypeAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeAddBy", ProductTypeAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int TypeRowInserted = sqlCommand.ExecuteNonQuery();
                    if (TypeRowInserted > 0)
                    {
                        //Query Sucessfull
                        ProductTypeInserted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductTypeInserted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductTypeInserted;
        }
        #endregion

        #region Product Type Delete  
        public Boolean ProductTypeDelete(int ProductTypeID)
        {
            bool ProductTypeDeleted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeDelete", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductTypeID", ProductTypeID);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowDeleted = sqlCommand.ExecuteNonQuery();
                    if (AccountRowDeleted > 0)
                    {
                        //Query Sucessfull
                        ProductTypeDeleted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductTypeDeleted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductTypeDeleted;
        }
        #endregion

        #region Product Type Search
        public DataTable ProductTypeSearch(string ProductTypeSearch)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeSearch", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductTypeSearch", ProductTypeSearch);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Type Update  
        public Boolean ProductTypeUpdate(
            int ProductTypeID, string ProductTypeName, string ProductTypeNote,
            DateTime ProductTypeUpdateTime, string ProductTypeUpdateBy)
        {
            bool ProductUpdated = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductTypeUpdate", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductTypeID", ProductTypeID);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeName", ProductTypeName);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeNote", ProductTypeNote);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeUpdateTime", ProductTypeUpdateTime);
                    sqlCommand.Parameters.AddWithValue("@ProductTypeUpdateBy", ProductTypeUpdateBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowUpdated = sqlCommand.ExecuteNonQuery();
                    if (AccountRowUpdated > 0)
                    {
                        //Query Sucessfull
                        ProductUpdated = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductUpdated = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductUpdated;
        }
        #endregion
        #endregion

        #region PRODUCT COLOR
        #region Product Color List
        public DataTable ProductColorList()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorList", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Color Data List From DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Color Exist  
        public DataTable ProductColorExist(string ProductTypeName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorExist", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductColorName", ProductTypeName);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get Color Exist In DataBase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Color Add New 
        public Boolean ProductColorAdd(string ProductColorName, string ProductColorNote,
                                            DateTime ProductColorAddTime, string ProductColorAddBy)
        {
            bool ProductColorAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorAdd", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductColorName", ProductColorName);
                    sqlCommand.Parameters.AddWithValue("@ProductColorNote", ProductColorNote);
                    sqlCommand.Parameters.AddWithValue("@ProductColorAddTime", ProductColorAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductColorAddBy", ProductColorAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int ColorRowAdded = sqlCommand.ExecuteNonQuery();
                    if (ColorRowAdded > 0)
                    {
                        //Query Sucessfull
                        ProductColorAdded = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductColorAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductColorAdded;
        }
        #endregion

        #region Product Color Insert
        public Boolean ProductColorInsert(int ProductColorID, string ProductColorName, string ProductColorNote,
                                                DateTime ProductColorAddTime, string ProductColorAddBy)
        {
            bool ProductColorInserted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorInsert", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductColorID", ProductColorID);
                    sqlCommand.Parameters.AddWithValue("@ProductColorName", ProductColorName);
                    sqlCommand.Parameters.AddWithValue("@ProductColorNote", ProductColorNote);
                    sqlCommand.Parameters.AddWithValue("@ProductColorAddTime", ProductColorAddTime);
                    sqlCommand.Parameters.AddWithValue("@ProductColorAddBy", ProductColorAddBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int ColorRowInserted = sqlCommand.ExecuteNonQuery();
                    if (ColorRowInserted > 0)
                    {
                        //Query Sucessfull
                        ProductColorInserted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductColorInserted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductColorInserted;
        }
        #endregion

        #region Product Color Delete  
        public Boolean ProductColorDelete(int ProductColorID)
        {
            bool ProductColorDeleted = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorDelete", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductColorID", ProductColorID);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int ColorRowDeleted = sqlCommand.ExecuteNonQuery();
                    if (ColorRowDeleted > 0)
                    {
                        //Query Sucessfull
                        ProductColorDeleted = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductColorDeleted = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductColorDeleted;
        }
        #endregion

        #region Product Color Search
        public DataTable ProductColorSearch(string ProductColorSearch)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorSearch", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductColorSearch", ProductColorSearch);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    TrimDataTable(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return dataTable;
        }
        #endregion

        #region Product Type Update  
        public Boolean ProductColorUpdate(
            int ProductColorID, string ProductColorName, string ProductColorNote,
            DateTime ProductColorUpdateTime, string ProductColorUpdateBy)
        {
            bool ProductUpdated = false;

            using (SqlConnection sqlConnection = new SqlConnection(SqlConnections.SqlAddress()))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("ProductColorUpdate", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@ProductColorID", ProductColorID);
                    sqlCommand.Parameters.AddWithValue("@ProductColorName", ProductColorName);
                    sqlCommand.Parameters.AddWithValue("@ProductColorNote", ProductColorNote);
                    sqlCommand.Parameters.AddWithValue("@ProductColorUpdateTime", ProductColorUpdateTime);
                    sqlCommand.Parameters.AddWithValue("@ProductColorUpdateBy", ProductColorUpdateBy);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    int AccountRowUpdated = sqlCommand.ExecuteNonQuery();
                    if (AccountRowUpdated > 0)
                    {
                        //Query Sucessfull
                        ProductUpdated = true;
                    }
                    else
                    {
                        //Query Failed
                        ProductUpdated = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            return ProductUpdated;
        }
        #endregion
        #endregion

        #endregion
    }
}
