using System;
using System.Text.RegularExpressions;

namespace OOPEksamen
{
    class User
    {
        private int _ID;
        private string _Firstname;
        private string _Lastname;
        public string Username { get; set; }
        private string _Email;
        private decimal _Balance;
        
        //User constructer
        public User(int iD, string firstname, string lastname, string username, string email, decimal balance)
        {
            ID = iD;
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
            Balance = balance;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Firstname
        {
            get { return _Firstname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Your firstname must be declared");

                _Firstname = value;
            }
        }
        public string Lastname
        {
            get { return _Lastname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Your lastname must be declared");

                _Lastname = value;
            }
        }

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;

                if (IsValidEmail(_Email))
                    _Email = value;
                else
                    throw new ArgumentException("You must enter a valid email adress");
            }
        }
        
        private bool IsValidEmail(string email)
        {
            string[] arrEmailSplit = email.Split('@');

            string localpart = arrEmailSplit[0];
            string domain = arrEmailSplit[1];

            // Validation criteria for the localpart in email
            bool localpartValidation = Regex.IsMatch(localpart, "^[A-Za-z0-9_.-]*$");

            // Validation criteria for the domain in email
            bool domainValidation = Regex.IsMatch(domain, "^[A-Za-z0-9.-]*$");
            bool domainDotValidation = domain.Contains('.');
            bool domainStartEndValidation = Regex.IsMatch(domain[0].ToString(), "[a-zA-Z0-9]") && Regex.IsMatch(domain[domain.Length - 1].ToString(), "[a-zA-Z0-9]");


            if (localpartValidation && domainValidation && domainDotValidation && domainStartEndValidation)
                return true;
            else
                return false;
        }

        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        // Generated overrides
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ($"{Firstname} {Lastname} ({Email})");
        }

    }

}