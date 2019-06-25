using System;
using prisoneers_dilema.Backend.Players;
using prisoneers_dilema.Backend.Logics;
using prisoneers_dilema.Frontend.Displays;
using prisoneers_dilema.Backend.Leagues;
using prisoneers_dilema.Backend;

namespace prisoneers_dilema.Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogic logic = new DefaultLogic();
            Player[] players = { new CooperativePlayer(0f), new NonCooperativePlayer(0f), new RandomPlayer(0f), new MyPlayer(0f) };
            League league = new AllVsAll(players, logic, 10);
            IDisplay display = new DefaultDisplay();

            league.Start();
            LeagueData data = league.Data;

            display.ShowInfo(data);
            
        }
    }
}