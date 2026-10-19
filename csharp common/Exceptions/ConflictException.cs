using System;

namespace CleanArchitecture.Common.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public string? Code { get; }
        public string? Field { get; }

        public ConflictException(string code, string message, string? field = null) : base(message)
        {
            Code = code;
            Field = field;
        }

        public ConflictException(string message) : base(message)
        {
        }
    }
}