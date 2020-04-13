using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class RoleEdges
    {
        public string FromHost { get; set; }
        public string FromUser { get; set; }
        public string ToHost { get; set; }
        public string ToUser { get; set; }
        public string WithAdminOption { get; set; }
    }
}
