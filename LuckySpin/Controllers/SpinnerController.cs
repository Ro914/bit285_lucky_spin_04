using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        /***
         * Entry Page Action
         **/

        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Index(Player p)
        {
            return RedirectToAction("SpinIt", new { luck = 3 });
        }

        /***
         * Spin Action
         **/  
               
        Random random = new Random() ; 

        public IActionResult SpinIt(int luck)
        {

            //Load up a Spin object with data
            Spin spin = new Spin();
            spin.Luck = luck;
            spin.A = random.Next(1, 10);
            spin.B = random.Next(1, 10);
            spin.C = random.Next(1, 10);

            // Test to see if a winner
            if (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck)
                spin.Display = "block";
            else
                spin.Display = "none";

            //Send the View a Spin
            return View(spin);
        }
    }
}

