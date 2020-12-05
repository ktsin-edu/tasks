using System;
using System.Runtime.Serialization;

namespace ExceptionsLibrary
{
    [Serializable]
    public class MyException : Exception
    {
        public MyException() : base("") { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException( SerializationInfo info, StreamingContext context) : base(info, context) { }
    }


}
