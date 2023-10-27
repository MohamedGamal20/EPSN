using System.Linq;
using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class CategoriesController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
    }
}
