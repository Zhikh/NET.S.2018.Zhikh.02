using System;
using System.Collections;

namespace Logic.Task1
{
    /// <summary>
    /// This class works with bit representations of the received values.
    /// </summary>
    public static class BitWorker
    {
        private static readonly int MaxSize = 32;
        private static readonly int DefaultValue = 0;

        #region Public Methods
        /// <summary>
        /// This method inserts bits from two values in new value by indexes.
        /// </summary>
        /// <param name="firstElement"> First value </param>
        /// <param name="secondElement"> Second value </param>
        /// <param name="i"> Left index </param>
        /// <param name="j"> Right index </param>
        /// <returns> New value was created on first and second values base </returns>
        public static int Insert(int firstElement, int secondElement, int i, int j)
        {
            if ((firstElement == 0) && (secondElement == 0))
            {
                return DefaultValue;
            }

            Mix(ref firstElement, secondElement, i, j);

            return firstElement;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method mixes bits from two integer values.
        /// </summary>
        /// <param name="firstElement"> First value </param>
        /// <param name="secondElement"> Second value </param>
        /// <param name="i"> Left index </param>
        /// <param name="j"> Right index </param>
        /// <param name="bitArray"> Array of bits </param>
        /// <exception cref="ArgumentOutOfRangeException"> Sends when j more than MaxSize of integer or when i less than 0</exception>
        /// <exception cref="ArgumentException"> Sends when i more than j </exception>
        private static void Mix(ref int firstElement, int secondElement, int i, int j)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("Argument i can't be less than 0!");
            }

            if (j > MaxSize)
            {
                throw new ArgumentOutOfRangeException("Argument j can't be more than max size of type in bits!");
            }

            if (i > j)
            {
                throw new ArgumentException("Argument i can't be more than argument j!");
            }

            for (int k = 0; k < 32; ++k)
            {
                if ((k >= i) && (k <= j))
                {
                    firstElement |= ((secondElement >> (k - i)) & 1) << k;
                }
            }
        }
        #endregion
    }
}
