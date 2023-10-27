using System.Linq;
using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class CourseController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }
        public PartialViewResult Category()
        {
            return PartialView(db.Categories.ToList());
        }
        public ActionResult Course(int? id)
        {
            return View(db.Courses.Where(a => a.Category_Id == id).ToList());
        }
    }
}