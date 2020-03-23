using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
    /// <summary>
    /// Provides an ISelectedMemberInfo for Enumerable objects
    /// </summary>
    internal class EnumerableSelectedMemberInfo : SelectedMemberInfo
    {

        private readonly MethodInfo getEnumerator;

        public EnumerableSelectedMemberInfo(Type enumerableInterface, Type declaringType)
        {
            DeclaringType = declaringType;
            this.getEnumerator = enumerableInterface.GetMethod(nameof(IEnumerable.GetEnumerator));
        }

        public override string Name => getEnumerator.DeclaringType.GetFriendlyName();

        public override Type MemberType => typeof(EnumerableWrapper);

        public override Type DeclaringType { get; }

        internal override CSharpAccessModifier GetGetAccessModifier() => getEnumerator.GetCSharpAccessModifier();

        internal override CSharpAccessModifier GetSetAccessModifier() => CSharpAccessModifier.InvalidForCSharp;

        public override object GetValue(object obj, object[] index)
        {
            if (index?.Any() == true)
            {
                throw new TargetParameterCountException("Parameter count mismatch.");
            }

            var enumerator = (IEnumerator)getEnumerator.Invoke(obj, new object[0]);

            return new EnumerableWrapper(enumerator);
        }
    }
}
