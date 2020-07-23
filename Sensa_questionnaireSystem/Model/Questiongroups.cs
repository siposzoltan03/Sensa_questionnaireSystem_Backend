using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Questiongroups
    {
        public int QuestiongroupId { get; set; }
        public int QuestionnaireId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public sbyte ImportantNum { get; set; }
        public string Type { get; set; }
        public short StartNum { get; set; }
        public sbyte Pos { get; set; }
        public short StandardMin { get; set; }
        public short StandardMax { get; set; }
        public string StandardMinText { get; set; }
        public string StandardMaxText { get; set; }
        public string TitleAlt { get; set; }
        public string StandardMinTextAlt { get; set; }
        public string StandardMaxTextAlt { get; set; }
    }
}
