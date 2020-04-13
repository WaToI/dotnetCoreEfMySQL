using System;
using System.Collections.Generic;

namespace efMysql.Models
{
    public partial class HelpCategory
    {
        public ushort HelpCategoryId { get; set; }
        public string Name { get; set; }
        public ushort? ParentCategoryId { get; set; }
        public string Url { get; set; }
    }
}
