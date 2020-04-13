using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class HelpTopic
    {
        public uint HelpTopicId { get; set; }
        public string Name { get; set; }
        public ushort HelpCategoryId { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }
        public string Url { get; set; }
    }
}
