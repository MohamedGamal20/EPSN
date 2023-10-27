using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Trainee_coursesController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Trainee_courses
        public ActionResult Index()
        {
            var trainee_courses = db.Trainee_courses.Include(t => t.Cours).Include(t => t.Trainee);
            return View(trainee_courses.ToList());
        }

        // GET: Admin/Trainee_courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee_courses trainee_courses = db.Trainee_courses.Find(id);
            if (trainee_courses == null)
            {
                return HttpNotFound();
            }
            return View(trainee_courses);
        }

        // GET: Admin/Trainee_courses/Create
        public ActionResult Create()
        {
            ViewBag.Course_Id = new SelectList(db.Courses, "ID", "Name");
            ViewBag.Trainee_Id = new SelectList(db.Trainees, "ID", "Name");
            return View();
        }

        // POST: Admin/Trainee_courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Trainee_Id,Course_Id,Registration_date")] Trainee_courses trainee_courses)
        {
            if (ModelState.IsValid)
            {
                db.Trainee_courses.Add(trainee_courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Id = new SelectList(db.Courses, "ID", "Name", trainee_courses.Course_Id);
            ViewBag.Trainee_Id = new SelectList(db.Trainees, "ID", "Name", trainee_courses.Trainee_Id);
            return View(trainee_courses);
        }

        // GET: Admin/Trainee_courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee_courses trainee_courses = db.Trainee_courses.Find(id);
            if (trainee_courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "ID", "Name", trainee_courses.Course_Id);
            ViewBag.Trainee_Id = new SelectList(db.Trainees, "ID", "Name", trainee_courses.Trainee_Id);
            return View(trainee_courses);
        }

        // POST: Admin/Trainee_courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Trainee_Id,Course_Id,Registration_date")] Trainee_courses trainee_courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee_courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Id = new SelectList(db.Courses, "ID", "Name", trainee_courses.Course_Id);
            ViewBag.Trainee_Id = new SelectList(db.Trainees, "ID", "Name", trainee_courses.Trainee_Id);
            return View(trainee_courses);
        }

        // GET: Admin/Trainee_courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee_courses trainee_courses = db.Trainee_courses.Find(id);
            if (trainee_courses == null)
            {
                return HttpNotFound();
            }
            return View(trainee_courses);
        }

        // POST: Admin/Trainee_courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee_courses trainee_courses = db.Trainee_courses.Find(id);
            db.Trainee_courses.Remove(trainee_courses);
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
