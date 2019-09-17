using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSLS_Web_App.Models.ViewModels
{
    public class GameRound
    {
        public GameRound()
        {
            this.UserSelection = String.Empty;
            this.AiSelection = String.Empty;
            this.PlayerSelectionString = String.Empty;
            this.AiSelectionString = String.Empty;
            this.Verb = String.Empty;
            this.Winner = String.Empty;
            this.Loser = String.Empty;
            this.Draw = String.Empty;
            this.PlayerWins = 0;
            this.PlayerLosses = 0;
            this.PlayerDraws = 0;
            this.AiWins = 0;
            this.AiLosses = 0;
            this.AiDraws = 0;
            this.HumanPlayer = new Player();
            this.Players = new List<Player>();
            this.HumanImageUrl = String.Empty;
            this.AiImageUrl = String.Empty;
        }
        public string UserSelection { get; set; }
        public String AiSelection { get; set; }

        public string PlayerSelectionString { get; set; }
        public string AiSelectionString { get; set; }

        public string Verb { get; set; }

        public string Winner { get; set; }
        public string Loser { get; set; }
        public string Draw { get; set; }

        public int PlayerWins { get; set; }
        public int PlayerLosses { get; set; }
        public int PlayerDraws { get; set; }

        public int AiWins { get; set; }
        public int AiLosses { get; set; }
        public int AiDraws { get; set; }

        public Player HumanPlayer { get; set; }

        public List<Player> Players { get; set; }

        public string HumanImageUrl { get; set; }
        public string AiImageUrl { get; set; }
    }
}
