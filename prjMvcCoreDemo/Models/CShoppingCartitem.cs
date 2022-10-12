using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.Models
{
    public class CShoppingCartitem
    {
        [DisplayName("購買品項")]
        public int productId { get; set; }
        [DisplayName("採購量")]
        public int count { get; set; }
        [DisplayName("成交價")]
        public decimal price { get; set; }
        public decimal 小計 { get { return this.price * this.count; } }
        public TProduct product { get; set; }
    }
}
