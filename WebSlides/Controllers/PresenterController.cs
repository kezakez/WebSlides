using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerUpdate.Models;

namespace ServerUpdate.Controllers
{
    public class PresenterController : Controller
    {
        //
        // GET: /Presenter/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Presenter/Next

        [HttpPost]
        public ActionResult Next(FormCollection collection)
        {
            try
            {
                Follower followerModel = new Follower();
                followerModel.PageNumber++;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Previous(FormCollection collection)
        {
            try
            {
                Follower followerModel = new Follower();
                followerModel.PageNumber--;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
