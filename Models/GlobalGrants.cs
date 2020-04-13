using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class GlobalGrants
    {
        public string User { get; set; }
        public string Host { get; set; }
        public string Priv { get; set; }
        public string WithGrantOption { get; set; }
    }
}
