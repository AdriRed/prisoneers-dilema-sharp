namespace prisoneers_dilema.Backend.Players
{
    public class CooperativePlayer : Player
    {
        public CooperativePlayer(float money = 0f, string name = "Panfilo") : base(money, name)
        {
        }

        public override void NewMove()
        {
            Cooperate = Selection.Yes;
        }
    }
}

