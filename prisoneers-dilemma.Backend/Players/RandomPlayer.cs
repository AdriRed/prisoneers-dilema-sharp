using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class RandomPlayer : Player
    {
        private float _trueProbablility;
        private Random rd;

        public RandomPlayer(float money, float trueProbability = 0.5f, string name = "Tuntun") : base(money, name)
        {
            rd = new Random();
            _trueProbablility = trueProbability;
        }
        public override void NewMove()
        {
            Cooperate = rd.NextDouble() < _trueProbablility ? 
                Selection.Yes 
                : Selection.No ;
        }
    }
}
