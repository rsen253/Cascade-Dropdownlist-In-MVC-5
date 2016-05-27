using Dropdown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dropdown.Context;

namespace Dropdown.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        public ActionResult Submit()
        {
            List<Country> allCountry = new List<Country>();
            List<State> allState = new List<State>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                allCountry = dbContext.Country.OrderBy(a => a.CountryName).ToList();
            }
            ViewBag.CountryID = new SelectList(allCountry, "CountryID", "CountryName");
            ViewBag.StateID = new SelectList(allState, "StateID", "StateName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(FeedBack fb)
        {
            List<Country> allCountry = new List<Country>();
            List<State> allState = new List<State>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                allCountry = dbContext.Country.OrderBy(a => a.CountryName).ToList();
                if (fb.CountryID > 0)
                {
                    allState = dbContext.State.Where(a => a.CountryID.Equals(fb.CountryID)).OrderBy(a => a.StateName).ToList();
                }
            }
            ViewBag.CountryID = new SelectList(allCountry, "CountryID", "CountryName",fb.CountryID);
            ViewBag.StateID = new SelectList(allState, "StateID", "StateName",fb.StateID);
            if (ModelState.IsValid)
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    dbContext.Feedback.Add(fb);
                    dbContext.SaveChanges();
                    ModelState.Clear();
                    fb = null;
                    ViewBag.Message = "Successfully Submitted";
                }
            }
            else
            {
                ViewBag.Message = "Faild ! try it again";
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetStates(FeedBack feedback)
        {
            List<State> allstates = new List<State>();
            var CountryID = feedback.CountryID;
            int ID = CountryID;
            if (CountryID > 0)
            {
                using (DatabaseContext dbcontext = new DatabaseContext())
                {
                    allstates = dbcontext.State.Where(a => a.CountryID.Equals(ID)).OrderBy(a => a.StateName).ToList();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = allstates,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
    }
}