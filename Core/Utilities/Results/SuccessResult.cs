using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result//(base)
    {
        public SuccessResult(string message) : base(true, message) // base class'ın içerisindeki mesaj alan constructor yapıya true ve SuccessResult(parametre) olarak girilen messajı yolla
        {

        }

        public SuccessResult() : base(true) { } // base class'ın içerisindeki mesaj vermeden çalışan constructor yapıya true yolla

    }
}
