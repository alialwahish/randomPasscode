using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using gnrtRandPasscode.Models;

namespace gnrtRandPasscode.Controllers
{
    
    public class HomeController : Controller
    {
        public static Random rand = new Random();
        


        public static string randString()
        {
            
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 14).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        
        
      

        [HttpGet]
        [Route("")]
        public IActionResult Index(int count,string pass)
        {
            Console.WriteLine(count);
            HttpContext.Session.SetInt32("clicked",count);
            
            int? clicked= HttpContext.Session.GetInt32("clicked");
            
            
            ViewBag.num=clicked;
            ViewBag.s=pass;

            return View();
        }

        [HttpGet("inc")]
       public IActionResult redirect(){
           Console.WriteLine("in redirect");
           int? count=HttpContext.Session.GetInt32("clicked");
           count++;
           string s=randString();

           return RedirectToAction("Index",new {count,pass=s});
       }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
