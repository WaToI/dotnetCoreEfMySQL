using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class TablesPriv
    {
        public string Host { get; set; }
        public string Db { get; set; }
        public string User { get; set; }
        public string TableName { get; set; }
        public string Grantor { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
