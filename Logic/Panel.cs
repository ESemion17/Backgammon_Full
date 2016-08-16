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
        public void PrintToConsole(IEnumerable<int> cubes)
        {
            var cubesList = cubes.ToList<int>();
            int i;
            SetColorToDefault();
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)0;
            Console.WriteLine("Enter 'exit' to quit");
            Console.WriteLine($"Now turn = {PlayingNow}");
            SetColorToDefault();
            Console.WriteLine(@"||=13=||=14=||=15=||=16=||=17=||=18=|||||||=19=||=20=||=21=||=22=||=23=||=24=||||||");
            i = 12;
            Console.Write(@"||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/|||||||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.Write(@"/||\");
            PrintByColor(i++);
            Console.WriteLine(@"/||||||");
            Console.WriteLine(@"|| \/ || \/ || \/ || \/ || \/ || \/ ||||||| \/ || \/ || \/ || \/ || \/ || \/ ||||||");
            Console.Write(@"||    ||    ||    ||    ||    ||    |||");
            PrintByColor(1,'e');
            Console.Write(@"||    ||    ||    ||    ||    ||    ||");
            PrintByColor(1,'h');
            Console.WriteLine(@"||");
            Console.WriteLine(@"||====||====||====||====||====||====||Eat||====||====||====||====||====||====|Home|     Cubes:");
            Console.Write(@"||    ||    ||    ||    ||    ||    |||");
            PrintByColor(0, 'e');
            Console.Write(@"||    ||    ||    ||    ||    ||    ||");
            PrintByColor(0, 'h');
            Console.Write(@"||       ");
            PrintCube(0, cubesList);
            Console.Write(@"|| /\ || /\ || /\ || /\ || /\ || /\ ||||||| /\ || /\ || /\ || /\ || /\ || /\ ||||||       ");
            PrintCube(1, cubesList);
            i = 11;
            Console.Write(@"||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\|||||||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||/");
            PrintByColor(i--);
            Console.Write(@"\||||||       ");
            PrintCube(2, cubesList);
            Console.Write(@"||=12=||=11=||=10=||= 9=||= 8=||= 7=|||||||= 6=||= 5=||= 4=||= 3=||= 2=||= 1=||||||       ");
            PrintCube(3, cubesList);
            Console.ForegroundColor = (ConsoleColor)0;
        }
        private void PrintCube(int i,List<int> cube)
        {
            if (cube.Count > i)
                Console.Write($"{cube[i]}");
            Console.WriteLine();
        }
        private void SetColorToDefault()
        {
            Console.BackgroundColor = (ConsoleColor)7;
            Console.ForegroundColor = (ConsoleColor)8;
        }
        private void SetColorToBlack()
        {
            Console.BackgroundColor = (ConsoleColor)0;
            Console.ForegroundColor = (ConsoleColor)12;
        }
        private void SetColorToWhite()
        {
            Console.BackgroundColor = (ConsoleColor)15;
            Console.ForegroundColor = (ConsoleColor)12;
        }
        private void PrintByColor(int i, char ch='d')
        {
            if (i == 0 && ch == 'e')
            {
                SetColorToBlack();
                Console.Write("{0,2}", Eaten[i] == 0 ? "0" : Eaten[i].ToString());
                SetColorToDefault();
            }
            else
            if (i == 0 && ch == 'h')
            {
                SetColorToBlack();
                Console.Write("{0,2}", AtHome[i] == 0 ? "0" : AtHome[i].ToString());
                SetColorToDefault();
            }
            else
            if (i == 1 && ch == 'e')
            {
                SetColorToWhite();
                Console.Write("{0,2}", Eaten[i] == 0 ? "0" : Eaten[i].ToString());
                SetColorToDefault();
            }
            else
            if (i == 1 && ch == 'h')
            {
                SetColorToWhite();
                Console.Write("{0,2}", AtHome[i] == 0 ? "0" : AtHome[i].ToString());
                SetColorToDefault();
            }
            else
            if (Board[i] != null && Board[i].PlayerStone == Player.BlackPlayer)
            {
                SetColorToBlack();
                Console.Write("{0,2}", Board[i].Number.ToString());
                SetColorToDefault();
            }
            else
            if (Board[i] != null && Board[i].PlayerStone == Player.WhitePlayer)
            {
                SetColorToWhite();
                Console.Write("{0,2}", Board[i].Number.ToString());
                SetColorToDefault();
            }
            else
                Console.Write(@"00");
        }
    }
}
