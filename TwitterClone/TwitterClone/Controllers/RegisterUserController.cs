using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: Register


        TwitterDBEntities33 TE = new TwitterDBEntities33();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(RegisterUser RegUser)

        {
            
            TE.Entry(RegUser).State = System.Data.Entity.EntityState.Added;
            TE.SaveChanges();
      
            return View("Index");

        }


        public ActionResult RegisterUser(RegisterUser RegUser)
            
        {


            try
            {
                
                TE.Entry(RegUser).State = System.Data.Entity.EntityState.Added;
                TE.SaveChanges();
                //   return RedirectToAction("Index");
                return View("Index");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

           
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(RegisterUser User)
        {
            using (TwitterDBEntities33 TE = new TwitterDBEntities33())
            {

            //    RegisterUser UserReg = new Models.RegisterUser();
              var    UserReg = TE.RegisterUsers.SingleOrDefault(u => u.Emaild == User.Emaild && u.Password == User.Password);
                if (UserReg != null)
                {
                    Session["UserId"] = UserReg.Id.ToString();
                    Session["UserName"] = UserReg.Name.ToString();
                    // Session["Password"] = UserReg.Password.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "User name or password is wrong");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                // return View();
                return RedirectToAction("Index","Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("LogIn");
            }


        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("CreateUser", "Home");
        }

    }
}