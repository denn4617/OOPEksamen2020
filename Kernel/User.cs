﻿using System;
using System.Text.RegularExpressions;

namespace OOPEksamen
{
    class User : IComparable
    {
        private int UserID { get; set; }
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        public string Username { get; set; }
        private string Email { get; set; }
        public decimal Balance { get; set; }

        //User constructer
        public User(int userID, string firstname, string lastname, string username, string email, decimal balance)
        {
            if (!IsValidUsername(username))
                throw new ArgumentException("You must enter a valid username"); /*NotValidUsernameException()*/
            if (!IsValidEmail(email))
                throw new ArgumentException("You must enter a valid email address");/*NotValidEmailException()*/

            UserID = userID;
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Username = username;
            Email = email;
            Balance = balance;
        }
        

        public bool IsValidUsername(string username)
        {
            bool usernameValidation = Regex.IsMatch(username, "^[a-z0-9_]*$");
            if (usernameValidation)
                return true;
            else
                return false;
        }
  
        private bool IsValidEmail(string email)
        {
            if (!email.Contains('@'))
                return false;

            int indexOfAt = email.IndexOf('@');

            string[] arrEmailSplit = email.Split();

            string localpart = email.Substring(0, indexOfAt);
            string domain = email.Substring(indexOfAt + 1);

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

        #region Generated overrides
        public override bool Equals(object obj)
        {
            if (UserID == ((User)obj).UserID)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return UserID.GetHashCode();
        }

        public override string ToString()
        {
            return ($"{Firstname} {Lastname} ({Email}) - Balance: {Balance}");
        }
        #endregion
        public int CompareTo(Object obj)
        {
            return UserID.CompareTo(((User)obj).UserID);
        }
    }

}