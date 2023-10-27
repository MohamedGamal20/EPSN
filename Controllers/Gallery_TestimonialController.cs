using System.Linq;
using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class Gallery_TestimonialController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();
        // GET: Gallery_Testimonial
        public ActionResult Index()
        {
            return View(db.Gallery_Testimonial.ToList());
        }
    }
}
