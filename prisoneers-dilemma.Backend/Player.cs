using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend
{
    public abstract class Player
    {
        public static int PlayerCount;

        public int InGamePlayer;

        public enum Selection
        {
            Yes,    //0
            No      //1
        };

        private float _money;

        public PlayerData Data { get; private set; }

        public Selection Cooperate
        {
            get; set;
        }

        static Player ()
        {
            PlayerCount = 0;
        }

        public Player (float money, string name = "Default Player")
        {
            Money = money;
            Data = new PlayerData(PlayerCount, name);
            PlayerCount++;
        }

        public float Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public abstract void NewMove();
    }

    public struct PlayerData
    {
        public int Id;
        public string Name;

        public PlayerData(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            bool isEquals = false;

            if (obj is PlayerData otherData)
            {
                isEquals = Id == otherData.Id;
            }

            return isEquals;
        }
    }

}
