using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPSLS_Web_App.Models;

namespace RPSLS_Web_App.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index(string userChoice)
        {
            ViewData["userSelection"] = "The user has selected " + userChoice;
            return View();
        }
    }
}
