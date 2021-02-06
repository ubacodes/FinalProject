using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions; // Expression için using ettik
using System.Text;

namespace Core.DataAccess
{
    // Generic constraint = generic yapıda kısıtlama oluşturmak
    // new() :  new'lenebilir olmalı , interfaceler newlemez oldukları için IEntity koyamayız sadece onu inheritance eden classlarını kullanabiliriz product, customer, category
    public interface IEntityRepository <T> where T: class,IEntity,new()         // class : referans tip olabilir demek // IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // () içerisindeki Linq ile gelen filtreleme için işe yarayan bir ortamın ismi Expression // filter = null filtre vermeyebilirsin
        // Expression biz ProductManager'da bir sürü metot tanımlayarak filtreleme yapmaktan kurtardı
        T Get(Expression<Func<T, bool>> filter); // filtre verilmesi zorunludur
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
