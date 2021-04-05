using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Medex.Service.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determine whether a type is simple (String, Decimal, DateTime, etc) 
        /// or complex (i.e. custom class with public properties and methods).
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/2442534/how-to-test-if-type-is-primitive"/>
        public static bool IsSimpleType(this Type type)
        {
            return
               type.IsValueType ||
               type.IsPrimitive ||
               new[]
               {
               typeof(String),
               typeof(Decimal),
               typeof(DateTime),
               typeof(DateTimeOffset),
               typeof(TimeSpan),
               typeof(Guid)
               }.Contains(type) ||
               (Convert.GetTypeCode(type) != TypeCode.Object);
        }

        public static Type GetUnderlyingType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Event:
                    return ((EventInfo)member).EventHandlerType;
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Method:
                    return ((MethodInfo)member).ReturnType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    throw new ArgumentException
                    (
                       "Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo"
                    );
            }
        }
    }

    public static class CompareExtension
    {
        public static IList<string> GetDiffProperties<T>(this T self, T to, params string[] ignore) where T : class
        {
            var result = new List<string>();
            if (self == null || to == null)
                return result;

            var type = typeof(T);
            var ignoreList = ignore != null
                ? new List<string>(ignore)
                : new List<string>();

            foreach (var pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (ignoreList.Contains(pi.Name))
                    continue;

                var propertyName = pi.Name;
                var selfValue = type.GetProperty(propertyName)?.GetValue(self, null);
                var toValue = type.GetProperty(propertyName)?.GetValue(to, null);

                if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                    result.Add(propertyName);
            }
            return result;
        }
    }
}
