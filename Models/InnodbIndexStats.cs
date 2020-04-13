using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class InnodbIndexStats
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string IndexName { get; set; }
        public DateTime LastUpdate { get; set; }
        public string StatName { get; set; }
        public ulong StatValue { get; set; }
        public ulong? SampleSize { get; set; }
        public string StatDescription { get; set; }
    }
}
