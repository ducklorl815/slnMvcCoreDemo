using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.Controllers
{
    public class AController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string SayHello()
        {
            return "Hello World";
        }
        public string Lotto()
        {
            string number = (new CLottoGen()).LottoGen();
            return number;
        }
        public IActionResult ShowCountBySession()
        {
            int count = 0;
            if (HttpContext.Session.Keys.Contains("KK"))
                count = (int)HttpContext.Session.GetInt32("KK");
            count++;
            HttpContext.Session.SetInt32("KK", count);

            ViewBag.COUNT = count;
            return View();
        }








    }
}
