using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Panel : IPanel
    {
        public Triangel[] Board { get; set; }
        public int[] Eaten { get; set; }
        public int[] AtHome { get; set; }
        public Player PlayingNow { get; set; }
        public void NextPlayer()
        {
            var now = (int)PlayingNow;
            var next = now + 1;
            next %= 2;
            PlayingNow=(Player)next;
        }
    }
}
