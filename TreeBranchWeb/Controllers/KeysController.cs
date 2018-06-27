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

        public ActionResult Index()
        {
            var keys = _context.DichotomousKeys.ToList();
            return View(keys);
        }
    }
}