using System;
using System.Collections.Generic;
using System.Text;

namespace prisoneers_dilema.Backend.Logics
{
    public class Chicken : DefaultLogic
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

        protected override float[][] Player1Distribution
        {
            get
            {
                return new float[2][]
                    {
                        new float[2]{5f, 1f},
                        new float[2]{10f, -20f}
                    };
            }
        }

        protected override float[][] Player2Distribution
        {
            get
            {
                return new float[2][]
                    {
                        new float[2]{5f, 10f},
                        new float[2]{1f, -20f}
                    };
            }
        }
    }
}
