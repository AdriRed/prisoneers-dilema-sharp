namespace prisoneers_dilema.Backend.Logics
{
    public class DefaultLogic : Logic
    {
        /*
        *                      P2         P2
        *  -------------------------------------
        *      |  (P1,P2) |   No    |    Yes   |
        *  -------------------------------------
        *  P1  |    No    | (-1, -1)| (-5, 5)  |      
        *  -------------------------------------
        *  P1  |    Yes   | (5, -5) |  (3, 3)  |
        *  -------------------------------------
        *  
        */

        private static readonly float[][] p1Rewards = new float[2][] {
                                                                new float[2]{-1f, -5f},
                                                                new float[2]{5f, 3f}
                                                            };

        private static readonly float[][] p2Rewards = new float[2][] {
                                                                new float[2]{-1f, 5f},
                                                                new float[2]{-5f, 3f}
                                                            };

        public DefaultLogic() :
            base(p1Rewards, p2Rewards)
        {

        }
    }
}
