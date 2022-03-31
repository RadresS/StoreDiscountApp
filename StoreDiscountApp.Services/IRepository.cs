using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreDiscountApp.Services
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(Guid Id);
        bool Insert(T T);
        bool Update(T T);
        bool Delete(Guid Id);
    }
}
