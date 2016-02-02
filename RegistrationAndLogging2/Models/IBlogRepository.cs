using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationAndLogging2.Models
{
    public interface IBlogRepository<T>:IDisposable
    {
        IEnumerable<T> List();
        T GetBlogById(int? id);
        void InsertBlog(T entity);
        void DeleteBlog(int? id);
        void UpdateBlog(T entity);
        void Save();
    }
}