using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreeBranchWeb.Models
{
    public class DichotomousKey
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        public bool QuestionsFinalized { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Match> Matches { get; set; }

        public DichotomousKey()
        {
            Questions = new List<Question>();
            Matches = new List<Match>();
        }
    }
}