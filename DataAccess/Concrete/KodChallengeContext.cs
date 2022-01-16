using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class KodChallengeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=KodChallenge; Trusted_Connection=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemInput> ProblemInputs { get; set; }

    }
}
