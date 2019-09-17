using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPSLS_Web_App.Models;
using RPSLS_Web_App.Models.ViewModels;

namespace RPSLS_Web_App.Controllers
{
    public class GameController : Controller
    {
        private readonly RPSLS_Web_AppContext _context;

        public GameController(RPSLS_Web_AppContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(string userName, string userSelection, int p1win, int p1lose, int p1draw, int p2win, int p2lose, int p2draw)
        {
            Player aiPlayer = _context.Player.Where(s => s.ID == 1).FirstOrDefault();
            Player humanPlayer = new Player();
            Game thisGame = new Game();
            GameRound gameRound = new GameRound();
            if (!String.IsNullOrEmpty(userName))
            {
                humanPlayer = _context.Player.Where(s => s.Name.Equals(userName)).FirstOrDefault();
                if (humanPlayer == null)
                {
                    humanPlayer = new Player
                    {
                        Name = userName,
                        Wins = 0,
                        Losses = 0,
                        Draws = 0

                    };
                    _context.Add(humanPlayer);
                    await _context.SaveChangesAsync();
                }
               
                gameRound.Players.Add(aiPlayer);
                gameRound.Players.Add(humanPlayer);
                gameRound.PlayerWins = p1win;
                gameRound.PlayerLosses = p1lose;
                gameRound.PlayerDraws = p1draw;
                gameRound.AiWins = p2win;
                gameRound.AiLosses = p2lose;
                gameRound.AiDraws = p2draw;
                gameRound.HumanPlayer = humanPlayer;
                gameRound.UserSelection = userSelection;
                gameRound.AiSelection = thisGame.GetAiSelection();
                if(!String.IsNullOrEmpty(userSelection))
                {
                    gameRound.AiImageUrl = thisGame.GetImage(gameRound.AiSelection);
                    gameRound.HumanImageUrl = thisGame.GetImage(userSelection);
                }
               
            }
            

            
            
            //int test = id;
            String[] weapons = new string[] { "Scissors", "Paper", "Rock", "Lizard", "Spock" };
            

            
            if(!String.IsNullOrEmpty(userSelection))
            {
                gameRound.PlayerSelectionString = "The user has selected: " + gameRound.UserSelection;
                gameRound.AiSelectionString = "Sheldon has selected: " + gameRound.AiSelection;
            }
           
           

            if (!String.IsNullOrEmpty(userSelection))
            {
                int result = thisGame.GetWinner(weapons, gameRound.UserSelection, gameRound.AiSelection);

                switch (result)
                {
                    case 1:
                        gameRound.Verb = thisGame.GetVerb(gameRound.UserSelection, gameRound.AiSelection);
                        gameRound.Winner = gameRound.UserSelection + " " + gameRound.Verb + " " + gameRound.AiSelection + " you win!";
                        gameRound.PlayerWins++;
                        gameRound.AiLosses++;
                        humanPlayer.Wins++;
                        aiPlayer.Losses++;
                        _context.UpdateRange(gameRound.Players);
                        await _context.SaveChangesAsync();
                       
                        break;
                    case 0:
                        gameRound.Draw = "Draw";
                        gameRound.AiDraws++;
                        gameRound.PlayerDraws++;
                        humanPlayer.Draws++;
                        aiPlayer.Draws++;
                        _context.UpdateRange(gameRound.Players);
                        await _context.SaveChangesAsync();
                        break;
                    case -1:
                        gameRound.Verb = thisGame.GetVerb(gameRound.AiSelection, gameRound.UserSelection);
                        gameRound.Loser = gameRound.AiSelection + " " + gameRound.Verb + " " + gameRound.UserSelection + " you lose!";
                        gameRound.PlayerLosses++;
                        gameRound.AiWins++;
                        humanPlayer.Losses++;
                        aiPlayer.Wins++;
                        _context.UpdateRange(gameRound.Players);
                        await _context.SaveChangesAsync();

                        break;
                }
            }
            

            

            return View(gameRound);
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

        public string GetVerb(string weapon1, string weapon2)
        {
            if (weapon1.Equals("Scissors") && weapon2.Equals("Paper"))
                return "cuts";

            if (weapon1.Equals("Paper") && weapon2.Equals("Rock"))
                return "covers";

            if (weapon1.Equals("Rock") && weapon2.Equals("Lizard"))
                return "crushes";

            if (weapon1.Equals("Lizard") && weapon2.Equals("Spock"))
                return "poisons";

            if (weapon1.Equals("Spock") && weapon2.Equals("Scissors"))
                return "smashes";

            if (weapon1.Equals("Scissors") && weapon2.Equals("Lizard"))
                return "decapitates";

            if (weapon1.Equals("Lizard") && weapon2.Equals("Paper"))
                return "eats";

            if (weapon1.Equals("Paper") && weapon2.Equals("Spock"))
                return "disproves";

            if (weapon1.Equals("Spock") && weapon2.Equals("Rock"))
                return "vaporizez";

            if (weapon1.Equals("Rock") && weapon2.Equals("Scissors"))
                return "crushes";

            return "";
        }

        public string GetImage(string weapon)
        {
            if (weapon.Equals("Rock"))
                return "/images/rock.svg";
            if (weapon.Equals("Paper"))
                return "/images/paper.svg";
            if (weapon.Equals("Scissors"))
                return "/images/scissors.svg";
            if (weapon.Equals("Lizard"))
                return "/images/lizard.svg";
            else
                return "/images/spock.svg";
        }
    }
}
