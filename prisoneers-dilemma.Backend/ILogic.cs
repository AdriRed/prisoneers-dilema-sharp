using System;
using System.Collections.Generic;
using prisoneers_dilema.Backend.Players;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public interface ILogic
    {
        void Decide(Player player1, Player player2);
        float[] Rewards(Player.Selection player1, Player.Selection player2);
    }
}
