namespace prisoneers_dilema.Backend.Logics
{
    public class Chicken : Logic
    {
        /*
        *                      P2         P2
        *  -------------------------------------
        *      |  (P1,P2) |   No    |    Yes   |
        *  -------------------------------------
        *  P1  |    No    | (5, 5)  | (1, 10)  |      
        *  -------------------------------------
        *  P1  |    Yes   | (10, 1) |(-20, -20)|
        *  -------------------------------------
        *  
        */


        private static readonly float[][] p1Rewards = new float[2][] {
                                                                new float[2]{5f, 1f},
                                                                new float[2]{10f, -20f}
                                                            };

        private static readonly float[][] p2Rewards = new float[2][] {
                                                                new float[2]{5f, 10f},
                                                                new float[2]{1f, -20f}
                                                            };

        public Chicken() : base(p1Rewards, p2Rewards)
        {

        }




    }
}
