using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMvcCoreDemo.Models
{
    public partial class TShoppingCart
    {
        [DisplayName("產品編號")]
        public int Fld { get; set; }

        public string FDate { get; set; }
        public int? FCustomer { get; set; }
        public int? FProduct { get; set; }
        public int? FCount { get; set; }
        public decimal? FPrice { get; set; }
    }
}
