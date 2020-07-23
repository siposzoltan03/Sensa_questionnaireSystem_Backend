using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Questions
    {
        public int QuestionId { get; set; }
        public int QuestiongroupId { get; set; }
        public string Params { get; set; }
        public sbyte Pos { get; set; }
        public string ParamsAlt { get; set; }
    }
}
