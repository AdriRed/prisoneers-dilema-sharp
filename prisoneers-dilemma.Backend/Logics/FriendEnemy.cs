using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Logics
{
    public class FriendEnemy : DefaultLogic
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

        protected override float[][] Player1Distribution
        {
            get
            {
                return new float[2][]
                    {
                        new float[2]{1f, 0f},
                        new float[2]{2f, 0f}
                    };
            }
        }

        protected override float[][] Player2Distribution
        {
            get
            {
                return new float[2][]
                    {
                        new float[2]{1f, 2f},
                        new float[2]{0f, 0f}
                    };
            }
        }
    }
}
