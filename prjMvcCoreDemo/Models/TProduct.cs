using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMvcCoreDemo.Models
{
    public partial class TProduct
    {
        public int FId { get; set; }
        public string FName { get; set; }
        public decimal? FCost { get; set; }
        public int? FQty { get; set; }
        public decimal? FPrice { get; set; }
        public string FImage { get; set; }
        public string FImagepath { get; set; }
        public bool? FActived { get; set; }
    }
}
