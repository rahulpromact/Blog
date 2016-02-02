using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RegistrationAndLogging2.Models
{

    public class BlogRepository<T> : IBlogRepository<T>where T:class
    {
        private ApplicationDbContext db;
        private DbSet<T> dbSet;

        public BlogRepository(ApplicationDbContext context)
        {
            this.db = context;
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> List()
        {
            return dbSet.AsEnumerable();
        }

        public virtual T GetBlogById(int? id)
        {
            return dbSet.Find(id);
        }

        public void InsertBlog(T entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public void DeleteBlog(int? id)
        {
            T detail= dbSet.Find(id);
            dbSet.Remove(detail);
            db.SaveChanges();
        }

        public void UpdateBlog(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}