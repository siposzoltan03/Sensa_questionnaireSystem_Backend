using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Answers
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public short? Value { get; set; }
        public sbyte Importance { get; set; }
        public string Params { get; set; }
        public short Pos { get; set; }
        public string CrCritical { get; set; }
        public string CrImproved { get; set; }
    }
}
