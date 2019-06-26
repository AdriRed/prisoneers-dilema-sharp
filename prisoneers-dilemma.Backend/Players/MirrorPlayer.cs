using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class MirrorPlayer : RegresivePlayer
    {

        public MirrorPlayer(float money = 0f , string name = "Mirror Player") : base(money, name)
        {

        }

        public override void NewMove()
        {
            int otherPlayerIndex = InGamePlayer == 0 ?
                1
                : 0;

            Cooperate = base.RegresiveSelection(otherPlayerIndex);
        }
    }
}
