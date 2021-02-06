using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    // artık DataAccess içerisindeki EntityFramework klasörü içerisinde EfProductdal gibi veri yönetimi katmanlarını tek bir kere CRUD işlemlerini burada yapıp diğerlerinden 
    // inheritance ederek kullanıcaz

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity: class, IEntity, new() where TContext: DbContext, new() 
        // bana parametre olarak bir entity (tablo yapısı) ve onu bağlayacağımız bir context (veri tabanı bağlantısı) yapısı ver
    {
        public void Add(TEntity entity)
        {
            // using yapısı : içerisine yazılan nesneler using işi bitince çöpçüye gidip işim bitti beni silebilirsin diyor 
            // bu using = IDispossable pattern implementation  of C# 'dır. Yukarıdaki using kütüphane mantığından farklı birşeydir.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
