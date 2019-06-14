using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public interface ILogic
    {
        ILogic Player1 { get; }
        ILogic Player2 { get; }
        double[,] Distribution { get; }
        void Result();
    }
}
