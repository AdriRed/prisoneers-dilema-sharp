using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public abstract class CleverPlayer : Player
    {
        public List<RoundData> History;
        public ILogic FollowingLogic;

        public CleverPlayer(float money, string name = "Clever player") : base(money, name)
        {

        }
    }
}
