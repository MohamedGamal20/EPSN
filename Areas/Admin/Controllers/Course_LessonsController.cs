using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Course_LessonsController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Course_Lessons
        public ActionResult Index()
        {
            var course_Lessons = db.Course_Lessons.Include(c => c.Course_units).Include(c => c.Group);
            return View(course_Lessons.ToList());
        }

        // GET: Admin/Course_Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Lessons course_Lessons = db.Course_Lessons.Find(id);
            if (course_Lessons == null)
            {
                return HttpNotFound();
            }
            return View(course_Lessons);
        }

        // GET: Admin/Course_Lessons/Create
        public ActionResult Create()
        {
            ViewBag.Unit_Id = new SelectList(db.Course_units, "ID", "Name");
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name");
            return View();
        }

        // POST: Admin/Course_Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Order_Number,PDF,Type,Unit_Id,Group_Id")] Course_Lessons course_Lessons)
        {
            if (ModelState.IsValid)
            {
                db.Course_Lessons.Add(course_Lessons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Unit_Id = new SelectList(db.Course_units, "ID", "Name", course_Lessons.Unit_Id);
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name", course_Lessons.Group_Id);
            return View(course_Lessons);
        }

        // GET: Admin/Course_Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Lessons course_Lessons = db.Course_Lessons.Find(id);
            if (course_Lessons == null)
            {
                return HttpNotFound();
            }
            ViewBag.Unit_Id = new SelectList(db.Course_units, "ID", "Name", course_Lessons.Unit_Id);
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name", course_Lessons.Group_Id);
            return View(course_Lessons);
        }

        // POST: Admin/Course_Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Order_Number,PDF,Type,Unit_Id,Group_Id")] Course_Lessons course_Lessons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Lessons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Unit_Id = new SelectList(db.Course_units, "ID", "Name", course_Lessons.Unit_Id);
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name", course_Lessons.Group_Id);
            return View(course_Lessons);
        }

        // GET: Admin/Course_Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Lessons course_Lessons = db.Course_Lessons.Find(id);
            if (course_Lessons == null)
            {
                return HttpNotFound();
            }
            return View(course_Lessons);
        }

        // POST: Admin/Course_Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Lessons course_Lessons = db.Course_Lessons.Find(id);
            db.Course_Lessons.Remove(course_Lessons);
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
