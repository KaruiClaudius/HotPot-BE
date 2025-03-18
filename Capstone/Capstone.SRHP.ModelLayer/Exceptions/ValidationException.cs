using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [Serializable]
        public class ServiceException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceException"/> class.
            /// </summary>
            public ServiceException()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public ServiceException(string message)
                : base(message)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceException"/> class with a specified error message
            /// and a reference to the inner exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            /// <param name="inner">The exception that is the cause of the current exception.</param>
            public ServiceException(string message, Exception inner)
                : base(message, inner)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceException"/> class with serialized data.
            /// </summary>
            /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
            /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
            protected ServiceException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
}
