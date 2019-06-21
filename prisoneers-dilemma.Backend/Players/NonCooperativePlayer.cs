using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class NonCooperativePlayer : Player
    {
        public NonCooperativePlayer(float money, string name = "Maquiavelo") : base(money, name)
        {

        }

        public override void NewMove()
        {
            Cooperate = Selection.No;
        }
    }
}
