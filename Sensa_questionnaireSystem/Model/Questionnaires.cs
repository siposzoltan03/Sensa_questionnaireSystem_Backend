using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Questionnaires
    {
        public int QuestionnaireId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionInner { get; set; }
        public string Emailsubject { get; set; }
        public string Emailbody { get; set; }
        public string State { get; set; }
        public string NameAlt { get; set; }
        public string ReportTitle { get; set; }
        public string ReportSubtitle { get; set; }
        public string ReportClientName { get; set; }
        public string ReportMakers { get; set; }
        public string ReportMakersPhones { get; set; }
        public string ReportDate { get; set; }
        public string ReportCover { get; set; }
        public string ReportBackpage { get; set; }
    }
}
