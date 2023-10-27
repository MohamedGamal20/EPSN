using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Trainer_CoursesController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Trainer_Courses
        public ActionResult Index()
        {
            var trainer_Courses = db.Trainer_Courses.Include(t => t.Cours).Include(t => t.Trainer);
            return View(trainer_Courses.ToList());
        }

        // GET: Admin/Trainer_Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer_Courses trainer_Courses = db.Trainer_Courses.Find(id);
            if (trainer_Courses == null)
            {
                return HttpNotFound();
            }
            return View(trainer_Courses);
        }

        // GET: Admin/Trainer_Courses/Create
        public ActionResult Create()
        {
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "Name");
            ViewBag.Trainer_ID = new SelectList(db.Trainers, "ID", "Name");
            return View();
        }

        // POST: Admin/Trainer_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trainer_ID,Course_ID,Creation_date")] Trainer_Courses trainer_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Trainer_Courses.Add(trainer_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "Name", trainer_Courses.Course_ID);
            ViewBag.Trainer_ID = new SelectList(db.Trainers, "ID", "Name", trainer_Courses.Trainer_ID);
            return View(trainer_Courses);
        }

        // GET: Admin/Trainer_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer_Courses trainer_Courses = db.Trainer_Courses.Find(id);
            if (trainer_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "Name", trainer_Courses.Course_ID);
            ViewBag.Trainer_ID = new SelectList(db.Trainers, "ID", "Name", trainer_Courses.Trainer_ID);
            return View(trainer_Courses);
        }

        // POST: Admin/Trainer_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trainer_ID,Course_ID,Creation_date")] Trainer_Courses trainer_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ID = new SelectList(db.Courses, "ID", "Name", trainer_Courses.Course_ID);
            ViewBag.Trainer_ID = new SelectList(db.Trainers, "ID", "Name", trainer_Courses.Trainer_ID);
            return View(trainer_Courses);
        }

        // GET: Admin/Trainer_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer_Courses trainer_Courses = db.Trainer_Courses.Find(id);
            if (trainer_Courses == null)
            {
                return HttpNotFound();
            }
            return View(trainer_Courses);
        }

        // POST: Admin/Trainer_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer_Courses trainer_Courses = db.Trainer_Courses.Find(id);
            db.Trainer_Courses.Remove(trainer_Courses);
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
