﻿namespace TaskManager.Core
{
    public static class ReflectionExtensions
    {
        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            var par = parent;
            return InheritsOrImplementsHalf(child, ref parent) || par.IsAssignableFrom(child);
        }

        private static bool InheritsOrImplementsHalf(Type child, ref Type parent)
        {
            parent = ResolveGenericTypeDefinition(parent);
            var currentChild = child.IsGenericType
                                   ? child.GetGenericTypeDefinition()
                                   : child;
            while (currentChild != typeof(Object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;
                currentChild = currentChild.BaseType != null
                               && currentChild.BaseType.IsGenericType
                                   ? currentChild.BaseType.GetGenericTypeDefinition()
                                   : currentChild.BaseType;
                if (currentChild == null)
                    return false;
            }
            return false;
        }

        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    var currentInterface = childInterface.IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;

                    return currentInterface == parent;
                });
        }

        private static Type ResolveGenericTypeDefinition(Type parent)
        {
            var shouldUseGenericType = !(parent.IsGenericType && parent.GetGenericTypeDefinition() != parent);
            if (parent.IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition();
            return parent;
        }
    }
}
