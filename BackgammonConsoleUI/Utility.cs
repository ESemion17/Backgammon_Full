using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace BackgammonConsoleUI
{
    public static class Utility
    {
        public static void PrintToConsole(this IPanel panel, IEnumerable<int> cubes)
        {
            var cubesList = cubes.ToList<int>();
            int i;
            SetColorToDefault();
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)0;
            Console.WriteLine("Enter 'exit' to quit");
            Console.WriteLine($"Now turn = {panel.PlayingNow}");
            SetColorToDefault();
            Console.WriteLine(@"||=13=||=14=||=15=||=16=||=17=||=18=|||||||=19=||=20=||=21=||=22=||=23=||=24=||||||");
            i = 12;
            Console.Write(@"||\");
            PrintByColor(panel,i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/|||||||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.Write(@"/||\");
            PrintByColor(panel, i++);
            Console.WriteLine(@"/||||||");
            Console.WriteLine(@"|| \/ || \/ || \/ || \/ || \/ || \/ ||||||| \/ || \/ || \/ || \/ || \/ || \/ ||||||");
            Console.Write(@"||    ||    ||    ||    ||    ||    |||");
            PrintByColor(panel, 1, 'e');
            Console.Write(@"||    ||    ||    ||    ||    ||    ||");
            PrintByColor(panel, 1, 'h');
            Console.WriteLine(@"||");
            Console.WriteLine(@"||====||====||====||====||====||====||Eat||====||====||====||====||====||====|Home|     Cubes:");
            Console.Write(@"||    ||    ||    ||    ||    ||    |||");
            PrintByColor(panel, 0, 'e');
            Console.Write(@"||    ||    ||    ||    ||    ||    ||");
            PrintByColor(panel, 0, 'h');
            Console.Write(@"||       ");
            PrintCube(0, cubesList);
            Console.Write(@"|| /\ || /\ || /\ || /\ || /\ || /\ ||||||| /\ || /\ || /\ || /\ || /\ || /\ ||||||       ");
            PrintCube(1, cubesList);
            i = 11;
            Console.Write(@"||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\|||||||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||/");
            PrintByColor(panel, i--);
            Console.Write(@"\||||||       ");
            PrintCube(2, cubesList);
            Console.Write(@"||=12=||=11=||=10=||= 9=||= 8=||= 7=|||||||= 6=||= 5=||= 4=||= 3=||= 2=||= 1=||||||       ");
            PrintCube(3, cubesList);
            Console.ForegroundColor = (ConsoleColor)0;
        }
        private static void PrintCube(int i, List<int> cube)
        {
            if (cube.Count > i)
                Console.Write($"{cube[i]}");
            Console.WriteLine();
        }
        private static void SetColorToDefault()
        {
            Console.BackgroundColor = (ConsoleColor)7;
            Console.ForegroundColor = (ConsoleColor)8;
        }
        private static void SetColorToBlack()
        {
            Console.BackgroundColor = (ConsoleColor)0;
            Console.ForegroundColor = (ConsoleColor)12;
        }
        private static void SetColorToWhite()
        {
            Console.BackgroundColor = (ConsoleColor)15;
            Console.ForegroundColor = (ConsoleColor)12;
        }
        private static void PrintByColor(IPanel panel,int i, char ch = 'd')
        {
            if (i == 0 && ch == 'e')
            {
                SetColorToBlack();
                Console.Write("{0,2}", panel.Eaten[i] == 0 ? "0" : panel.Eaten[i].ToString());
                SetColorToDefault();
            }
            else
            if (i == 0 && ch == 'h')
            {
                SetColorToBlack();
                Console.Write("{0,2}", panel.AtHome[i] == 0 ? "0" : panel.AtHome[i].ToString());
                SetColorToDefault();
            }
            else
            if (i == 1 && ch == 'e')
            {
                SetColorToWhite();
                Console.Write("{0,2}", panel.Eaten[i] == 0 ? "0" : panel.Eaten[i].ToString());
                SetColorToDefault();
            }
            else
            if (i == 1 && ch == 'h')
            {
                SetColorToWhite();
                Console.Write("{0,2}", panel.AtHome[i] == 0 ? "0" : panel.AtHome[i].ToString());
                SetColorToDefault();
            }
            else
            if (panel.Board[i] != null && panel.Board[i].PlayerStone == Player.BlackPlayer)
            {
                SetColorToBlack();
                Console.Write("{0,2}", panel.Board[i].Number.ToString());
                SetColorToDefault();
            }
            else
            if (panel.Board[i] != null && panel.Board[i].PlayerStone == Player.WhitePlayer)
            {
                SetColorToWhite();
                Console.Write("{0,2}", panel.Board[i].Number.ToString());
                SetColorToDefault();
            }
            else
                Console.Write(@"00");
        }
    }
}
