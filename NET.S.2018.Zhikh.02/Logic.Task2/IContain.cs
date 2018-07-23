namespace Logic.Task2
{
    public interface IContain<in T>
    {
        bool IsContain(T element, T value);
    }
}
