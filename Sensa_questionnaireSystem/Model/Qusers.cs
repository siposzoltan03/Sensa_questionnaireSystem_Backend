using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Qusers
    {
        public int UserId { get; set; }
        public int QuestionnaireId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string State { get; set; }
        public string LoginId { get; set; }
        public string Groups { get; set; }
        public DateTime? LastEmailDate { get; set; }
        public DateTime? LastFillDate { get; set; }
    }
}
