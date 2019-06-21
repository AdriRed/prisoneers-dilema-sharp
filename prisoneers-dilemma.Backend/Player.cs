using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public abstract class Player
    {
        public enum Selection
        {
            Yes,
            No
        };

        private string _name;
        private float _money;

        public Selection Cooperate
        {
            get; set;
        }


        public Player (float money, string name)
        {
            Money = money;
            Name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public float Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public abstract void NewMove();
    }
}
