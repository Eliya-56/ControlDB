using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDB
{
    class ControlContext : DbContext
    {
        public ControlContext(): base("ControlDb")
        {}

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

    }

    class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> AMatches { get; set; }
        public virtual ICollection <Match> BMatches { get; set; }
    }

    class Player
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }

    class Match
    {
        public int Id { get; set; }

        public string Stadium { get; set; }
        
        public int? ATeamId { get; set; }
        public virtual Team ATeam { get; set; }
        
        public int? BTeamId { get; set; }
        public virtual Team BTeam { get; set; }

        public int TeamAScore { get; set; }

        public int TeamBScore { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
    



    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ControlContext())
            {
                foreach (var item in context.Matches)
                {
                    Console.WriteLine(item.Stadium);
                }
            }
        }
    }
}
