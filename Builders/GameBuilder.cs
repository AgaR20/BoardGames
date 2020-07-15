using BoardGame.Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Builders
{
    public class GameBuilder
    {
        private readonly BoardContext _context;
        private Game _state;
        public GameBuilder(BoardContext context)
        {
            _context = context;
            _state = new Game();
        }
        public Game Build()
        {
            _context.SaveChanges();
            return _state;
        }

        public GameBuilder WithName(string name)
        {
            _state.Name = name;
            return this;
        }
        public GameBuilder WithMaxPlayersAmount(int maxAmount)
        {
            _state.MaximalPlayersAmount = maxAmount;
            return this;
        }
        public GameBuilder WithMinPlayersAmount(int minAmount)
        {
            _state.MinimalPlayersAmount = minAmount;
            return this;
        }
        public GameBuilder WithMinPlayersAge(int age)
        {
            _state.MinimalPlayersAge = age;
            return this;
        }
    }
}
