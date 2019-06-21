using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Players
{
    public class MyPlayer : CleverPlayer
    {
        public MyPlayer(float money, string name, List<RoundData> history) : base(money, name, history)
        {
        }

        public override void NewMove()
        {
            int otherYes = 0, otherNo = 0;
            int otherPlayerIndex = History[0].Players[0].Equals(this.Data) ? 1 : 0;
            Player.Selection prevision;

            for (int i = History.Count, j = 0; i >= 0 && j < 3; i--, j++)
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
                prevision = Selection.No;
            } else
            {
                prevision = Selection.Yes;
            }

            //for (int i = 0; i < History[0].Logic.Distribution.; i++)
            //{

            //}
        }
    }
}
