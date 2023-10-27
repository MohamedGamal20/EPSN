using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EPSN;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Category_ArticleController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Category_Article
        public ActionResult Index()
        {
            return View(db.Category_Article.ToList());
        }

        // GET: Admin/Category_Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Article category_Article = db.Category_Article.Find(id);
            if (category_Article == null)
            {
                return HttpNotFound();
            }
            return View(category_Article);
        }

        // GET: Admin/Category_Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category_Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category_Article category_Article, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                category_Article.Image_ID= upload.FileName;
                db.Category_Article.Add(category_Article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_Article);
        }

        // GET: Admin/Category_Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Article category_Article = db.Category_Article.Find(id);
            if (category_Article == null)
            {
                return HttpNotFound();
            }
            return View(category_Article);
        }

        // POST: Admin/Category_Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category_Article category_Article, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                category_Article.Image_ID = upload.FileName;
                db.Entry(category_Article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_Article);
        }

        // GET: Admin/Category_Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Article category_Article = db.Category_Article.Find(id);
            if (category_Article == null)
            {
                return HttpNotFound();
            }
            return View(category_Article);
        }

        // POST: Admin/Category_Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_Article category_Article = db.Category_Article.Find(id);
            db.Category_Article.Remove(category_Article);
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
