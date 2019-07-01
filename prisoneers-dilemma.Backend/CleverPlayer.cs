using System.Collections.Generic;

namespace prisoneers_dilema.Backend
{
    public abstract class CleverPlayer : Player
    {
        public List<RoundData> History;
        public Logic FollowingLogic;

        public CleverPlayer(float money, string name = "Clever player") : base(money, name)
        {

        }
    }
}
