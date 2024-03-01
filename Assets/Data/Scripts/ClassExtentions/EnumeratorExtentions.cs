namespace True10.Extentions
{
    using System.Collections.Generic;

    public static class EnumeratorExtentions
    {
        public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        /*   public static T GetRandomElement<T>(this IEnumerable<T> list)
           {
               if (list.Count == 0)
               {
                   return default(T);
               }
               int randomIndex = Random.Range(0, list.Count);

               return list[randomIndex];
           }*/
    }
}
