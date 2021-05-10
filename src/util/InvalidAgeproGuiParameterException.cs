using System;
using System.Runtime.Serialization;

namespace Nmfs.Agepro.Gui
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
