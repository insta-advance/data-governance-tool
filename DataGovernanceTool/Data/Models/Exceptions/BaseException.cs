using System;
using System.Net;

namespace DataGovernanceTool.Data.Models.Exceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public BaseException(string message, Exception ex, HttpStatusCode statusCode)
            : base(message, ex)
        {
            StatusCode = statusCode;
        }
    }
}
