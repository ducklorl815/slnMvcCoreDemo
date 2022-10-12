using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult List(CKeyWordViewModel model)
        {
            dbDemoContext db = new dbDemoContext();
            IEnumerable<TCustomer> datas = null;
            if (string.IsNullOrEmpty(model.txtkeyword))
                datas = from p in db.TCustomers
                        select p;
            else
                datas = db.TCustomers.Where(p => p.FName.Contains(model.txtkeyword)||
                p.FAddress.Contains(model.txtkeyword) ||
                p.FPhone.Contains(model.txtkeyword) ||
                p.FEmail.Contains(model.txtkeyword));

            return View(datas);
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TCustomer prod = db.TCustomers.FirstOrDefault(p => p.FId == id);
                if (prod != null)
                    return View(prod);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(TCustomer inCust) //post
        {
            dbDemoContext db = new dbDemoContext();
            TCustomer cust = db.TCustomers.FirstOrDefault(c => c.FId == inCust.FId);
            if (cust != null)
            {
                cust.FName = inCust.FName;
                cust.FPhone = inCust.FPhone;
                cust.FEmail = inCust.FEmail;
                cust.FAddress = inCust.FAddress;
                cust.FPassword = inCust.FPassword;
                cust.FActived = inCust.FActived;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TCustomer t)
        {
            dbDemoContext db = new dbDemoContext();
            db.TCustomers.Add(t);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbDemoContext db = new dbDemoContext();
                TCustomer cus = db.TCustomers.FirstOrDefault(p => p.FId == id);
                if (cus != null)
                {
                    db.TCustomers.Remove(cus);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("List");
        }
    }
}
