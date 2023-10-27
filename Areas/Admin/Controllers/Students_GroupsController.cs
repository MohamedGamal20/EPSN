using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Students_GroupsController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Admin/Students_Groups
        public ActionResult Index()
        {
            var students_Groups = db.Students_Groups.Include(s => s.Group).Include(s => s.Student);
            return View(students_Groups.ToList());
        }

        // GET: Admin/Students_Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Groups students_Groups = db.Students_Groups.Find(id);
            if (students_Groups == null)
            {
                return HttpNotFound();
            }
            return View(students_Groups);
        }

        // GET: Admin/Students_Groups/Create
        public ActionResult Create()
        {
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name");
            ViewBag.Student_Id = new SelectList(db.Students, "ID", "e_mail");
            return View();
        }

        // POST: Admin/Students_Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Group_Id,Student_Id,Creation_date")] Students_Groups students_Groups)
        {
            if (ModelState.IsValid)
            {
                db.Students_Groups.Add(students_Groups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name", students_Groups.Group_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "ID", "e_mail", students_Groups.Student_Id);
            return View(students_Groups);
        }

        // GET: Admin/Students_Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Groups students_Groups = db.Students_Groups.Find(id);
            if (students_Groups == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name", students_Groups.Group_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "ID", "e_mail", students_Groups.Student_Id);
            return View(students_Groups);
        }

        // POST: Admin/Students_Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Group_Id,Student_Id,Creation_date")] Students_Groups students_Groups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students_Groups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Group_Id = new SelectList(db.Groups, "ID", "Name", students_Groups.Group_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "ID", "e_mail", students_Groups.Student_Id);
            return View(students_Groups);
        }

        // GET: Admin/Students_Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Groups students_Groups = db.Students_Groups.Find(id);
            if (students_Groups == null)
            {
                return HttpNotFound();
            }
            return View(students_Groups);
        }

        // POST: Admin/Students_Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students_Groups students_Groups = db.Students_Groups.Find(id);
            db.Students_Groups.Remove(students_Groups);
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
