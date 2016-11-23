using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AGEPRO.GUI
{
    [Serializable]
    public class InvalidAgeproGuiParameterException : Exception
    {
        public InvalidAgeproGuiParameterException()
        {

        }
        public InvalidAgeproGuiParameterException(string message)
            : base(message)
        {

        }
        public InvalidAgeproGuiParameterException(string message, Exception innerException) 
            : base(message, innerException)
        {

        }
        protected InvalidAgeproGuiParameterException(SerializationInfo info, StreamingContext c)
            : base(info, c)
        {

        } 
    }
}
