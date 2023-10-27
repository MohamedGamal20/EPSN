using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Gallery_TestimonialController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Gallery_Testimonial
        public ActionResult Index()
        {
            return View(db.Gallery_Testimonial.ToList());
        }

        // GET: Admin/Gallery_Testimonial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Testimonial gallery_Testimonial = db.Gallery_Testimonial.Find(id);
            if (gallery_Testimonial == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Testimonial);
        }

        // GET: Admin/Gallery_Testimonial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gallery_Testimonial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gallery_Testimonial gallery_Testimonial, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                gallery_Testimonial.Testimonial_Image = upload.FileName;
                db.Gallery_Testimonial.Add(gallery_Testimonial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery_Testimonial);
        }

        // GET: Admin/Gallery_Testimonial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Testimonial gallery_Testimonial = db.Gallery_Testimonial.Find(id);
            if (gallery_Testimonial == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Testimonial);
        }

        // POST: Admin/Gallery_Testimonial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gallery_Testimonial gallery_Testimonial, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                gallery_Testimonial.Testimonial_Image = upload.FileName;
                db.Entry(gallery_Testimonial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery_Testimonial);
        }

        // GET: Admin/Gallery_Testimonial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Testimonial gallery_Testimonial = db.Gallery_Testimonial.Find(id);
            if (gallery_Testimonial == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Testimonial);
        }

        // POST: Admin/Gallery_Testimonial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery_Testimonial gallery_Testimonial = db.Gallery_Testimonial.Find(id);
            db.Gallery_Testimonial.Remove(gallery_Testimonial);
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
