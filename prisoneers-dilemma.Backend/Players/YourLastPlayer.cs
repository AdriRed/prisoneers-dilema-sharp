using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class YourLastPlayer : CleverPlayer
    {
        public YourLastPlayer(float money = 0f, string name = "YourLast Player") : base(money, name)
        {
        }

        public override void NewMove()
        {
            int otherPlayerIndex = InGamePlayer == 0 ? 
                1 
                : 0;

            Selection last = GetLastSelection(otherPlayerIndex);

            Cooperate = last;
        }

        protected Selection GetLastSelection(int otherPlayerIndex)
        {
            Selection selection;

            if (History.Count == 0)
            {
                selection = Selection.No;
            }
            else
            {
                selection = History[History.Count - 1].Selections[otherPlayerIndex];
            }

            return selection;
        }
    }
}
