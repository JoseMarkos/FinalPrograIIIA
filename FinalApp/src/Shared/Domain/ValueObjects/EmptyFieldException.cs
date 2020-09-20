using System;
using System.Runtime.Serialization;

namespace FinalApp.src.Shared.Domain.ValueObjects
{
    [Serializable]
    internal class EmptyFieldException : Exception
    {
        public EmptyFieldException()
        {
        }

        public EmptyFieldException(string message) : base(message)
        {
        }

        public EmptyFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}