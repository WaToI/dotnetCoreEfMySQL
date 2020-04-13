using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class GtidExecuted
    {
        public Guid SourceUuid { get; set; }
        public long IntervalStart { get; set; }
        public long IntervalEnd { get; set; }
    }
}
