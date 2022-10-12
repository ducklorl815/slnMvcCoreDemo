using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace prjMvcCoreDemo.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult List()
        {
            var datas = from p in (new dbDemoContext()).TProducts
                        select p;
            List<CProductViewModel> list = new List<CProductViewModel>();
            foreach(TProduct t in datas)
            {
                CProductViewModel vm = new CProductViewModel();
                vm.product = t;
                list.Add(vm);
            }
            return View(list);
        }
        public ActionResult CartView()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_已購入_商品))
            {
                string jsonCart = HttpContext.Session.GetString(CDictionary.SK_已購入_商品);
                List<CShoppingCartitem> cart = JsonSerializer.Deserialize<List<CShoppingCartitem>>(jsonCart);
                return View(cart);
            }
            else
                return RedirectToAction("List");
        }
        public ActionResult AddToCart(int? id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
            if (prod == null)
                return RedirectToAction("List");
            return View(prod);
        }
        [HttpPost]
        public ActionResult AddToCart(CAddToCartViewModel vModel)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == vModel.txtfid);
            if (prod == null)
                return RedirectToAction("List");
            string jsonCart = "";
            List<CShoppingCartitem> list = null;
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_已購入_商品))
                list = new List<CShoppingCartitem>();
            else
            {
                jsonCart = HttpContext.Session.GetString(CDictionary.SK_已購入_商品);
                list = JsonSerializer.Deserialize<List<CShoppingCartitem>>(jsonCart);
            }
            CShoppingCartitem item = new CShoppingCartitem()
            {
                count = vModel.txtCount,
                price = (decimal)prod.FPrice,
                productId = vModel.txtfid,
                product = prod,
            };
            list.Add(item);
            jsonCart = JsonSerializer.Serialize(list);
            HttpContext.Session.SetString(CDictionary.SK_已購入_商品, jsonCart);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                string jsonCart = HttpContext.Session.GetString(CDictionary.SK_已購入_商品);
                List<CShoppingCartitem> cart = JsonSerializer.Deserialize<List<CShoppingCartitem>>(jsonCart);
                var q = cart.FirstOrDefault(p => p.productId == id);
                cart.Remove(q);
                jsonCart = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_已購入_商品, jsonCart);
            }

            return RedirectToAction("CartView");
        }
        public ActionResult Edit(CAddToCartViewModel id)
        {
            dbDemoContext db = new dbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == id.txtfid);
            if (prod == null)
                return RedirectToAction("List");
            string jsonCart = "";
            List<CShoppingCartitem> list = null;
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_已購入_商品))
                list = new List<CShoppingCartitem>();
            else
            {
                jsonCart = HttpContext.Session.GetString(CDictionary.SK_已購入_商品);
                list = JsonSerializer.Deserialize<List<CShoppingCartitem>>(jsonCart);
            }
            CShoppingCartitem item = new CShoppingCartitem()
            {
                count = id.txtCount,
                price = (decimal)prod.FPrice,
                productId = id.txtfid,
                product = prod,
            };
            list.Add(item);
            jsonCart = JsonSerializer.Serialize(list);
            HttpContext.Session.SetString(CDictionary.SK_已購入_商品, jsonCart);
            return RedirectToAction("List");
        }
    }
}
