using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public class Round
    {
        private Player _player1;
        private Player _player2;
        private ILogic _rules;

        public RoundData Data { get; private set; }

        public Round(Player player1, Player player2, ILogic rules)
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
        public string[] Names;
        public Player.Selection[] Selections;
        public float[] DeltaMoney;
        public float[] MoneyBefore;

        public RoundData(Player player1, Player player2, ILogic logic)
        {
            Names = new string[] { player1.Name, player2.Name };
            Selections = new Player.Selection[] { player1.Cooperate, player2.Cooperate };
            DeltaMoney = logic.Distribution[(int)Selections[0]][(int)Selections[1]];
            MoneyBefore = new float[] { player1.Money - DeltaMoney[0], player2.Money - DeltaMoney[1] };
        }
    }
}
