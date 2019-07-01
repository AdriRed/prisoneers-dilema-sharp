namespace prisoneers_dilema.Backend.Players
{
    public class OppositeLastPlayer : YourLastPlayer
    {

        public OppositeLastPlayer(float money = 0f, string name = "OppositeLast Player") : base(money, name)
        {
        }

        public override void NewMove()
        {
            int otherPlayerIndex = InGamePlayer == 0 ?
                1
                : 0;

            Selection last = GetLastSelection(otherPlayerIndex);

            last = InvertSelection(last);

            Cooperate = last;
        }

        protected Selection InvertSelection(Selection last)
        {
            return ((int)last == 0) ?
                (Selection)1
                : (Selection)0;
        }
    }
}
