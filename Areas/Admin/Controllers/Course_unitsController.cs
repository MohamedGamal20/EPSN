using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Course_unitsController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Course_units
        public ActionResult Index()
        {
            return View(db.Course_units.ToList());
        }

        // GET: Admin/Course_units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_units course_units = db.Course_units.Find(id);
            if (course_units == null)
            {
                return HttpNotFound();
            }
            return View(course_units);
        }

        // GET: Admin/Course_units/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Course_units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Course_units course_units)
        {
            if (ModelState.IsValid)
            {
                db.Course_units.Add(course_units);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course_units);
        }

        // GET: Admin/Course_units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_units course_units = db.Course_units.Find(id);
            if (course_units == null)
            {
                return HttpNotFound();
            }
            return View(course_units);
        }

        // POST: Admin/Course_units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Course_units course_units)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_units).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course_units);
        }

        // GET: Admin/Course_units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_units course_units = db.Course_units.Find(id);
            if (course_units == null)
            {
                return HttpNotFound();
            }
            return View(course_units);
        }

        // POST: Admin/Course_units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_units course_units = db.Course_units.Find(id);
            db.Course_units.Remove(course_units);
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
