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
        public IActionResult Index(string userSelection)
        {
            String[] weapons = new string[] { "Scissors", "Paper", "Rock", "Lizard", "Spock" };
            ViewData["Winner"] = "";
            ViewData["Loser"] = "";
            ViewData["Draw"] = "";
            ViewData["UserSelection"] = "";
            ViewData["AiSelection"] = "";

            Game thisGame = new Game();
            
            String aiSelection = thisGame.GetAiSelection();
            if(!String.IsNullOrEmpty(userSelection))
            {
                ViewData["UserSelection"] = "The user has selected: " + userSelection;
                ViewData["AiSelection"] = "Sheldon has selected: " + aiSelection;
            }
           
           

            if (!String.IsNullOrEmpty(userSelection))
            {
                int result = thisGame.GetWinner(weapons, userSelection, aiSelection);

                switch (result)
                {
                    case 1:
                        ViewData["Winner"] = userSelection + " defeats " + aiSelection + " you win!";
                        //Console.WriteLine("{0} pwns {1}. You're a winner!", userSelection, aiSelection);
                        break;
                    case 0:
                        ViewData["Draw"] = "Draw";
                        //Console.WriteLine("Draw!");
                        break;
                    case -1:
                        ViewData["Loser"] = aiSelection + " defeats " + userSelection + " you lose!";
                        //Console.WriteLine("{0} pwns {1}. You're a loser!", aiSelection, userSelection);
                        break;
                }
            }
            

            

            return View();
        }
    }

    public class Game
    {
        Random random = new Random();
        String[] weapons = new string[] { "Scissors", "Paper", "Rock","Lizard", "Spock" };

        public string GetAiSelection()
        {
            int numSelection = random.Next(5);
            string weaponSelection = weapons[numSelection];

            return weaponSelection;
        }

        public int GetWinner(string[] weapons, string weapon1, string weapon2)
        {
            if (weapon1 == weapon2)
                return 0; // If weapons are the same, return 0 for draw.

            if (GetVictories(weapons, weapon1).Contains(weapon2))
                return 1; // Returns 1 for weapon1 win.
            else if (GetVictories(weapons, weapon2).Contains(weapon1))
                return -1; // Returns -1 for weapon2 win.

            throw new Exception("No winner found.");
        }

        public static IEnumerable<string> GetVictories(string[] weapons, string weapon)
        {
            // Gets index of weapon.
            int index = Array.IndexOf(weapons, weapon);

            // If weapon is odd and the final index in the set, then return the first item in the set as a victory.
            if (index % 2 != 0 && index == weapons.Length - 1)
                yield return weapons[0];

            for (int i = index - 2; i >= 0; i -= 2)
                yield return weapons[i];

            for (int i = index + 1; i < weapons.Length; i += 2)
                yield return weapons[i];
        }
    }
}
