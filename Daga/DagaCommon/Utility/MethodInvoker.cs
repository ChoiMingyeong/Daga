using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace DagaCommon.Utility
{
    public static class MethodInvoker
    {
        private static readonly ConcurrentDictionary<string, MethodInfo> _methodInfoCache = [];
        private static readonly ConcurrentDictionary<MethodInfo, Delegate> _methodCache = [];

        private static string Key<T>(string methodName, params Type[] parameterTypes) 
            => $"{typeof(T).FullName}.{methodName}({string.Join(",", parameterTypes.Select(t => t.FullName))})";

        public static Func<object, object?[]?, object?> GetMethodInvoker<T>(string methodName) 
            => (Func<object, object?[]?, object?>)_methodCache.GetOrAdd(GetCachedMethodInfo<T>(methodName), CreateMethodInvoker<T>);

        private static MethodInfo GetCachedMethodInfo<T>(string methodName)
        {
            if (_methodInfoCache.TryGetValue(Key<T>(methodName), out var methodInfo))
            {
                return methodInfo;
            }

            methodInfo = CreateCachedMethodInfo<T>(methodName);
            _methodInfoCache.TryAdd(Key<T>(methodName), methodInfo);
            return methodInfo;
        }

        private static MethodInfo CreateCachedMethodInfo<T>(string methodName)
        {
            var type = typeof(T);
            if (type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) 
                is not MethodInfo methodInfo)
            {
                throw new ArgumentException($"MethodName '{methodName}' not found on type '{type.FullName}'");
            }

            return methodInfo;
        }

        private static Delegate CreateMethodInvoker<T>(MethodInfo methodInfo)
        {
            var instanceParam = Expression.Parameter(typeof(object), "instance");
            var argsParam = Expression.Parameter(typeof(object[]), "args");

            var parameters = methodInfo.GetParameters();
            var arguments = new Expression[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var index = Expression.Constant(i);
                var argAccess = Expression.ArrayIndex(argsParam, index);
                var convertedArg = Expression.Convert(argAccess, parameters[i].ParameterType);
                arguments[i] = convertedArg;
            }

            var instanceCast = methodInfo.IsStatic
                ? null
                : Expression.Convert(instanceParam, methodInfo.DeclaringType!);

            Expression call;

            if (methodInfo.GetParameters().Length == 0)
            {
                // 매개변수 없는 경우
                call = methodInfo.IsStatic
                    ? Expression.Call(methodInfo)
                    : Expression.Call(instanceCast!, methodInfo);
            }
            else
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    var index = Expression.Constant(i);
                    var argAccess = Expression.ArrayIndex(argsParam, index);
                    var argCast = Expression.Convert(argAccess, parameters[i].ParameterType);
                    arguments[i] = argCast;
                }

                call = Expression.Call(instanceCast!, methodInfo, arguments);
            }

            Expression body = methodInfo.ReturnType == typeof(void)
                ? Expression.Block(call, Expression.Constant(null))
                : Expression.Convert(call, typeof(object));

            return Expression.Lambda<Func<object, object[], object?>>(body, instanceParam, argsParam).Compile();
        }
    }
}
