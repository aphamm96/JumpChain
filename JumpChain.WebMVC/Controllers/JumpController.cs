using Jumpchain.Models.JumpModels;
using JumpChain.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpChain.WebMVC.Controllers
{
    public class JumpController : Controller
    {
        // GET: Jump
        public ActionResult JumpIndex()
        {
            var jumperId = int.Parse(User.Identity.GetUserId());
            var service = new JumpService(jumperId);
            var model = service.GetJumps();

            return View(model);
        }
        public ActionResult JumpCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JumpCreate(JumpCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            };
            var service = CreateJumpService();

            if (service.CreateJump(model))
            {
                TempData["SaveResult"] = "Jump Created"; //Creates the Jump Created popup
                return RedirectToAction("JumpIndex");
            };
            ModelState.AddModelError("", "Jump could not be created.");
            return View(model);
        }

        public ActionResult JumpDetails(int id)
        {
            var svc = CreateJumpService();
            var model = svc.GetJumpById(id);

            return View(model);
        }

        public ActionResult JumpEdit(int id)
        {
            var service = CreateJumpService();
            var detail = service.GetJumpById(id);
            var model =
                new JumpEdit
                {
                    JumpID = detail.JumpID,
                    JumpNumber = detail.JumpNumber,
                    JumpLocation = detail.JumpLocation,
                    Companions = detail.Companions,
                    JumpPerks = detail.JumpPerks,
                    JumpItems = detail.JumpItems,
                    Drawbacks = detail.Drawbacks
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JumpEdit(int id, JumpEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JumpID != id)
            {
                ModelState.AddModelError("", "Jump ID doesn't match");
                return View(model);
            }

            var service = CreateJumpService();

            if (service.UpdateJump(model))
            {
                TempData["SaveResult"] = "Jump updated";
                return RedirectToAction("JumpIndex");
            }

            ModelState.AddModelError("", "Jump could not be updated.");
            return View();
        }

        public ActionResult JumpDelete(int id)
        {
            var svc = CreateJumpService();
            var model = svc.GetJumpById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("JumpDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateJumpService();

            service.DeleteJump(id);

            TempData["SaveResult"] = "Jump has erased.";

            return RedirectToAction("JumpIndex");
        }

        private JumpService CreateJumpService()
        {
            var jumperId = int.Parse(User.Identity.GetUserId());
            var service = new JumpService(jumperId);
            return service;
        }
    }
}