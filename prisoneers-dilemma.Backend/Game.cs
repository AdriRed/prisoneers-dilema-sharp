using System;
using System.Collections.Generic;

namespace prisoneers_dilema.Backend
{
    public class Game
    {
        private ILogic _rules;
        protected IPlayer _player1;
        protected IPlayer _player2;
        protected List<Round> History;

        public Game(IPlayer player2, IPlayer player1, ILogic rules)
        {
            Player2 = player2;
            Player1 = player1;
            Rules = rules;
            History = new List<Dictionary<IPlayer, bool>>();
        }

        public IPlayer Player2
        {
            get { return _player2; }
            private set { _player2 = value; }
        }

        public IPlayer Player1
        {
            get { return _player1; }
            private set { _player1 = value; }
        }

        public ILogic Rules
        {
            get { return _rules; }
            private set { _rules = value; }
        }

        

    }
}
