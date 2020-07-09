using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpChain.WebMVC.Controllers
{
    public class JumpListController : Controller
    {
        // GET: JumpList
        public ActionResult Index()
        {
            return View();
        }
    }
}