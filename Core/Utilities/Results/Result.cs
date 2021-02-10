using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message)
        {
            Success = success;  // getter yapılar read only'dir sadece constructor da set edilebilir
            Message = message;
        }

        public bool Success { get; } // getter yapılar read only'dir sadece constructor da set edilebilir
        public string Message { get; }
    }
}
