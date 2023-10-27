using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Gallery_ImageController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Gallery_Image
        public ActionResult Index()
        {
            return View(db.Gallery_Image.ToList());
        }

        // GET: Admin/Gallery_Image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Image gallery_Image = db.Gallery_Image.Find(id);
            if (gallery_Image == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Image);
        }

        // GET: Admin/Gallery_Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gallery_Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gallery_Image gallery_Image, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                gallery_Image.Image= upload.FileName;
                db.Gallery_Image.Add(gallery_Image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery_Image);
        }

        // GET: Admin/Gallery_Image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Image gallery_Image = db.Gallery_Image.Find(id);
            if (gallery_Image == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Image);
        }

        // POST: Admin/Gallery_Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gallery_Image gallery_Image, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                gallery_Image.Image = upload.FileName;
                db.Entry(gallery_Image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery_Image);
        }

        // GET: Admin/Gallery_Image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Image gallery_Image = db.Gallery_Image.Find(id);
            if (gallery_Image == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Image);
        }

        // POST: Admin/Gallery_Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery_Image gallery_Image = db.Gallery_Image.Find(id);
            db.Gallery_Image.Remove(gallery_Image);
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
