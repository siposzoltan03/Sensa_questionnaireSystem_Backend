using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Registerdate { get; set; }
        public DateTime Lastlogin { get; set; }
        public string Lastip { get; set; }
        public sbyte Logincount { get; set; }
        public string State { get; set; }
    }
}
