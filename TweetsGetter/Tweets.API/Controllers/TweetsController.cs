using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweets.API.Controllers
{
    public class TweetsController : Controller
    {
        // GET: Tweets
        public ActionResult Index()
        {
            return View();
        }
    }
}