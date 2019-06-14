using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    class Round
    {
        private IPlayer _player1;
        private IPlayer _player2;

        public IPlayer Player2
        {
            get { return _player2; }
            set { _player2 = value; }
        }
        public IPlayer Player1
        {
            get { return _player1; }
            set { _player1 = value; }
        }

        /*
         * All info.
         * Last money, difference, option, etc...
         * 
         */



    }
}
