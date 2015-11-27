using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
namespace mvc5.Models
{
    public class SpeakersContext : DbContext
    {
        public DbSet<Speaker> Speakers {get;set;}
    }
}
