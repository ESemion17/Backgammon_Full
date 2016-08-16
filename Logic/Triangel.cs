using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Triangel: ITriangel
    {
        public Triangel(Player p)
        {
            PlayerStone = p;
            Number = 1;
        }
        public Triangel(Player p,int num)
        {
            PlayerStone = p;
            Number = num;
        }
        public int Number { get; private set; }
        public Player PlayerStone { get; private set; }
        public static Triangel operator ++(Triangel t)
        {
            t.Number++;
            return t;
        }
        public static Triangel operator --(Triangel t)
        {
            t.Number--;
            if (t.Number == 0)
                return null;
            return t;
        }
        public static implicit operator int (Triangel t)
        {
            return t.Number;
        }
        public static implicit operator Player(Triangel t)
        {
            return t.PlayerStone;
        }
    }
}