using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{   // CrossCuttingConcerns bir Logger oluşturuyoruz interface'ler imzamala ve referans tutuculardır
    // Birden fazla alternatifi olan için interface implementasyonu yaparız
    public interface ILogger
    {

        void Log();

    }
}
