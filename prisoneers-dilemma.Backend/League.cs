using System.Collections.Generic;

namespace prisoneers_dilema.Backend
{
    public abstract class League
    {
        protected List<Match> Matches;
        public List<GameData> History { get; protected set; }
        public LeagueData Data { get; protected set; }
        public Player[] Players { get; protected set; }
        protected Logic Rules;
        public League(Player[] players, Logic rules)
        {
            Rules = rules;
            History = new List<GameData>();
            Matches = new List<Match>();
            SetMatches(players);
            Players = players;
        }

        public League(Player[] players, float[][] player1Payments, float[][] player2Payments)
            : this(players, new Logic(player1Payments, player2Payments))
        {

        }

        protected abstract void SetMatches(Player[] players);
        public abstract void Start();
    }

    public struct LeagueData
    {
        public List<Match> Matches;
        public List<GameData> History;
        public Player[] Players;

        public LeagueData(List<Match> matches, List<GameData> history, Player[] players)
        {
            Matches = matches;
            History = history;
            Players = players;
        }
    }

    public struct Match
    {
        public Player Player1;
        public Player Player2;

        public Match(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
