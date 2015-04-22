using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mustache.Net35
{
    static class Enumerable35
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            if (resultSelector == null)
            {
                throw new ArgumentNullException("resultSelector");
            }
            return Enumerable35.ZipIterator<TFirst, TSecond, TResult>(first, second, resultSelector);
        }

        private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (IEnumerator<TFirst> enumerator = first.GetEnumerator())
            {
                using (IEnumerator<TSecond> enumerator1 = second.GetEnumerator())
                {
                    while (enumerator.MoveNext() && enumerator1.MoveNext())
                    {
                        yield return resultSelector(enumerator.Current, enumerator1.Current);
                    }
                }
            }
        }
    }
}
