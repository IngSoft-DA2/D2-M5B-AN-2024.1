using System;
using starwars.Domain.Enums;

namespace starwars.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ForceValue { get; set; }
        public QuestionCategory Category { get; set; }
    }
}

