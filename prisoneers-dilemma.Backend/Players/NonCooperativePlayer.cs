namespace prisoneers_dilema.Backend.Players
{
    public class NonCooperativePlayer : Player
    {
        public NonCooperativePlayer(float money = 0f, string name = "Maquiavelo") : base(money, name)
        {

        }

        public override void NewMove()
        {
            Cooperate = Selection.No;
        }
    }
}
