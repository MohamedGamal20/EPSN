using EPSN.Areas.Admin.Model;
using EPSN.Services;
using System.Web.Mvc;

namespace EPSN.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        // GET: Admin/Account/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginInfo)
        {
            var adminservice = new AdminServive();
            var isLoggedIn = adminservice.Login(loginInfo.Email, loginInfo.Password);

            if (isLoggedIn)
            {
                return RedirectToAction("Index", "Course");
            }
            else
            {
                loginInfo.Message = "Email or Password is incorrect!";
                return View(loginInfo);
            }

        }
    }
}