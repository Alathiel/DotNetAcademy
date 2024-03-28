using Microsoft.Data.SqlClient;
using SQLManager.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLManager.BLogic
{
    internal class DBUtility
    {
        string sqlConnectionString;
        SqlCommand sqlCommand = new SqlCommand();
        public bool IsDbStatusValid = false;

        public DBUtility(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
            try 
            {
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString))
                {
                    sqlcn.Open();
                    IsDbStatusValid=true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        internal int GetTotalCustomers() {
            int totalCustomers = 0;
            try
            {
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString))
                {
                    sqlcn.Open();
                    sqlCommand.CommandText = "Select Count(CustomerID) from SalesLT.Customer";
                    sqlCommand.Connection = sqlcn;
                    totalCustomers = Convert.ToInt16(sqlCommand.ExecuteScalar());//esegue command text e torna solo il primo valore
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return totalCustomers;
        }

        internal List<Customer> getCustomers()
        {
            List<Customer> customerList = [];
            try
            {
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString))
                {
                    sqlCommand.CommandText = $"Select * from SalesLT.Customer";
                    sqlCommand.Connection = sqlcn;
                    sqlcn.Open();
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {

                        if (sqlReader.HasRows)
                        {
                            DateTime aa;
                            while (sqlReader.Read())
                            {
                                if (DateTime.TryParse(sqlReader["ModifiedDate"].ToString(), out aa))
                                    customerList.Add(new Customer(
                                        Convert.ToInt16(sqlReader["CustomerId"]),
                                        sqlReader["Title"].ToString(),
                                        sqlReader["FirstName"].ToString(),
                                        sqlReader["MiddleName"].ToString(),
                                        sqlReader["LastName"].ToString(),
                                        sqlReader["Suffix"].ToString(),
                                        sqlReader["CompanyName"].ToString(),
                                        sqlReader["SalesPerson"].ToString(),
                                        sqlReader["EmailAddress"].ToString(),
                                        sqlReader["Phone"].ToString(),
                                        sqlReader["PasswordHash"].ToString(),
                                        sqlReader["PasswordSalt"].ToString(),
                                        sqlReader["rowguid"].ToString(), aa
                                        )
                                    );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return customerList;
        }

        internal void getCustomerByCompleteName(string firstName, string lastName)
        {
            List<Customer> customerList = [];
            try
            {
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString)) 
                {
                    sqlCommand.CommandText = "Select * from SalesLT.Customer where FirstName = @name and LastName = @lname";
                    sqlCommand.Parameters.AddWithValue("@name", firstName);
                    sqlCommand.Parameters.AddWithValue("@lname", lastName);
                    sqlCommand.Connection = sqlcn;
                    using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                Console.WriteLine($"CustomerID: {sqlReader["CustomerID"]} - FirstName: {sqlReader["FirstName"]} - LastName: {sqlReader["LastName"]}");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //return customerList;
        }

        public int UpdateCustomersByID(int id, string firstName) 
        {
            int rowsAffected = 0;
            try
            {
                // sqlConnection.ConnectionString = @"Data Source=DESKTOP-I7OUE3Q\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString))
                {
                    sqlcn.Open();
                    sqlCommand.CommandText = "Update SalesLT.Customer Set FirstName = @FirstName where CustomerID = @CustomerID";
                    sqlCommand.Parameters.AddWithValue("@CustomerID", id);
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Connection = sqlcn;

                    rowsAffected = sqlCommand.ExecuteNonQuery();


                }
            }
            catch(Exception ex)
            {
                throw;
            }
            sqlCommand.Parameters.Clear();
            return rowsAffected;
        }


        internal int DeleteCustomerById(int id)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString))
                {
                    sqlCommand.CommandText = "Delete from SalesLT.Customer where CustomerID = @id";
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Connection = sqlcn;
                    sqlcn.Open();
                    affectedRows = sqlCommand.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return affectedRows;
        }

        internal int InsertCustomer()
        {
            int affectedRows = 0;
            //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction() ;
            try
            {
                using (SqlConnection sqlcn = new SqlConnection(sqlConnectionString))
                {
                    //sqlCommand.Transaction = sqlTransaction;

                    sqlcn.Open();
                    sqlCommand.CommandText = @"Insert into SalesLT.Customer (NameStyle, FirstName,LastName, PasswordHash, PasswordSalt, rowguid, ModifiedDate) values ('false','aa','aa','KJqV15wsX3PG8TS5GSddp6LFFVdd3CoRftZM/tP0+R4=','cNFKU4w=','6808b1ed-3c9a-411d-b284-9ac31164d9eb','2007-04-01 00:00:00.000')";
                    sqlCommand.Parameters.AddWithValue("@rowguid","69ae5ds3-31be-4b76-bfbb-5d23c4788bbc");
                   sqlCommand.Connection = sqlcn;
                    
                    affectedRows = sqlCommand.ExecuteNonQuery();
                    //sqlTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //sqlTransaction.Rollback();
                throw;
            }

            return affectedRows;
        }

        /*sostituti dello using per check se db e' open o closed
        internal void CheckDBOpen()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }
        internal void CheckDBClose()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }*/
    }
}
