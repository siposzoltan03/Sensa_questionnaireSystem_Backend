using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Usergroupings
    {
        public int UsergroupingId { get; set; }
        public int QuestionnaireId { get; set; }
        public string Name { get; set; }
        public sbyte Pos { get; set; }
        public string NameAlt { get; set; }
    }
}
