using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityCodeFirstChallenge.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designer { get; set; }
        public int PlayTime { get; set; }
        public string CoreMechanic { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int Weight { get; set; }
        public int Rating { get; set; }

    }
}