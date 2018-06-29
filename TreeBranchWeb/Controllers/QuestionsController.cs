using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeBranchWeb.Migrations;
using TreeBranchWeb.Models;

namespace TreeBranchWeb.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Keys/{keyName}/Questions
        public ActionResult Index(string keyName)
        {
            var key = _context.GetDichotomousKeyOrNotFound(keyName);
            ViewBag.KeyName = keyName;
            return View(key);
        }

        // GET: Keys/{keyName}/Questions/New
        public ActionResult New(string keyName)
        {
            _context.GetDichotomousKeyOrNotFound(keyName);
            ViewBag.KeyName = keyName;
            return View("QuestionForm", new Question());
        }

        [HttpPost]
        public ActionResult Save(Question question, string keyName, string submitAction)
        {
            if (submitAction.Equals("save"))
            {
                
            }
            else if (submitAction.Equals("addAnswer"))
            {
                question.Answers.Add(new Answer());
            }
            else if (submitAction.Equals("removeAnswer"))
            {
                if (question.Answers.Count > 2)
                {
                    question.Answers.Remove(question.Answers.Last());
                }
            }
            ViewBag.KeyName = keyName;
            return View("QuestionForm", question);
        }
    }
}