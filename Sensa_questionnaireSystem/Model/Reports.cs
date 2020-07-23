using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Reports
    {
        public int ReportId { get; set; }
        public int QuestionnaireId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Params { get; set; }
        public string State { get; set; }
        public sbyte Pos { get; set; }
        public string ParamsAlt { get; set; }
        public string TitleAlt { get; set; }
        public int StartingPagenum { get; set; }
        public string PageNumbering { get; set; }
        public int GroupAveragesGroupingId { get; set; }
    }
}
