namespace prisoneers_dilema.Backend.Players
{
    public class RegresivePlayer : CleverPlayer
    {
        public RegresivePlayer(float money = 0f, string name = "Regresive Player") : base(money, name)
        {

        }

        public override void NewMove()
        {
            int otherPlayerIndex = InGamePlayer == 0 ?
                1
                : 0;

            float[] possibleRewards;
            Player.Selection prevision;

            prevision = RegresiveSelection(otherPlayerIndex);
            possibleRewards = GetPossibleRewards(otherPlayerIndex, prevision);

            Cooperate = (Player.Selection)(
                (
                    possibleRewards[0] < possibleRewards[1]) ?
                    1
                    : 0
                );
        }

        private float[] GetPossibleRewards(int otherPlayerIndex, Selection prevision)
        {
            float[] possibleRewards = new float[2];

            if (otherPlayerIndex == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    possibleRewards[i] = FollowingLogic.Rewards(prevision, (Player.Selection)i)[1];
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    possibleRewards[i] = FollowingLogic.Rewards((Player.Selection)i, prevision)[0];
                }
            }

            return possibleRewards;
        }

        public Selection RegresiveSelection(int otherPlayer)
        {
            Selection prevision;

            int otherYes = 0, otherNo = 0;

            for (int i = History.Count - 1, j = 0; i >= 0 && j < 3; i--, j++)
            {
                if (History[i].Selections[otherPlayer] == Selection.Yes)
                {
                    otherYes++;
                }
                else
                {
                    otherNo++;
                }
            }

            if (otherYes > otherNo)
            {
                prevision = Selection.Yes;
            }
            else
            {
                prevision = Selection.No;
            }

            return prevision;
        }
    }
}
