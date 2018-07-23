using System;

namespace Logic.Task2
{
    public class IntContain : IContain<int>
    {
        /// <summary>
        /// This method checks if checkValue in value.
        /// </summary>
        /// <param name="value"> Number for checking </param>
        /// <param name="checkValue"> Numeral </param>
        /// <returns> If value contain checkValue return true, else - false </returns>
        public bool IsContain(int value, int checkValue)
        {
            value = Math.Abs(value);

            int wholePart = value / 10,
                modulo = value % 10;

            bool result = false;

            do
            {
                if ((modulo == checkValue) || (wholePart == checkValue))
                {
                    result = true;
                }
                else
                {
                    if (wholePart != 0)
                    {
                        modulo = wholePart % 10;

                        wholePart /= 10;
                    }
                }
            }
            while ((!result) && (wholePart != 0));

            return result;
        }
    }
}
