using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class TraineesController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();
        // GET: Trainees/Create
        public ActionResult Create()
        {
            ViewBag.CouresName_Id = new SelectList(db.Courses_Name, "ID", "Name");
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,E_mail,Phone,Country,Extra_Notes,CouresName_Id")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
            }

            ViewBag.CouresName_Id = new SelectList(db.Courses_Name, "ID", "Name", trainee.CouresName_Id);
            return View(trainee);
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
