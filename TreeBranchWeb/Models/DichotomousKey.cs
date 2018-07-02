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
        [OnlyLetters]
        public string Name { get; set; }

        public bool QuestionsFinalized { get; set; }

        public bool MatchesFinalized { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Match> Matches { get; set; }

        public DichotomousKey()
        {
            Questions = new List<Question>();
            Matches = new List<Match>();
        }

        private int GetRequiredMatches()
        {
            int requiredMatches = 1;
            foreach (var question in Questions)
            {
                requiredMatches *= question.Answers.Count;
            }
            return requiredMatches;
        }

        public bool CanFinalizeQuestions()
        {
            return Questions.Count > 0;
        }

        public bool CanFinalizeMatches()
        {
            if (!QuestionsFinalized || MatchesFinalized)
            {
                return false;
            }
            return GetRequiredMatches() == Matches.Count;
        }

        public bool CanAddMatches()
        {
            if (!QuestionsFinalized || MatchesFinalized)
            {
                return false;
            }
            return GetRequiredMatches() > Matches.Count;
        }

        private void GenerateMatchesRecursively(Question question, ICollection<Answer> answers)
        {
            foreach (var answer in question.Answers)
            {
                answers.Add(answer);
                var nextQuestion = Questions.SkipWhile(q => q != question).ElementAtOrDefault(1);
                if (nextQuestion != null)
                {
                    GenerateMatchesRecursively(nextQuestion, answers);
                }
                else
                {
                    Matches.Add(new Match
                    {
                        DichotomousKey = this,
                        Answers = answers,
                        IsDefined = false
                    });
                }
            }
        }

        public void GenerateMatches()
        {
            GenerateMatchesRecursively(Questions.First(), new List<Answer>());
        }
    }
}