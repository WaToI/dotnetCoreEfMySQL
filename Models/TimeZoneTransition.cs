using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class TimeZoneTransition
    {
        public uint TimeZoneId { get; set; }
        public long TransitionTime { get; set; }
        public uint TransitionTypeId { get; set; }
    }
}
