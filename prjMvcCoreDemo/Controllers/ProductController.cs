using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _enviro;
        public ProductController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
        public IActionResult List(CKeyWordViewModel model)
        {
            dbDemoContext db = new dbDemoContext();
            IEnumerable<TProduct> datas = null;
            if (string.IsNullOrEmpty(model.txtkeyword))
                datas = from p in db.TProducts
                        select p;
            else
                datas = db.TProducts.Where(p => p.FName.Contains(model.txtkeyword));

            return View(datas);
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
                if (prod != null)
                    return View(prod);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(CProductViewModel inProd) //post
        {
            dbDemoContext db = new dbDemoContext();
            TProduct c = db.TProducts.FirstOrDefault(c => c.FId == inProd.FId);
            if (c != null)
            {
                if (inProd.photo != null)
                {
                    string pName = Guid.NewGuid().ToString() + ".jpg";
                    c.FImagepath = pName;
                    string path = _enviro.WebRootPath + "/images/" + pName;
                    inProd.photo.CopyTo(new FileStream(path, FileMode.Create));
                }
                c.FName = inProd.FName;
                c.FPrice = inProd.FPrice;
                c.FCost = inProd.FCost;
                c.FQty = inProd.FQty;
                c.FActived = inProd.FActived;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TProduct p)
        {
            dbDemoContext db = new dbDemoContext();
            db.TProducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
                if (prod != null)
                {
                    db.TProducts.Remove(prod);
                }
            }
            return View();
        }
    }
}
