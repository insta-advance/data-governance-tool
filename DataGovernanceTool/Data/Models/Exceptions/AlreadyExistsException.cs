using System;
using System.Net;

namespace DataGovernanceTool.Data.Models.Exceptions
{
    public class EntityAlreadyExistsException : BaseException
    {
        const string DefaultMessage = "Entity already exists";

        public EntityAlreadyExistsException()
            : this(DefaultMessage)
        {
        }

        public EntityAlreadyExistsException(string message)
            : this(message, null)
        {
        }

        public EntityAlreadyExistsException(Exception ex)
            : this(DefaultMessage, ex)
        {
        }

        public EntityAlreadyExistsException(string message, Exception ex)
            : base(message, ex, HttpStatusCode.NotFound)
        {
        }
    }
}

