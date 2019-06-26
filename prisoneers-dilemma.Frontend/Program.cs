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
            ILogic logic = new Chicken();
            Player[] players = {

                new CooperativePlayer(),
                new NonCooperativePlayer(),
                new RandomPlayer(0f),
                new OppositeLastPlayer(0f, "opposite"),
                new MirrorPlayer(0f, "mirror"),
                new RegresivePlayer(),
                new YourLastPlayer()


            };
            League league;
            IDisplay display = new PrettyDisplay();

            league = new AllVsAll(players, logic, 15);
            league.Start();
            display.ShowInfo(league.Data);

            //league = new Tournament(players, logic, 50);
            //league.Start();
            //display.ShowInfo(league.Data);
        }
    }
}