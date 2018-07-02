using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeBranchWeb.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDefined { get; set; }

        public bool Exists { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public virtual DichotomousKey DichotomousKey { get; set; }
        public int DichotomousKeyId { get; set; }
    }
}