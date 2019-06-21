using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public interface IDisplay
    {
        void ShowInfo(GameData game, bool writeline);
        void ShowInfo(RoundData round, bool writeline);
        void ShowInfo(LeagueData league);
    }
}
