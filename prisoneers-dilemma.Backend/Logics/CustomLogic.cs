using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Logics
{
    public class CustomLogic : DefaultLogic
    {
        
        private float[][] player1rewards, player2rewards;

        protected override float[][] Player1Distribution
        {
            get
            {
                return player1rewards;
            }
        }

        protected override float[][] Player2Distribution
        {
            get
            {
                return player2rewards;
            }
        }

        public CustomLogic (float[][] player1, float[][] player2)
        {
            player1rewards = player1;
            player2rewards = player2;
        }


    }
}
