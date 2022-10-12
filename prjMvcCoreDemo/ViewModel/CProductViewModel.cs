using Microsoft.AspNetCore.Http;
using prjMvcCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.ViewModels
{
    public class CProductViewModel
    {
        private TProduct _product;
        public TProduct product
        {
            get { return _product; } 
            set { _product = value; }
        }
        public CProductViewModel()
        {
            _product = new TProduct();  //每做一個就建一個
        }
        [DisplayName("產品編號")]
        public int FId
        {
            get { return _product.FId; }
            set { _product.FId = value; }
        }
        [DisplayName("產品")]
        public string FName
        {
            get { return _product.FName; }
            set { _product.FName = value; }
        }
        [DisplayName("成本")]
        public decimal? FCost
        {
            get { return _product.FCost; }
            set { _product.FCost = value; }
        }
        [DisplayName("庫存")]
        public int? FQty
        {
            get { return _product.FQty; }
            set { _product.FQty = value; }
        }
        [DisplayName("價格")]
        public decimal? FPrice
        {
            get { return _product.FPrice; }
            set { _product.FPrice = value; }
        }

        public string FImagepath
        {
            get { return _product.FImagepath; }
            set { _product.FImagepath = value; }
        }
        [DisplayName("上市")]
        public bool? FActived
        {
            get { return _product.FActived; }
            set { _product.FActived = value; }
        }
        public IFormFile photo { get; set; }
    }
}
