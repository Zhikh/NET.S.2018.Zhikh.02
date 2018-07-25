using System;

namespace Logic.Task2
{
    public class StringPredicate : IPredicate<string>
    {
        private string _checkString;

        /// <summary>
        /// Initialize StringPredicate object
        /// </summary>
        /// <param name="checkValue"> Value for checking </param>
        public StringPredicate(string checkValue)
        {
            if (string.IsNullOrEmpty(checkValue))
            {
                throw new ArgumentException($"The {nameof(checkValue)} can't be null or empty!");
            }

            _checkString = checkValue;
        }

        /// <summary>
        /// Check the next: value is consist checkValue
        /// </summary>
        /// <param name="value"> Value for checking </param>
        /// <returns> If value has checkValue, it will be true, else - false </returns>
        public bool IsMatch(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"The {nameof(value)} can't be null or empty!");
            }

            return value.ToString().Contains(_checkString);
        }
    }
}
