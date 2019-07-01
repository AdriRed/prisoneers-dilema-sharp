namespace prisoneers_dilema.Backend.Logics
{
    public class FriendEnemy : Logic
    {

        /*
         *                      P2         P2
         *  -------------------------------------
         *      |  (P1,P2) |   No    |    Yes   |
         *  -------------------------------------
         *  P1  |    No    |  (1, 1) |  (0, 2)  |      
         *  -------------------------------------
         *  P1  |    Yes   |  (2, 0) |  (0, 0)  |
         *  -------------------------------------
         *  
         */


        private static readonly float[][] p1Rewards = new float[2][] {
                                                                new float[2]{1f, 0f},
                                                                new float[2]{2f, 0f}
                                                            };

        private static readonly float[][] p2Rewards = new float[2][] {
                                                                new float[2]{1f, 2f},
                                                                new float[2]{0f, 0f}
                                                            };

        public FriendEnemy() : base(p1Rewards, p2Rewards)
        {

        }

    }
}
