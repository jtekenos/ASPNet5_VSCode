using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc5.Models
{
    public class DummyData
    {
        public static void Initialize(SpeakersContext context) {
            if (!context.Speakers.Any()) {
                context.Speakers.Add(new Speaker { FirstName = "Richard"});
                context.Speakers.Add(new Speaker { FirstName = "Anthony"});
                context.Speakers.Add(new Speaker { FirstName = "Tommy"});
                context.Speakers.Add(new Speaker { FirstName = "Charles"});
                context.Speakers.Add(new Speaker { FirstName = "Peter"});
        
                context.SaveChanges();
            }
        }
    }
}
