using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleRotas.Exceptions
{
    public class ExceptionApp : Exception
    {
            public ExceptionApp() { }
            public ExceptionApp(string message) : base(message) { }
            public ExceptionApp(string message, Exception inner) : base(message, inner) { }
            protected ExceptionApp(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
