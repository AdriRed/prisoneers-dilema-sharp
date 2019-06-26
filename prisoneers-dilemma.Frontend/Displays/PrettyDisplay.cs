using System;
using System.Collections.Generic;
using System.Text;
using prisoneers_dilema.Backend;

namespace prisoneers_dilema.Frontend.Displays
{
    class PrettyDisplay : IDisplay
    {
        private string moneyFormat = "+0.00$;-0.00$";
        private int minLengthName = 15;
        private int minLengthCooperate = 3;
        private int minLengthMoney = 8;


        public virtual void ShowInfo(Player player, bool writeline)
        {
            string info = String.Format("{0}({1}): {2}", 
                player.Data.Name.PadRight(minLengthName, ' '), 
                player.Data.Id.ToString("00"), 
                player.Money.ToString(moneyFormat).PadRight(minLengthMoney, ' ') );

            if (writeline)
            {
                Console.WriteLine(info);
            }
            else
            {
                Console.Write(info);
            }
        }

        public virtual void ShowInfo(RoundData round, bool writeline)
        {
            PlayerRoundInfo(round, 0);
            if (writeline)
            {
                Console.WriteLine();
                PlayerRoundInfo(round, 1);
                Console.WriteLine();
                Console.WriteLine("-------------------");
            }
            else
            {
                Console.Write(" ");
                PlayerRoundInfo(round, 1);
            }
        }

        private void ShowRoundHistory(List<RoundData> history)
        {
            Console.WriteLine("\n------------------Round History------------------");
            foreach (RoundData item in history)
            {
                ShowInfo(item, true);
            }
        }

        public virtual void ShowInfo(GameData game, bool writeline)
        {
            Console.WriteLine("------------{0} vs. {1}--------------", 
                game.Players[0].Name.PadLeft(minLengthName, '-'), 
                game.Players[1].Name.PadRight(minLengthName, '-') );

            ShowRoundHistory(game.History);
            Console.WriteLine("\n---------------------TOTALS----------------------");

            PlayerGameInfo(game, 0);
            if (writeline)
            {
                Console.WriteLine();
                PlayerGameInfo(game, 1);
                Console.WriteLine();
            }
            else
            {
                Console.Write(" ");
                PlayerGameInfo(game, 1);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowInfo(LeagueData league)
        {
            Console.WriteLine("--------------------Matches----------------------");
            ShowMatches(league.Matches);
            Console.WriteLine();
            ShowGameHistory(league.History);
            Console.WriteLine();
            Console.WriteLine("---------------------League finished----------------------");
            ShowPlayers(league.Players);
            Console.WriteLine();
        }

        private void ShowPlayers(Player[] players)
        {
            foreach (Player item in players)
            {
                ShowInfo(item, true);
            }
        }

        private void ShowMatches(List<Match> matches)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine(" {0} vs. {1} ", 
                    match.Player1.Data.Name.PadRight(minLengthName, ' ') , 
                    match.Player2.Data.Name.PadRight(minLengthName, ' ') );
            }
        }

        private void ShowGameHistory(List<GameData> history)
        {
            foreach (GameData gameData in history)
            {
                ShowInfo(gameData, true);
            }
        }

        private void PlayerGameInfo(GameData data, int player)
        {
            string info = String.Format("{0} {1} ({2})",
                data.Players[player].Name.PadRight(minLengthName, ' '), 
                data.TotalMoney[player].ToString(moneyFormat).PadRight(minLengthMoney, ' '),
                data.DeltaMoney[player].ToString(moneyFormat));

            Console.Write(info);
        }

        private void PlayerRoundInfo(RoundData data, int player)
        {
            string info = String.Format("{0} {1} Cooperate? {2} ({3})",
                data.Players[player].Name.PadRight(minLengthName, ' '), 
                data.MoneyBefore[player].ToString(moneyFormat).PadRight(minLengthMoney, ' '),
                data.Selections[player].ToString().PadRight(minLengthCooperate, ' '), 
                data.DeltaMoney[player].ToString(moneyFormat));

            Console.Write(info);
        }
    }
}
