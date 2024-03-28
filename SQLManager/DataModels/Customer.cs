using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SQLManager.DataModels
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string rowguid { get; set; }
        DateTime ModifiedDate { get; set; }


        public Customer()
        {
            Title = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Suffix = string.Empty;
            CompanyName = string.Empty;
            SalesPerson = string.Empty;
            EmailAddress = string.Empty;
            Phone = string.Empty;
            PasswordHash = string.Empty;
            PasswordSalt = string.Empty;
            rowguid = string.Empty;
            ModifiedDate = DateTime.MinValue;
        }

        public Customer(int CustomerId, string Title, string FirstName, string MiddleName, string LastName, string Suffix, 
            string CompanyName, string SalesPerson, string EmailAddress, string Phone, string PasswordHash, string PasswordSalt, 
            string rowguid, DateTime ModifiedDate) 
        {
            this.CustomerId = CustomerId;
            this.Title = Title;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Suffix = Suffix;
            this.CompanyName = CompanyName;
            this.SalesPerson = SalesPerson;
            this.EmailAddress = EmailAddress;
            this.Phone = Phone;
            this.PasswordHash = PasswordHash;
            this.PasswordSalt = PasswordSalt;
            this.rowguid = rowguid;
            this.ModifiedDate = ModifiedDate;
        }

        public void IsValid()
        {
           // Validator v = new Validator()
        }
    }

}
