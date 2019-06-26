using System;
using System.Collections.Generic;
using prisoneers_dilema.Backend.Players;

namespace prisoneers_dilema.Backend
{
    public class Game
    {
        protected Match Players;

        public Game(Match players, ILogic rules)
        {
            Players = players;
            Rules = rules;
            History = new List<RoundData>();
            Data = new GameData(Player1, Player2, History);

            players.Player1.InGamePlayer = 0;

            if (players.Player1 is CleverPlayer clever)
            {
                clever.History = History;
                clever.FollowingLogic = rules;
            }
                

            players.Player2.InGamePlayer = 1;
            if (players.Player2 is CleverPlayer clever2)
            {
                clever2.History = History;
                clever2.FollowingLogic = rules;
            }
                
        }

        public GameData Data { get; private set; }
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
            get; private set;
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
        public PlayerData[] Players;
        public float[] DeltaMoney, TotalMoney;

        public GameData(Player player1, Player player2, List<RoundData> history)
        {
            History = history;
            Players = new PlayerData[] { player1.Data, player2.Data };
            DeltaMoney = new float[] { player1.Money, player2.Money };
            TotalMoney = new float[] { player1.Money, player2.Money };
        }
    }
}
