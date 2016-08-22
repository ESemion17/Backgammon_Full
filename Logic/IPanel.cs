using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IPanel
    {
        Triangel[] Board { get; set; }
        int[] Eaten { get; set; }
        int[] AtHome { get; set; }
        Player PlayingNow { get; set; }
        void NextPlayer();
    }
}
