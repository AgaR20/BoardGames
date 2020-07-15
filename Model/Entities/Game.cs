using BoardGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Game : Entity
    {
        public Game()
        {
            Visits = new List<Visit>();
        }
        public Game(IAddEditGame game)
        {
            Name = game.Name;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
        }
        public string Name { get; set; }
        public int MinimalPlayersAmount { get; set; }
        public int MaximalPlayersAmount { get; set; }
        public int MinimalPlayersAge { get; set; }
        public List<Visit> Visits { get; set; }

        public void Update(IAddEditGame game)
        {
            Name = game.Name;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
        }
    }

    public interface IAddEditGame
    {
        string Name { get; set; }
        int MinimalPlayersAmount { get; set; }
        int MaximalPlayersAmount { get; set; }
        int MinimalPlayersAge { get; set; }
    }
}

