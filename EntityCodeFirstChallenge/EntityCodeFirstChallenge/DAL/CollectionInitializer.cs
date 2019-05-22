using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntityCodeFirstChallenge.Models;

namespace EntityCodeFirstChallenge.DAL
{
    public class CollectionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollectionContext>
    {
        protected override void Seed(CollectionContext context)
        {
            //test data
            var games = new List<Game>
            {
                new Game{Name="Settlers of Catan",Designer="Klaus Teuber",PlayTime=45,CoreMechanic="Resource Managment",MinPlayers=2,MaxPlayers= 4,Weight=4,Rating=6},
                new Game{Name="Puerto Rico",Designer="Andreas Seyfarth",PlayTime=90,CoreMechanic="Follow", MinPlayers=3,MaxPlayers= 5,Weight=6,Rating=7}
            };
            games.ForEach(x => context.Games.Add(x));
            context.SaveChanges();
            
        }
    }
}