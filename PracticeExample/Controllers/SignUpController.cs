using PracticeExample.Models;
using System.Web.Mvc;

namespace PracticeExample.Controllers
{
    public class SignUpController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ProductCategories");
            }
            else
                return View();
        }

    }
}