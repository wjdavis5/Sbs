using System;
using System.Collections.Generic;
using System.Text;

namespace SbsLib
{
    public static class BoardSettings
    {
        #region Statics

        public static readonly Random Random = new Random();
        public static readonly short[] PossibleNumbers = new short[]{0,1,2,3,4,5,6,7,8,9};

        #endregion

        static BoardSettings()
        {
            WarmUpRandom(Random.Next(100, 5000));
        }
        private static void WarmUpRandom(int numGenerations)
        {
            for (int i = 0; i < numGenerations; i++)
            {
                BoardSettings.Random.Next();
            }
        }
    }
}
