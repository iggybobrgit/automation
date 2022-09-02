using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.AdditionalMethods
{
    public class User
    {
      
        public bool TitleMr { get; set; } = false;
        public bool TitleMrs { get; set; } = false;
        public string FirstNamePersonal { get; set; }
        public string LastNamePersonal { get; set; }
        public string Email { get; set; }

        private string password;
        public string Password
        {
            set
            {
                if (value.Length >= 5)
                {
                    password = value;
                }
                else
                {
                    throw new InvalidOperationException("Password should be more than 4 characters");
                }
            }
            get
            {
                return password;
            }
        }

        public string DayDOB { get; set; }
        public DateOfBirthMonth? MonthDOB { get; set; }
        public string YearDOB { get; set; }
        public bool Newsletter { get; set; } = false;
        public bool SpecialOffers { get; set; } = false;
        public string FirstNameAddress { get; set; }
        public string LastNameAddress { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; } = "United States";
        public string AdditionalInformation { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string AddressAlias { get; set; }
    }
}