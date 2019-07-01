namespace prisoneers_dilema.Backend
{
    public class Logic
    {
        protected float[][] player1rewards, player2rewards;

        protected virtual float[][] Player1Distribution
        {
            get
            {
                return player1rewards;
            }
        }

        protected virtual float[][] Player2Distribution
        {
            get
            {
                return player2rewards;
            }
        }

        public virtual void Decide(Player player1, Player player2)
        {
            float[] rewards = Rewards(player1.Cooperate, player2.Cooperate);

            player1.Money += rewards[0];
            player2.Money += rewards[1];
        }

        public virtual float[] Rewards(Player.Selection player1, Player.Selection player2)
        {
            float[] rewards = new float[2] {
                Player1Distribution[ (int) player1 ][ (int) player2 ],
                Player2Distribution[ (int) player1 ][ (int) player2 ]
            };

            return rewards;
        }

        public Logic(float[][] p1Rewards, float[][] p2Rewards)
        {
            player1rewards = p1Rewards;
            player2rewards = p2Rewards;
        }
    }
}
