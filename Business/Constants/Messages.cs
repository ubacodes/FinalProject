using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //static verirsek new'lemiyoruz
    {
        public static string Added = "Ürün eklendi.";
        public static string NameInvalid = "Ürün ismi geçersiz.";
        public static string Listed = "Ürünler listelendi.";
        public static string MaintenanceTime = "Sistem bakımda. Bakım zamanında ürünleri listeyemezsiniz. (22:00 - 23:00)";
        public static string CategoryLimitExceded = "Categori sayısı 15'den fazla ekleyemezsiniz.";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string NameAlreadyExists = "Böyle bir isimde ürün zaten listede var.";
        public static string CategoryCountExists = "Categorideki ürün sayısı 10'dan fazla ekleyemezsiniz.";
    }
}
