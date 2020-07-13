using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Model
{
    public class Game: Entity
    {
        public string Name { get; set; }
        public int MinimalPlayersAmount { get; set; }
        public int MaximalPlayersAmount { get; set; }
        public int MinimalPlayersAge { get; set; }
    }
}
