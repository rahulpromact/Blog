using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogging2.Models;
using Microsoft.AspNet.Identity;

namespace RegistrationAndLogging2.Controllers
{[Authorize]
    public class BlogsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        
      private readonly IBlogRepository<Blog> _blogRepository;


      public BlogsController(IBlogRepository<Blog> blogRepository)
      {
         this._blogRepository = blogRepository;
      }
      public BlogsController()
      {
          this._blogRepository = new BlogRepository<Blog>(new ApplicationDbContext());

      }
    

        // GET: Blogs
        public ActionResult Index()
        {
                          

           //var list= db.Blog.ToList();
             
           /* var query=from title in db.Blog.Include("ApplicationUser")
                      where(title.Blogtitle.StartsWith("Hello"))
                      orderby title.BlogDate
                      group title by  title.User into gr
                     
                      select gr.ToList();
            ViewBag.Entry = query.ToList();*/

            var query2 = _blogRepository.List().Where(m => m.Blogtitle.StartsWith("Hello")).OrderBy(o => o.BlogDate).GroupBy(w => w.User).Select(n => n.ToList());
            ViewBag.Entry = query2.ToList();
 
                return View(_blogRepository.List());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Blogtitle,BlogDescription")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.BlogDate = DateTime.Now;
                _blogRepository.InsertBlog(blog);
                //UserId = User.Identity.GetUserId();
                blog.UserId = User.Identity.GetUserId();

               // blog.UserName = User.Identity.GetUserName();
                _blogRepository.Save();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Blogtitle,BlogDescription,UserId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.UpdateBlog(blog);
                _blogRepository.Save();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Blog blog = _blogRepository.GetBlogById(id);
            _blogRepository.DeleteBlog(id);
            _blogRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _blogRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public string UserId { get; set; }
    }
}
