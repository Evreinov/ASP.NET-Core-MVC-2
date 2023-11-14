namespace WorkingWithVisualStudio.Tests
{
    public class Comparer
    {
        public static Comparer<T> Get<T>(Func<T, T, bool> func)
        {
            return new Comparer<T>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;

        public Comparer(Func<T, T, bool> func)
        {
            comparisonFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return comparisonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
