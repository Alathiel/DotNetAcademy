using Microsoft.Data.SqlClient;
using SQLManager.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLManager.BLogic
{
    internal class DBUtility
    {
        SqlConnection sqlConnection = new();
        SqlCommand sqlCommand = new SqlCommand();
        public bool IsDbStatusValid = false;

        public DBUtility(string sqlConnectionString)
        {
            sqlConnection.ConnectionString = sqlConnectionString;
            try 
            {
                using (SqlConnection sqlcn = sqlConnection)
                {
                    sqlcn.Open();
                    sqlConnection = new SqlConnection(sqlConnectionString);
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
                using (SqlConnection sqlcn = sqlConnection) 
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
                sqlCommand.CommandText = $"Select * from SalesLT.Customer";
                sqlCommand.Connection = sqlConnection;
                sqlConnection.ConnectionString = @"Data Source=DESKTOP-I7OUE3Q\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                CheckDBOpen();
                using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                {
                    
                    if (sqlReader.HasRows)
                    {
                        DateTime aa;
                        while (sqlReader.Read())
                        {
                            if(DateTime.TryParse(sqlReader["ModifiedDate"].ToString(), out aa))
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
                CheckDBClose();
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
                sqlCommand.CommandText = "Select * from SalesLT.Customer where FirstName = @name and LastName = @lname";
                sqlCommand.Parameters.AddWithValue("@name", firstName);
                sqlCommand.Parameters.AddWithValue("@lname", lastName);
                sqlCommand.Connection = sqlConnection;
                CheckDBOpen();
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

                CheckDBClose();
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
                sqlCommand.CommandText = "Update SalesLT.Customer Set FirstName = @FirstName where CustomerID = @CustomerID";
                sqlCommand.Parameters.AddWithValue("@CustomerID", id);
                sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                sqlCommand.Connection = sqlConnection;
                CheckDBOpen();

                rowsAffected = sqlCommand.ExecuteNonQuery();


                CheckDBClose();
            }
            catch(Exception ex)
            {
                throw;
            }

            return rowsAffected;
        }


        //sostituti dello using per check se db e' open o closed
        internal void CheckDBOpen()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }
        internal void CheckDBClose()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }
    }
}
