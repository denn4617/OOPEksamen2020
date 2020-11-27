using System;
using System.Runtime.Serialization;

namespace OOPEksamen
{
    [Serializable]
    internal class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(string username) : base($"User:{username} does not exist!")
        {
        }

    }
}