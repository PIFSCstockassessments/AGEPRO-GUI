using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AGEPRO.GUI
{
    [Serializable]
    public class InvalidGeneralParameterException : Exception
    {
        public InvalidGeneralParameterException()
        {

        }
        public InvalidGeneralParameterException(string message)
            : base(message)
        {

        }
        public InvalidGeneralParameterException(string message, Exception innerException) 
            : base(message, innerException)
        {

        }
        protected InvalidGeneralParameterException(SerializationInfo info, StreamingContext c)
            : base(info, c)
        {

        } 
    }
}
