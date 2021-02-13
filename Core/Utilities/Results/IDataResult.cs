using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; } // IResult içerisindeki success ve message' a ek olarak sen dataları da barındırabilirsin generic yapıyla barındır ama 

    }
}
