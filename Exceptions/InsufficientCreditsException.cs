using System;
using System.Runtime.Serialization;

namespace OOPEksamen
{
    [Serializable]
    internal class InsufficientCreditsException : Exception
    {
        private User user;
        private Product product;

        public InsufficientCreditsException()
        {
        }

        public InsufficientCreditsException(string message) : base(message)
        {
        }

        public InsufficientCreditsException(User user, Product product) 
            : base("Due to insufficient funds, the transaction of " + product.Name + " failed for " + user.Username + "." )
        {
            
        }

        public InsufficientCreditsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientCreditsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}