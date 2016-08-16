using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IGameEngine
    {
        IPanel NewGame();
        bool IsLegal(IPanel panel, Move move, ICube cube);
        int LegalCube(Move move, ICube cube, IPanel panel);
        void MakeMove(IPanel panel, Move move);
        bool IsAnyMoveAvalible(ICube cube, IPanel panel);
    }
}