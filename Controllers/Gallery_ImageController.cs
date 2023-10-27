using System.Linq;
using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class Gallery_ImageController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();

        // GET: Gallery_Image
        public ActionResult Index()
        {
            return View(db.Gallery_Image.ToList());
        }
    }
}
