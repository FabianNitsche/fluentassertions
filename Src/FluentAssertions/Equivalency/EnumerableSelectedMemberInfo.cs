using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
    /// <summary>
    /// Provides an ISelectedMemberInfo for PropertyInfo objects
    /// </summary>
    internal class EnumerableSelectedMemberInfo : SelectedMemberInfo
    {
        private readonly Type enumerableInterface;

        public EnumerableSelectedMemberInfo(Type enumerableInterface, Type declaringType)
        {
            DeclaringType = declaringType;
            this.enumerableInterface = enumerableInterface;
        }

        public override string Name => enumerableInterface.GetFriendlyName();

        public override Type MemberType => typeof(EnumerableWrapper);

        public override Type DeclaringType { get; }

        internal override CSharpAccessModifier GetGetAccessModifier() => enumerableInterface.GetCSharpAccessModifier();

        internal override CSharpAccessModifier GetSetAccessModifier() => CSharpAccessModifier.InvalidForCSharp;

        public override object GetValue(object obj, object[] index)
        {
            if (index?.Any() == true)
            {
                throw new TargetParameterCountException("Parameter count mismatch.");
            }

            return new EnumerableWrapper((IEnumerable)obj);
        }
    }
}
