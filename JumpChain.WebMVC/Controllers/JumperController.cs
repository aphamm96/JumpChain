using Jumpchain.Models;
using JumpChain.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpChain.WebMVC.Controllers
{
    [Authorize]
    public class JumperController : Controller
    {
        //Will have to include authorization here somewhere
        //In order to see two different menus, one with jumpers and jumps that can be edited, and one that can't for sharing purposes
        //Will have to look more into how to do that
        //Potentially will have to create two different indexes. One involving JumperIndex and one OpenJumperIndex, with the latter not having links to create and edit
        //Potential to not work that way, but it is worth a shot, then again, the create and such would require authorization
        // GET: Jumper
        public ActionResult JumperIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JumperService(userId);
            var model = service.GetJumpers();

            return View(model);
        }
        public ActionResult JumperCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JumperCreate(JumperCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            };
            var service = CreateJumperService();

            if (service.CreateJumper(model))
            {
                TempData["SaveResult"] = "Jumper Created"; //Creates the Jumper Created popup
                return RedirectToAction("JumperIndex");
            };
            ModelState.AddModelError("", "Jumper could not be created.");
            return View(model);
        }

        public ActionResult JumperDetails(int id)
        {
            var svc = CreateJumperService();
            var model = svc.GetJumperById(id);

            return View(model);
        }

        [HttpGet]
        public ActionResult JumpList(int id)
        {
            var svc = CreateJumperService();
            var model = svc.GetJumpsForJumper(id);

            return View(model);
        }

        public ActionResult JumperEdit(int id)
        {
            var service = CreateJumperService();
            var detail = service.GetJumperById(id);
            var model =
                new JumperEdit
                {
                    JumperID = detail.JumperID,
                    JumperName = detail.JumperName,
                    JumperNotes = detail.JumperNotes
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JumperEdit(int id, JumperEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.JumperID != id)
            {
                ModelState.AddModelError("", "Jumper ID doesn't match");
                return View(model);
            }

            var service = CreateJumperService();

            if (service.UpdateJumper(model))
            {
                TempData["SaveResult"] = "Jumper updated";
                    return RedirectToAction("JumperIndex");
            }

            ModelState.AddModelError("", "Jumper could not be updated.");
            return View();
        }

        public ActionResult JumperDelete(int id)
        {
            var svc = CreateJumperService();
            var model = svc.GetJumperById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("JumperDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateJumperService();

            service.DeleteJumper(id);

            TempData["SaveResult"] = "Jumper has returned home.";

            return RedirectToAction("JumperIndex");
        }

        private JumperService CreateJumperService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JumperService(userId);
            return service;
        }
    }
}