using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class ServerCost
    {
        public string CostName { get; set; }
        public float? CostValue { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Comment { get; set; }
        public float? DefaultValue { get; set; }
    }
}
