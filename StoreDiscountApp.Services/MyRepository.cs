using StoreDiscountApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreDiscountApp.Services
{
    public abstract class MyRepository<T> : IDisposable, IRepository<T> where T : IEntity, new()
    {
        public bool Delete(Guid Id)
        {
            var List_ = GetAll();
            List_.RemoveAll(x => x.Id == Id);
            return List_.WriteFile<T>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<T> GetAll()
        {
            return Util.ReadFile<T>();
        }

        public T GetById(Guid Id)
        {
            return GetAll()?.FirstOrDefault(x => x.Id == Id);
        }

        public bool Insert(T T)
        {
            var List_ = GetAll() ?? new List<T>();
            List_?.Add(T);
           return List_.WriteFile<T>();
        }

        public bool Update(T T)
        {
            var List_ = GetAll();
            List_.RemoveAll(x => x.Id == T.Id);
            List_?.Add(T);
            return List_.WriteFile<T>();
        }
    }
}
