using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace org.random.JSONRPC
{
    [Serializable]
    class RandomJSONRPCException : Exception
    {
        public RandomJSONRPCException(string message)
            : base(message) { }

        public RandomJSONRPCException(string message, Exception innerException)
            : base(message, innerException) { }

        // Make sure you include this so your Excpetion is properly Serializable
        protected RandomJSONRPCException(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt) { }
    }

    [Serializable]
    class RandomJSONRPCRunTimeException : Exception
    {
        public RandomJSONRPCRunTimeException(string message)
            : base(message) { }

        public RandomJSONRPCRunTimeException(string message, Exception innerException)
            : base(message, innerException) { }
        
        protected RandomJSONRPCRunTimeException(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt) { }
    }
}
