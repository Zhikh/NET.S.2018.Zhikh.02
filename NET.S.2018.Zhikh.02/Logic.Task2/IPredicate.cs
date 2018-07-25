namespace Logic.Task2
{
    public interface IPredicate<in T>
    {
        /// <summary>
        /// Check execution of special rules
        /// </summary>
        /// <param name="value"> Value for checking </param>
        /// <returns> If rules are executed, it will be true, else - false </returns>
        bool IsMatch(T value);
    }
}
