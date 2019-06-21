using System;
using System.Collections.Generic;
using prisoneers_dilema.Backend.Players;

namespace prisoneers_dilema.Backend
{
    public class Game
    {
        private ILogic _rules;
        protected Match Players;
        public GameData Data { get; private set; }

        public Game(Match players, ILogic rules)
        {
            Players = players;
            Rules = rules;
            History = new List<RoundData>();
            Data = new GameData(Player1, Player2, History);
        }

        public Player Player2
        {
            get { return Players.Player2; }
        }

        public Player Player1
        {
            get { return Players.Player1; }
        }

        public ILogic Rules
        {
            get { return _rules; }
            private set { _rules = value; }
        }

        public void SaveData()
        {
            Data.DeltaMoney[0] = Player1.Money - Data.DeltaMoney[0];
            Data.DeltaMoney[1] = Player2.Money - Data.DeltaMoney[1];
            Data.TotalMoney[0] = Player1.Money;
            Data.TotalMoney[1] = Player2.Money;
        }

        public List<RoundData> History
        {
            get; private set;
        }

        public RoundData LastRound
        {
            get
            {
                return History[History.Count - 1];
            }
        }

        public void NewRound()
        {
            Round actualRound = new Round(Player1, Player2, Rules);
            actualRound.Execute();
            History.Add(actualRound.Data);
        }

        public void Start(int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                NewRound();
            }
        }
    }

    public struct GameData
    {
        public List<RoundData> History;
        public string[] Names;
        public float[] DeltaMoney, TotalMoney;

        public GameData(Player player1, Player player2, List<RoundData> history)
        {
            History = history;
            Names = new string[] { player1.Name, player2.Name };
            DeltaMoney = new float[] { player1.Money, player2.Money };
            TotalMoney = new float[] { player1.Money, player2.Money };
        }
    }
}
