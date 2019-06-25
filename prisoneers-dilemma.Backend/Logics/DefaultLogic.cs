using System;
using System.Collections.Generic;
using System.Text;
using prisoneers_dilema.Backend.Players;

namespace prisoneers_dilema.Backend.Logics
{
    public class DefaultLogic : ILogic
    {
        /*                     P2         P2
         *  -------------------------------------
         *      |  (P1,P2) |   No    |    Yes   |
         *  -------------------------------------
         *  P1  |    No    | (-1, -1)| (-5, 5)  |      
         *  -------------------------------------
         *  P1  |    Yes   | (5, -5) |  (3, 3)  |
         *  -------------------------------------
         */

        protected float[][] _player1Distribution = new float[2][]
        {
            new float[2]{-1f, -5f},
            new float[2]{5f, 3f}
        };

        protected float[][] _player2Distribution = new float[2][]
        {
            new float[2]{-1f, 5f},
            new float[2]{-5f, 3f}
        };

        public void Decide(Player player1, Player player2)
        {
            float[] rewards = Rewards(player1.Cooperate, player2.Cooperate);

            player1.Money += rewards[0];
            player2.Money += rewards[1];
        }

        public float[] Rewards(Player.Selection player1, Player.Selection player2)
        {
            float[] rewards = new float[2] {
                _player1Distribution[ (int) player1 ][ (int) player2 ],
                _player2Distribution[ (int) player1 ][ (int) player2 ]
            };

            return rewards;
        }
    }
}
