using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class MyPlayer : CleverPlayer
    {
        public MyPlayer(float money, string name = "My Player") : base(money, name)
        {

        }

        public override void NewMove()
        {
            int otherYes = 0, otherNo = 0;
            int otherPlayerIndex = InGamePlayer == 0 ? 1 : 0;
            float[] possibleRewards = new float[2];
            Player.Selection prevision;

            for (int i = History.Count - 1, j = 0; i >= 0 && j < 3; i--, j++)
            {
                if (History[i].Selections[otherPlayerIndex] == Selection.Yes)
                {
                    otherYes++;
                } else
                {
                    otherNo++;
                }
            }

            if (otherYes > otherNo)
            {
                prevision = Selection.Yes;
            } else
            {
                prevision = Selection.No;
            }

            if (otherPlayerIndex == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    possibleRewards[i] = FollowingLogic.Rewards(prevision, (Player.Selection)i)[1];
                }
            } else
            {
                for (int i = 0; i < 2; i++)
                {
                    possibleRewards[i] = FollowingLogic.Rewards((Player.Selection)i, prevision)[0];
                }
            }

            Cooperate = (Player.Selection) ((possibleRewards[0] < possibleRewards[1]) ? 1 : 0);
        }
    }
}
