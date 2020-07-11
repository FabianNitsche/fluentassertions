using System.Collections;
using System.Linq;

namespace FluentAssertions.Equivalency
{
    public class EnumerableWrapper
    {
        public object[] Values { get; }

        public EnumerableWrapper(IEnumerator enumerator)
        {
            Values = Enumerate(enumerator).Cast<object>().ToArray();
        }

        private static IEnumerable Enumerate(IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}
