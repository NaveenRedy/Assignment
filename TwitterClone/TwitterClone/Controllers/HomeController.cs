using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class HomeController : Controller
    {

        TwitterDBEntities33 TE = new TwitterDBEntities33();

        // The Following method is used to display the main timeline of the followers and following tweets and info..
        [HttpGet]
        public ActionResult Index()
        {
            
            
            List<object> lstUserInfo = new List<object>();
            lstUserInfo.Add(TE.UserInfoes.ToList());
             
            return View(lstUserInfo);
        }


        //Method used to search by using the emailid or name

        [HttpPost]
        
        public ActionResult Index(string searchTerm)
        {
         
            List<object> LstUserInfo = new List<object>();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LstUserInfo.Add(TE.UserInfoes.ToList());
            }
            else
            {
                LstUserInfo.Add(TE.UserInfoes.Where(x => x.UserName.StartsWith(searchTerm)).ToList());
            }


            return View(LstUserInfo);
        }

        // Json result search
        public JsonResult GetUser(string term)
        {
           
            List<string> LstUser;

            LstUser = TE.UserInfoes.Where(x => x.UserName.StartsWith(term)).Select(y => y.UserName).ToList();



            return Json(LstUser, JsonRequestBehavior.AllowGet);
        }

      //  creating a user
       [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

      //  Post the details to the server
       [HttpPost]
        public ActionResult CreateUser(RegisterUser RegUser)

        {
            TwitterDBEntities33 TE = new TwitterDBEntities33();
            TE.Entry(RegUser).State = System.Data.Entity.EntityState.Added;
            TE.SaveChanges();

            return RedirectToAction("Index");

        }

        // Tweets method used to post the tweets to the server
        [HttpGet]
        public ActionResult Tweet()
        {
            TwitterDBEntities33 TE = new TwitterDBEntities33();
            List<object> lstTweet = new List<object>();
            lstTweet.Add(TE.Tweets.ToList());

            return View(lstTweet);
        }

        [HttpPost]
        public ActionResult Tweet(FormCollection formCollection)
        {
            TwitterDBEntities33 TDb = new TwitterDBEntities33();
            Tweet Twt = new Tweet();
            Twt.Tweet1 = formCollection["TxtMsg"];

           
            TDb.Entry(Twt).State = System.Data.Entity.EntityState.Added;
            TDb.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult GetInfosearch(string term)
        {
            TwitterDBEntities33 TE = new TwitterDBEntities33();
            List<string> LstUserInfo;
            LstUserInfo = TE.UserInfoes.Where(x => x.UserName.StartsWith(term)).Select(x => x.UserName).Distinct().ToList();
            return Json(LstUserInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Sample()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}