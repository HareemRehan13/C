using System;
using System.Collections.Generic;

namespace WebApp_hareem.Models
{
    public partial class User
    {
        public int UId { get; set; }
        public string UName { get; set; } = null!;
        public string UPass { get; set; } = null!;
        public string UImg { get; set; } = null!;
        public int RId { get; set; }

        public virtual Role RIdNavigation { get; set; } = null!;
    }
}
