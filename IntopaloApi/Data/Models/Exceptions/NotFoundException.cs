using System;
using System.Net;

namespace IntopaloApi.Data.Models.Exceptions
{
    public class EntityNotFoundException : BaseException
    {
        const string DefaultMessage = "Entity not found";

        public EntityNotFoundException()
            : this(DefaultMessage)
        {
        }

        public EntityNotFoundException(string message)
            : this(message, null)
        {
        }

        public EntityNotFoundException(Exception ex)
            : this(DefaultMessage, ex)
        {
        }

        public EntityNotFoundException(string message, Exception ex)
            : base(message, ex, HttpStatusCode.NotFound)
        {
        }
    }
}

