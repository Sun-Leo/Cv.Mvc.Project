using Cv.Mvc.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace Cv.Mvc.Project.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCVEntities3 db = new DbCVEntities3();

        public List<T> GetAllList()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }

        public void TDelete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }

        public T TGetID(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T t)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}