using System;
using System.Collections.Generic;
using System.Text;
using prisoneers_dilema.Backend.Players;

namespace prisoneers_dilema.Backend.Logics
{
    public class DefaultLogic : ILogic
    {
        protected float[][][] _moneyDistribution = new float[2][][]
        {
            new float[2][]
            {
                new float[2]{  3f,  3f },
                new float[2]{ -5f,  5f }
            },
            new float[2][]
            {
                new float[2]{  5f, -5f },
                new float[2]{ -1f, -1f }
            }
        };

        public float[][][] Distribution
        {
            get
            {
                return _moneyDistribution;
            }
        }

        public void Decide(Player player1, Player player2)
        {
            float[] rewards = Distribution[(int)player1.Cooperate][(int)player2.Cooperate];

            player1.Money += rewards[0];
            player2.Money += rewards[1];
        }
    }
}
