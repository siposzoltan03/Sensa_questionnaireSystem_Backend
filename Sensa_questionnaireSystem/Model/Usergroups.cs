using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Usergroups
    {
        public int UsergroupId { get; set; }
        public int UsergroupingId { get; set; }
        public string Name { get; set; }
        public sbyte Pos { get; set; }
        public string NameAlt { get; set; }
    }
}
