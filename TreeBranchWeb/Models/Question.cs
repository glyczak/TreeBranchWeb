using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreeBranchWeb.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Display(Name = "Question")]
        public string Text { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public virtual DichotomousKey DichotomousKey { get; set; }
        public int DichotomousKeyId { get; set; }

        public Question()
        {
            Answers = new List<Answer>
            {
                new Answer(),
                new Answer()
            };
        }
    }
}