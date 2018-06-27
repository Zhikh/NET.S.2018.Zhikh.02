using System;
using System.Collections;

namespace Logic.Task1
{
    public static class BitWorker
    {
        private static readonly int MaxSize = 32;
        private static readonly int DefaultValue = 0;

        #region Public Methods
        public static int Insert(int firstElement, int secondElement, int i, int j)
        {
            if ((firstElement == 0) && (secondElement == 0))
            {
                return DefaultValue;
            }

            var result = new BitArray(MaxSize);

            Mix(firstElement, secondElement, i, j, result);

            return GetIntFromBitArray(result);
        }   
        #endregion

        #region Private Methods
        private static int GetIntFromBitArray(BitArray bitArray)
        {
            if (bitArray.Length > MaxSize)
            {
                throw new ArgumentException("Argument length shall be at most 32 bits.");
            }

            int[] array = new int[1];

            bitArray.CopyTo(array, 0);

            return array[0];
        }

        private static void Mix(int firstElement, int secondElement, int i, int j, BitArray result)
        {
            if (i > j)
            {
                throw new ArgumentException("Argument i can't be more than argument j!");
            }

            if (j > MaxSize)
            {
                throw new ArgumentException("Argument j can't be more than max size of type in bits!");
            }

            for (int k = 0; k < 32; ++k)
            {
                if ((k >= i) && (k <= j))
                {
                    result.Set(k, Convert.ToBoolean((secondElement >> (k - i)) & 1));
                }
                else
                {
                    result.Set(k, Convert.ToBoolean((firstElement >> k) & 1));
                }
            }
        }
        #endregion
    }
}
