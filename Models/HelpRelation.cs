using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class HelpRelation
    {
        public uint HelpTopicId { get; set; }
        public uint HelpKeywordId { get; set; }
    }
}
