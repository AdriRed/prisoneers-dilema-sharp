using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public interface IPlayer
    {
        bool Decision { get; }
        void GetNewDecision();
    }
}
