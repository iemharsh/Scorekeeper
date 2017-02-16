using System.Collections.Generic;

namespace WebApplication.Models 
{
    public class Player 
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Score> Scores { get; set; }

    }
}