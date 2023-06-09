using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Classes
{
    public class Sportsman
    {
        public int Id { get; }
        public string Name { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime BirthDate { get; set; } = DateTime.Now;

        public Sportsman()
        {
            Id = _sportsmanCount++;
        }

        private static int _sportsmanCount = 0;
    }
}
