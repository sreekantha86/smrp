using pms.domain;
using pms.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prms.web.Controllers
{
    public class UserController : BaseController
    {
        UserRepository _repo = new UserRepository();
        public ActionResult Index()
        {
            if (TempData["message"] != null)
            {
                ViewBag.submitResult = TempData["message"].ToString();
            }
            List<User> model = _repo.GetuserList();
            return View(model);
        }
        public ActionResult Create()
        {
            if(TempData["message"]!=null)
            {
                ViewBag.submitResult = TempData["message"].ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(User model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.usrPassword = Helpers.Cryptography.GetSHA1String(model.usrPassword);
            int affectedRows = _repo.CreateUser(model);
            if(affectedRows >0)
            {
                TempData["message"] = "User Saved Successfully";
            }
            return RedirectToAction("Create");
        }
        public ActionResult Edit(string Id)
        {
            User model = _repo.GetUserById(Id);
            model.confirmPassword = model.usrPassword = "";
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.usrPassword != "")
            {
                model.usrPassword = Helpers.Cryptography.GetSHA1String(model.usrPassword);
            }           
            int affectedRows = _repo.EditUser(model);
            if (affectedRows > 0)
            {
                TempData["message"] = "User Updated Successfully";
            }
            return RedirectToAction("Index");
        }
    }
}