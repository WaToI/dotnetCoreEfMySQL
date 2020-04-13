using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class DefaultRoles
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string DefaultRoleHost { get; set; }
        public string DefaultRoleUser { get; set; }
    }
}
