using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class Component
    {
        public uint ComponentId { get; set; }
        public uint ComponentGroupId { get; set; }
        public string ComponentUrn { get; set; }
    }
}
