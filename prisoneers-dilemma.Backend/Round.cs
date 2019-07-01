namespace prisoneers_dilema.Backend
{
    public class Round
    {
        private Player _player1;
        private Player _player2;
        private Logic _rules;

        public RoundData Data { get; private set; }

        public Round(Player player1, Player player2, Logic rules)
        {
            _player1 = player1;
            _player2 = player2;
            _rules = rules;
        }

        private void GetMoves()
        {
            _player1.NewMove();
            _player2.NewMove();
        }

        public void Execute()
        {
            GetMoves();
            _rules.Decide(_player1, _player2);
            SaveData();
        }

        public void SaveData()
        {
            Data = new RoundData(_player1, _player2, _rules);
        }

    }

    public struct RoundData
    {
        public PlayerData[] Players;
        public Player.Selection[] Selections;
        public float[] DeltaMoney;
        public float[] MoneyBefore;
        public Logic Logic;

        public RoundData(Player player1, Player player2, Logic logic)
        {
            Players = new PlayerData[] { player1.Data, player2.Data };
            Selections = new Player.Selection[] { player1.Cooperate, player2.Cooperate };
            DeltaMoney = logic.Rewards(Selections[0], Selections[1]);
            MoneyBefore = new float[] { player1.Money - DeltaMoney[0], player2.Money - DeltaMoney[1] };
            Logic = logic;
        }
    }
}
