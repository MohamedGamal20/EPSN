using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EPSN.Controllers
{
    public class ArticlesController : Controller
    {
        private CoursesDBEntities db = new CoursesDBEntities();
        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Writer);
            return View(articles.ToList());
        }
        public ActionResult Content(int? Id)
        {
            var articleContents = db.Articles.Find(Id);
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            return View(articleContents);
        }
        public ActionResult Category(int? id)
        {
            var Category_Articles = db.Categories_Articles.Where(a => a.Article_ID == id && a.Category_ID == id).ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(Category_Articles);
        }
        public ActionResult Writer(int? id)
        {
            var writer = db.Articles.Where(a => a.Writer_ID == id).ToList();
            return View(writer);
        }
    }
}
