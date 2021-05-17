using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic constraint (Kısıtlama) , T parametresşne kısıtlama getirdik.
    //Class : Böyle yazarsak referans tip olabilir demiş oluruz.IEntity dersek eğer IEntity veya onun miras aldığı sınıflar olabilir demiş oluruz.
    //new() dersek interface new leme yapılamadığı için sadece implemente edildiği new yapılabilen sınıflar gelebilir demiş oluruz. 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Filtreli arama yapabilmek için bu şekilde yazılır.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //tek bir detay getirmek için kullanılır.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
