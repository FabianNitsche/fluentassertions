using System.Collections;
using System.Linq;

namespace FluentAssertions.Equivalency
{
    public class EnumerableWrapper
    {
        private readonly IEnumerable values;

        public EnumerableWrapper(IEnumerable values)
        {
            this.values = values;
        }

        public object[] GetValues() => values.OfType<object>().ToArray();
    }
}
