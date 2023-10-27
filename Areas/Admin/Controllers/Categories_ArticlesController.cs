using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EPSN;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Categories_ArticlesController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Categories_Articles
        public ActionResult Index()
        {
            var categories_Articles = db.Categories_Articles.Include(c => c.Article).Include(c => c.Category_Article);
            return View(categories_Articles.ToList());
        }

        // GET: Admin/Categories_Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Articles categories_Articles = db.Categories_Articles.Find(id);
            if (categories_Articles == null)
            {
                return HttpNotFound();
            }
            return View(categories_Articles);
        }

        // GET: Admin/Categories_Articles/Create
        public ActionResult Create()
        {
            ViewBag.Article_ID = new SelectList(db.Articles, "ID_Article", "Name_Article");
            ViewBag.Category_ID = new SelectList(db.Category_Article, "ID_ArticleCategory", "Name_ArticleCategory");
            return View();
        }

        // POST: Admin/Categories_Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_ID,Article_ID,Creationdate_Article")] Categories_Articles categories_Articles)
        {
            if (ModelState.IsValid)
            {
                db.Categories_Articles.Add(categories_Articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Article_ID = new SelectList(db.Articles, "ID_Article", "Name_Article", categories_Articles.Article_ID);
            ViewBag.Category_ID = new SelectList(db.Category_Article, "ID_ArticleCategory", "Name_ArticleCategory", categories_Articles.Category_ID);
            return View(categories_Articles);
        }

        // GET: Admin/Categories_Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Articles categories_Articles = db.Categories_Articles.Find(id);
            if (categories_Articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Article_ID = new SelectList(db.Articles, "ID_Article", "Name_Article", categories_Articles.Article_ID);
            ViewBag.Category_ID = new SelectList(db.Category_Article, "ID_ArticleCategory", "Name_ArticleCategory", categories_Articles.Category_ID);
            return View(categories_Articles);
        }

        // POST: Admin/Categories_Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_ID,Article_ID,Creationdate_Article")] Categories_Articles categories_Articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories_Articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Article_ID = new SelectList(db.Articles, "ID_Article", "Name_Article", categories_Articles.Article_ID);
            ViewBag.Category_ID = new SelectList(db.Category_Article, "ID_ArticleCategory", "Name_ArticleCategory", categories_Articles.Category_ID);
            return View(categories_Articles);
        }

        // GET: Admin/Categories_Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Articles categories_Articles = db.Categories_Articles.Find(id);
            if (categories_Articles == null)
            {
                return HttpNotFound();
            }
            return View(categories_Articles);
        }

        // POST: Admin/Categories_Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories_Articles categories_Articles = db.Categories_Articles.Find(id);
            db.Categories_Articles.Remove(categories_Articles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
