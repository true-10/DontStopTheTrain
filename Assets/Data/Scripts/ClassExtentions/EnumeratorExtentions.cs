namespace True10.Extentions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumeratorExtentions
    {
        public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
        /// <summary>
        /// Returns random element from collection
        /// </summary>
        public static T GetRandomElement<T>(this IEnumerable<T> list)
        {
            if (list.Count() == 0)
            {
                return default(T);
            }
            int randomIndex = UnityEngine.Random.Range(0, list.Count());

            return list.ElementAt(randomIndex);
        }
    }
}
