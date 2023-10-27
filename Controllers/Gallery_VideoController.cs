using System.Linq;
using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class Gallery_VideoController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();
        // GET: Gallery_Video
        public ActionResult Index()
        {
            return View(db.Gallery_Video.ToList());
        }
    }
}
