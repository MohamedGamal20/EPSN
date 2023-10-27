using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Gallery_VideoController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Gallery_Video
        public ActionResult Index()
        {
            return View(db.Gallery_Video.ToList());
        }

        // GET: Admin/Gallery_Video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Video gallery_Video = db.Gallery_Video.Find(id);
            if (gallery_Video == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Video);
        }

        // GET: Admin/Gallery_Video/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gallery_Video/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Video,Video")] Gallery_Video gallery_Video)
        {
            if (ModelState.IsValid)
            {
                db.Gallery_Video.Add(gallery_Video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery_Video);
        }

        // GET: Admin/Gallery_Video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Video gallery_Video = db.Gallery_Video.Find(id);
            if (gallery_Video == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Video);
        }

        // POST: Admin/Gallery_Video/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Video,Video")] Gallery_Video gallery_Video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery_Video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery_Video);
        }

        // GET: Admin/Gallery_Video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery_Video gallery_Video = db.Gallery_Video.Find(id);
            if (gallery_Video == null)
            {
                return HttpNotFound();
            }
            return View(gallery_Video);
        }

        // POST: Admin/Gallery_Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery_Video gallery_Video = db.Gallery_Video.Find(id);
            db.Gallery_Video.Remove(gallery_Video);
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
