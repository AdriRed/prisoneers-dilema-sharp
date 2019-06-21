using System;
using System.Collections.Generic;
using prisoneers_dilema.Backend.Players;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public interface ILogic
    {
        float[][][] Distribution { get; }
        void Decide(Player player1, Player player2);
    }
}
