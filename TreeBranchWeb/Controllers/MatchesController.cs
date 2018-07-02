using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using TreeBranchWeb.Models;

namespace TreeBranchWeb.Controllers
{
    public class MatchesController : Controller
    {
        private ApplicationDbContext _context;

        public MatchesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Keys/{keyName}/Matches
        public ActionResult Index(string keyName)
        {
            var key = _context.GetDichotomousKeyOrDefault(keyName);
            if (key == null) return HttpNotFound();
            ViewBag.KeyName = keyName;

            return View(key);
        }

        // GET: Keys/{keyName}/Matches/New
        public ActionResult New(string keyName)
        {
            var key = _context.GetDichotomousKeyOrDefault(keyName);
            if (key == null) return HttpNotFound();
            ViewBag.KeyName = keyName;

            if (!key.CanAddMatches())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "This key's matches are not modifiable.");
            }
            return View("MatchForm", new Match());
        }

        [HttpPost]
        public ActionResult Save()
        {
            return View();
        }
    }
}