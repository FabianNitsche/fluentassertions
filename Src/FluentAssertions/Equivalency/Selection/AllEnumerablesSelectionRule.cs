using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.Equivalency.Selection
{
    /// <summary>
    /// Selection rule that adds all enumerable interfaces of the expectation.
    /// </summary>
    internal class AllEnumerablesSelectionRule : IMemberSelectionRule
    {
        public bool IncludesMembers => false;

        public IEnumerable<SelectedMemberInfo> SelectMembers(IEnumerable<SelectedMemberInfo> selectedMembers, IMemberInfo context, IEquivalencyAssertionOptions config)
        {
            IEnumerable<SelectedMemberInfo> enumerableInterfaceInfos = SelectedMemberInfo.CreateForAllEnumerables(config.GetExpectationType(context));

            return selectedMembers.Union(enumerableInterfaceInfos);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "Include all enumerables";
        }
    }
}
