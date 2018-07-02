using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var key = _context.GetDichotomousKeyOrDefault(keyName);
            if (key == null) return HttpNotFound();
            ViewBag.KeyName = keyName;

            return View(key);
        }

        // GET: Keys/{keyName}/Questions/New
        public ActionResult New(string keyName)
        {
            var key = _context.GetDichotomousKeyOrDefault(keyName);
            if (key == null) return HttpNotFound();
            ViewBag.KeyName = keyName;

            if (key.QuestionsFinalized)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "This key's questions are not modifiable.");
            }
            return View("QuestionForm", new Question());
        }

        // POST: /Keys/{keyName}/Questions/Save
        [HttpPost]
        public ActionResult Save(Question question, string keyName, string submitAction)
        {
            var key = _context.GetDichotomousKeyOrDefault(keyName);
            if (key == null) return HttpNotFound();
            ViewBag.KeyName = keyName;

            if (key.QuestionsFinalized)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "This key's questions are not modifiable.");
            }

            if (submitAction.Equals("save"))
            {
                //TODO Save to DB.
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
            return View("QuestionForm", question);
        }
    }
}