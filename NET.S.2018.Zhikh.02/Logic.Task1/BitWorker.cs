using System;

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
        /// This method changes k-bit of first value to (k-i)-bit of second value.
        /// </summary>
        /// <param name="firstValue"> First value </param>
        /// <param name="secondValue"> Second value </param>
        /// <param name="i"> Index for replace (first value) </param>
        /// <param name="k"> Index for replace (second value: k-i) </param>
        /// <exception cref="ArgumentException"> Sends when i is more than k </exception>
        private static int BitReplace(int firstValue, int secondValue, int i, int k)
        {
            if (i > k)
            {
                throw new ArgumentException("Argument i can't be more than k!");
            }

            if ((firstValue.GetBit(k) & 1) == 1)
            {
                firstValue ^= 1 << k;
            }

            firstValue |= ((secondValue.GetBit(k - i)) & 1) << k;

            return firstValue;
        }

        /// <summary>
        /// This method mixes bits from two integer values.
        /// </summary>
        /// <param name="firstElement"> First value </param>
        /// <param name="secondElement"> Second value </param>
        /// <param name="i"> Left index </param>
        /// <param name="j"> Right index </param>
        /// <exception cref="ArgumentOutOfRangeException"> Sends when j is more than MaxSize of integer or when i is less than 0</exception>
        /// <exception cref="ArgumentException"> Sends when i more than j </exception>
        private static void Mix(ref int firstElement, int secondElement, int i, int j)
        {
            if (i < 0 || i > MaxSize)
            {
                throw new ArgumentOutOfRangeException("Argument i can't be less than 0!");
            }

            if (j > MaxSize || j < 0)
            {
                throw new ArgumentOutOfRangeException("Argument j can't be more than max size of type in bits!");
            }

            if (i > j)
            {
                throw new ArgumentException("Argument i can't be more than argument j!");
            }

            for (int k = 0; k < MaxSize; ++k)
            {
                if ((k >= i) && (k <= j))
                {
                    firstElement = BitReplace(firstElement, secondElement, i, k);
                }
            }
        }
        
        #region IntExtension
        /// <summary>
        /// This method return bit value by index.
        /// </summary>
        /// <param name="index"> Point on position of bit </param>
        /// <returns> Bit value </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Sends when index is less than 0 or more than MaxSize of integer</exception>
        private static int GetBit(this int value, int index)
        {
            if (0 < index || index < MaxSize)
            {
                throw new ArgumentOutOfRangeException("Argument index can't be less than 0 and more than max size of type in bits!");
            }

            return (value >> index);
        }
        #endregion
        #endregion
    }
}
