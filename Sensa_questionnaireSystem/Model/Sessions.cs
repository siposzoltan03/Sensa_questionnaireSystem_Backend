using System;
using System.Collections.Generic;

namespace Sensa_questionnaireSystem.Model
{
    public partial class Sessions
    {
        public long SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime LastAccess { get; set; }
        public string Variables { get; set; }
        public string LastFile { get; set; }
        public string LastIp { get; set; }
    }
}
