using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeBranchWeb.Models;

namespace TreeBranchWeb.Controllers
{
    public class KeysController : Controller
    {
        private ApplicationDbContext _context;

        public KeysController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Keys
        public ActionResult Index()
        {
            var keys = _context.DichotomousKeys.ToList();
            return View(keys);
        }

        // GET: Keys/{keyName}/Use
        public ActionResult Use(string keyName)
        {
            var key = _context.GetDichotomousKeyOrNotFound(keyName);
            ViewBag.KeyName = keyName;
            return View(key);
        }

        // GET: Keys/{keyName}/View
        public ActionResult View(string keyName)
        {
            var key = _context.GetDichotomousKeyOrNotFound(keyName);
            ViewBag.KeyName = keyName;
            return View(key);
        }
    }
}