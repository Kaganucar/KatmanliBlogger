using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : class
    {
        public bool Delete(Expression<Func<TEntity, bool>> where)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<TEntity>().Remove(GetById(where));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if (where is not null)
                {
                    return db.Set<TEntity>().AsNoTracking().Where(where).ToList();
                }
                else
                {
                    return db.Set<TEntity>().AsNoTracking().ToList();
                }
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> where)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Set<TEntity>().AsNoTracking().Where(where).FirstOrDefault();
            }
        }

        public bool Insert(TEntity data)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<TEntity>().Add(data);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Update(TEntity data)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<TEntity>().Update(data);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
