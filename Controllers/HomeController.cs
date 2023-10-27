using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Dynamic;
using EPSN.Models;
using System.Collections.Generic;

namespace EPSN.Controllers
{
    public class HomeController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();
        private List<Article> GetToSellingItems(int count)
        {
            return db.Articles.OrderByDescending(i => i.Categories_Articles.Count()).Take(count).ToList();
        }
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.courseList = GetCours();
            dy.articleList = GetArticles();
            dy.testimonialList = GetGallery_Testimonials();
            return View(dy);
        }
        public List<Cours> GetCours()
        {
            List<Cours> cours = db.Courses.ToList();
            return cours;
        }
        public List<Article> GetArticles()
        {
            List<Article> articles = db.Articles.ToList();
            articles = GetToSellingItems(3);
            return articles;
        }
        public List<Gallery_Testimonial> GetGallery_Testimonials()
        {
            List<Gallery_Testimonial> gallery_Testimonials = db.Gallery_Testimonial.ToList();
            return gallery_Testimonials;
        }
        public ActionResult Info(int? Id)
        {
            var courseInfo = db.Courses.Find(Id);
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            return View(courseInfo);
        }
        [Authorize(Roles = "Admin ,Trainee")]
        public ActionResult Lessons(int? id)
        {
            var check = db.Course_Lessons.Where(a => a.Group_Id == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(check);
        }

        public ActionResult Contactus()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Certificates(String searching)
        {
            return View(db.Certifications.Where(x => x.ID_No.Contains(searching) || searching == null).ToList());
        }
        public ActionResult Category()
        {
            var categoryList = db.Categories.ToList();
            SelectList list = new SelectList(categoryList, "ID", "Name");
            ViewBag.categorylistname = list;
            return View();
        }
        public ActionResult Articles()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }

    }
}
