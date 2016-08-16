using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameEngine : IGameEngine
    {
        public IPanel NewGame()
        {
            var panel = new Panel();
            panel.Board = new Triangel[24];
            panel.Board[0] = new Triangel(Player.WhitePlayer, 2);
            panel.Board[5] = new Triangel(Player.BlackPlayer, 5);
            panel.Board[7] = new Triangel(Player.BlackPlayer, 3);
            panel.Board[11] = new Triangel(Player.WhitePlayer, 5);
            panel.Board[12] = new Triangel(Player.BlackPlayer, 5);
            panel.Board[16] = new Triangel(Player.WhitePlayer, 3);
            panel.Board[18] = new Triangel(Player.WhitePlayer, 5);
            panel.Board[23] = new Triangel(Player.BlackPlayer, 2);
            panel.Eaten = new int[2] { 0, 0 };
            panel.AtHome = new int[2] { 0, 0 };
            panel.PlayingNow = Player.BlackPlayer;
            return panel;
        }
        public bool IsLegal(IPanel panel, Move move, ICube cube)
        {
            return IsLegalDirection((Panel)panel, move) && IsLegalCube(move, (Cube)cube, (Panel)panel) && IsLegalPanel((Panel)panel, move) && IsEatenTakeOut(panel,move);
        }
        private bool IsEatenTakeOut(IPanel panel, Move move)
        {
            if (panel.Eaten[(int)panel.PlayingNow] != 0)
                if (move.From != -1)
                    return false;
            return true;
        }
        private bool IsLegalDirection(Panel panel, Move move)
        {
            if (move.From == -1 || move.To == -1)
                return true;
            var player = panel.PlayingNow;
            if (player == Player.BlackPlayer)
                if (move.From > move.To)
                    return true;
                else
                    return false;
            else
                if (move.From < move.To)
                return true;
            else
                return false;
        }
        private bool IsLegalPanel(Panel panel, Move move)
        {
            return IsLegalFromBoard(move.From, panel) && IsLegalToBoard(move.To, panel);
        }
        private bool IsLegalFromBoard(int from, Panel panel)
        {
            if (from == -1)
                if (panel.Eaten[(int)panel.PlayingNow] != 0)
                    return true;
                else
                    return false;
            if (panel.Board[from] != null && panel.Board[from].PlayerStone == panel.PlayingNow)
                return true;
            return false;
        }
        private bool IsLegalToBoard(int to, Panel panel)
        {
            if (to == -1)
                if (IsLegalToMoveHome(panel))
                    return true;
                else
                    return false;
            if (panel.Board[to] == null ||
                panel.Board[to].Number == 1 ||
                panel.Board[to].PlayerStone == panel.PlayingNow)
                return true;
            return false;
        }
        private bool IsLegalToMoveHome(Panel panel)
        {
            int sum = panel.AtHome[(int)panel.PlayingNow];
            if (panel.PlayingNow == Player.BlackPlayer)
            {
                for (int i = 0; i < 6; i++)
                    if (panel.Board[i] != null && panel.Board[i].PlayerStone == panel.PlayingNow)
                        sum += panel.Board[i].Number;
                if (sum == 15)
                    return true;
                else
                    return false;
            }
            for (int i = 18; i < 24; i++)
                if (panel.Board[i] != null && panel.Board[i].PlayerStone == panel.PlayingNow)
                    sum += panel.Board[i].Number;
            if (sum == 15)
                return true;
            else
                return false;
        }
        private bool IsLegalCube(Move move, Cube cube, Panel panel)
        {
            if (move.To == -1)
                if (panel.PlayingNow == Player.BlackPlayer)
                {
                    foreach (var item in Enumerable.Range(move.From+1, 6).Where<int>(x => x < 7))
                        if (cube.Dise.ToList<int>().IndexOf(item) != -1)
                            return true;
                    return false;
                }
                else
                {
                    foreach (var item in Enumerable.Range(24 - move.From, 6).Where<int>(x => x < 7))
                        if (cube.Dise.ToList<int>().IndexOf(item) != -1)
                            return true;
                    return false;
                }
            int diff;
            if (move.From == -1)
                if (panel.PlayingNow == Player.BlackPlayer)
                    diff = 24 - move.To;
                else
                    diff = move.To + 1;
            else
                diff = Math.Abs(move.From - move.To);
            return cube.Dise.ToList<int>().IndexOf(diff) == -1 ? false : true;
        }
        public int LegalCube(Move move, ICube cube, IPanel panel)
        {
            if (move.To == -1)
                if (panel.PlayingNow == Player.BlackPlayer)
                {
                    foreach (var item in Enumerable.Range(move.From + 1, 6).Where<int>(x => x < 7))
                        if (cube.Dise.ToList<int>().IndexOf(item) != -1)
                            return item;
                }
                else
                {
                    foreach (var item in Enumerable.Range(24 - move.From, 6).Where<int>(x => x < 7))
                        if (cube.Dise.ToList<int>().IndexOf(item) != -1)
                            return item;
                }
            int diff;
            if (move.From == -1)
                if (panel.PlayingNow == Player.BlackPlayer)
                    diff = 24 - move.To;
                else
                    diff = move.To + 1;
            else
                diff = Math.Abs(move.From - move.To);
            return diff;
        }
        public void MakeMove(IPanel panel, Move move)
        {
            if (move.From == -1)
                panel.Eaten[(int)panel.PlayingNow]--;
            else
                panel.Board[move.From]--;
            if (move.To == -1)
                panel.AtHome[(int)panel.PlayingNow]++;
            else
            {
                if (panel.Board[move.To] == null)
                    panel.Board[move.To] = new Triangel(panel.PlayingNow);
                else
                    if (panel.Board[move.To].PlayerStone == panel.PlayingNow)
                        panel.Board[move.To]++;
                    else
                    {
                        panel.Eaten[(int)panel.Board[move.To].PlayerStone]++;
                        panel.Board[move.To] = new Triangel(panel.PlayingNow);
                    }
            }
        }
        public bool IsAnyMoveAvalible(ICube cube, IPanel panel)
        {
            for (int i = -1; i < 24; i++)
                for (int j = -1; j < 24; j++)
                    if (IsLegal(panel, new Move() { From = i, To = j }, cube))
                        return true;
            return false;
        }
    }
}
