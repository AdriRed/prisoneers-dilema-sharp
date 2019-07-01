using System;
using System.Collections.Generic;

namespace prisoneers_dilema.Backend.Leagues
{
    public class Tournament : League
    {
        private int _lonelyPlayerIndex;
        public int RoundsPerGame;


        public Tournament(Player[] players, Logic rules, int roundsPerGame) : base(players, rules)
        {
            RoundsPerGame = roundsPerGame;
        }

        public Tournament(Player[] players, float[][] player1Payments, float[][] player2Payments, int roundsPerGame)
            : this(players, new Logic(player1Payments, player2Payments), roundsPerGame)
        {

        }

        protected override void SetMatches(Player[] players)
        {
            Matches = new List<Match>();

            if (players.Length % 2 == 0)
            {
                _lonelyPlayerIndex = -1;
                for (int i = 0; i < players.Length / 2; i++)
                {
                    Matches.Add(new Match(players[i * 2], players[i * 2 + 1]));
                }
            }
            else
            {
                _lonelyPlayerIndex = (new Random()).Next(players.Length);

                int matchPlayer1Index = -1;

                for (int i = 0; i < players.Length; i++)
                {
                    if (i != _lonelyPlayerIndex)
                    {
                        if (matchPlayer1Index != -1)
                        {
                            Matches.Add(new Match(players[matchPlayer1Index], players[i]));
                            matchPlayer1Index = -1;
                        }
                        else
                        {
                            matchPlayer1Index = i;
                        }
                    }
                }
            }
        }

        public override void Start()
        {
            Game game;
            int totalMatches = Players.Length - 1;
            Player lastWinner = null;

            for (int i = 0; i < totalMatches; i++)
            {
                game = new Game(Matches[i], Rules);
                game.Start(RoundsPerGame);
                game.SaveData();
                History.Add(game.Data);

                if (lastWinner == null)
                {
                    lastWinner = GetWinnerFromGame(History.Count - 1);
                    if (_lonelyPlayerIndex != -1)
                    {
                        Matches.Add(new Match(lastWinner, FindPlayer(_lonelyPlayerIndex)));
                        _lonelyPlayerIndex = -1;
                        lastWinner = null;
                    }
                }
                else
                {
                    Matches.Add(new Match(lastWinner, GetWinnerFromGame(History.Count - 1)));
                    lastWinner = null;
                }
            }

            Data = new LeagueData(Matches, History, Players);
        }

        private Player GetWinnerFromGame(int index)
        {
            int id = History[index].DeltaMoney[0] > History[index].DeltaMoney[1] ?
                History[index].Players[0].Id
                :
                History[index].Players[1].Id;

            Player winner = FindPlayer(id);

            if (winner == null)
            {
                throw new Exception("Error 404 Player Not Found");
            }
            else
            {
                return winner;
            }
        }

        private Player FindPlayer(int id)
        {
            Player target = null;
            bool found = false;

            for (int i = 0; i < Players.Length && !found; i++)
            {
                if (Players[i].Data.Id == id)
                {
                    found = true;
                    target = Players[i];
                }
            }

            return target;
        }
    }
}
