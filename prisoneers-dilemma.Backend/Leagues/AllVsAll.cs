using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Leagues
{
    public class AllVsAll : League
    {
        public int RoundsPerGame;
        public AllVsAll(Player[] players, ILogic rules, int roundsPerGame) : base(players, rules)
        {
            RoundsPerGame = roundsPerGame;
        }

        protected override void SetMatches(Player[] players)
        {
            for (int i = 0; i < players.Length - 1; i++)
            {
                for (int j = i + 1; j < players.Length; j++)
                {
                    Matches.Add(new Match(players[i], players[j]));
                }
            }
        }

        public override void Start()
        {
            Game game;

            for (int i = 0; i < Matches.Count; i++)
            {
                game = new Game(Matches[i], Rules);
                game.Start(RoundsPerGame);
                game.SaveData();
                History.Add(game.Data);
            }

            Data = new LeagueData(Matches, History, Players);
        }
    }
}
