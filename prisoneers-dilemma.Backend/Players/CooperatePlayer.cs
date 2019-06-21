using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class CooperativePlayer : Player
    {
        public CooperativePlayer(float money, string name = "Panfilo") : base(money, name)
        {
        }

        public override void NewMove()
        {
            Cooperate = Selection.Yes;
        }
    }
}

