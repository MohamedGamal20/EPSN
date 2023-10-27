using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Courses_NameController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Courses_Name
        public ActionResult Index()
        {
            return View(db.Courses_Name.ToList());
        }

        // GET: Admin/Courses_Name/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses_Name courses_Name = db.Courses_Name.Find(id);
            if (courses_Name == null)
            {
                return HttpNotFound();
            }
            return View(courses_Name);
        }

        // GET: Admin/Courses_Name/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Courses_Name/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Courses_Name courses_Name)
        {
            if (ModelState.IsValid)
            {
                db.Courses_Name.Add(courses_Name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses_Name);
        }

        // GET: Admin/Courses_Name/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses_Name courses_Name = db.Courses_Name.Find(id);
            if (courses_Name == null)
            {
                return HttpNotFound();
            }
            return View(courses_Name);
        }

        // POST: Admin/Courses_Name/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Courses_Name courses_Name)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses_Name).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses_Name);
        }

        // GET: Admin/Courses_Name/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses_Name courses_Name = db.Courses_Name.Find(id);
            if (courses_Name == null)
            {
                return HttpNotFound();
            }
            return View(courses_Name);
        }

        // POST: Admin/Courses_Name/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses_Name courses_Name = db.Courses_Name.Find(id);
            db.Courses_Name.Remove(courses_Name);
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
