namespace Logic.Task2
{
    public interface IPredicate<in T>
    {
        bool IsMatch(T value);
    }
}
