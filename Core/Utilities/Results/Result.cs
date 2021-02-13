using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;  // getter yapılar read only'dir sadece constructor da set edilebilir
        }
        // overloading yapmamızın sebebi ProductManager'dan gelen parametreler sadece başarılı olarak gelebilir ekrana herhangi bir mesaj yazdırmak istemediğimiz metotların içerisini de karşılayabilsin
        public Result(bool success, string message) : this(success) // this bu classın kendisi demektir. 
        {
            // getter yapılar read only'dir sadece constructor da set edilebilir
            Message = message;
        }
        

        public bool Success { get; } // getter yapılar read only'dir sadece constructor da set edilebilir
        public string Message { get; }
    }
}
