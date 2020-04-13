using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class TimeZone
    {
        public uint TimeZoneId { get; set; }
        public string UseLeapSeconds { get; set; }
    }
}
