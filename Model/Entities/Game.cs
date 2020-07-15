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
        public Game(IAddGame game)
        {
            Name = game.Name;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
            Visits = new List<Visit>();
        }
        public string Name { get; set; }
        public int MinimalPlayersAmount { get; set; }
        public int MaximalPlayersAmount { get; set; }
        public int MinimalPlayersAge { get; set; }
        public List<Visit> Visits { get; set; }

        public void Update(IEditGame game)
        {
            Name = game.Name;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
        }
    }

    public interface IAddGame
    {
        string Name { get; set; }
        int MinimalPlayersAmount { get; set; }
        int MaximalPlayersAmount { get; set; }
        int MinimalPlayersAge { get; set; }
    }

    public interface IEditGame : IAddGame
    {
        int Id { get; set; }

    }
}

