using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public abstract class CleverPlayer : Player
    {
        protected List<RoundData> History;

        public CleverPlayer(float money, string name, List<RoundData> history) : base(money, name)
        {
            History = history;
        }
    }
}
