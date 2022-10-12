using System;
using System.Collections.Generic;

#nullable disable

namespace prjMvcCoreDemo.Models
{
    public partial class TEmployee
    {
        public int FId { get; set; }
        public string FEmployee { get; set; }
        public string FPhone { get; set; }
        public string FEmail { get; set; }
        public string FAddress { get; set; }
        public string FPassword { get; set; }
        public int? FSysrole { get; set; }
        public bool? FActived { get; set; }
    }
}
