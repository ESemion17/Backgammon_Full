using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace BackgammonConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            Panel panel = (Panel)gameEngine.NewGame();
            Cube cubes = new Cube();
            Move move;
            cubes.Roll();
            string pressed;
            int fromNum;
            int toNum;
            bool flag=true;
            do
            {
                if (!cubes.IsMoreCube())
                {
                    panel.NextPlayer();
                    cubes.Roll();
                }
                panel.PrintToConsole(cubes.Dise);
                if (panel.AtHome[0] == 15 || panel.AtHome[1] == 15)
                    break;
                if (!gameEngine.IsAnyMoveAvalible(cubes, panel))
                {
                    cubes.Clear();
                    panel.NextPlayer();
                    cubes.Roll();
                    Console.WriteLine("I'm sorry but you didn't have any move");
                    Console.ReadLine();
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Enter from where you wanna take your tool (number 1-24, use 0 to take from eaten)");
                        pressed = Console.ReadLine();
                        if (pressed == "exit")
                            flag = false;
                    } while (!(int.TryParse(pressed, out fromNum) && fromNum >= 0 && fromNum <= 24) && flag);
                    if (!flag)
                        continue;
                    do
                    {
                        Console.WriteLine("Enter to where you wanna put your tool (number 1-24, use 0 to put from at home)");
                        pressed = Console.ReadLine();
                        if (pressed == "exit")
                            flag = false;
                    } while (!(int.TryParse(pressed, out toNum) && toNum >= 0 && toNum <= 24) && flag);
                    if (!flag)
                        continue;
                    move = new Move() { From = fromNum == 0 ? -1 : fromNum - 1, To = toNum == 0 ? -1 : toNum - 1 };

                    if (gameEngine.IsLegal(panel, move, cubes))
                    {
                        Console.WriteLine("Your move is legal!\nPress any key to continue");
                        int k = gameEngine.LegalCube(move, cubes, panel);
                        gameEngine.MakeMove(panel, move);
                        cubes.Remove(gameEngine.LegalCube(move, cubes, panel));
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your move is illegal, try again!\nPress any key to try again");
                        Console.ReadLine();
                    }
                }
            } while (flag);
            if (panel.AtHome[0] == 15)
                Console.WriteLine("Player White Wins");
            if (panel.AtHome[1] == 15)
                Console.WriteLine("Player Black Wins");
            Console.WriteLine("\nPress again to exit");
            Console.ReadLine();
        }
    }
}
