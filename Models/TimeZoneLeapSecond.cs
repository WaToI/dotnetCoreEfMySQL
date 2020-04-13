using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class TimeZoneLeapSecond
    {
        public long TransitionTime { get; set; }
        public int Correction { get; set; }
    }
}
