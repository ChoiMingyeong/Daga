using DagaBlazorLibrary.Attributes;
using System.Collections.Concurrent;
using System.Reflection;

namespace DagaBlazorLibrary.Cache
{

    public static class MethodCache
    {
        private static readonly ConcurrentDictionary<Type, MethodInfo[]> _initializeMethodsCache = [];
        private static readonly ConcurrentDictionary<Type, MethodInfo[]> _asyncInitializeMethodsCache = [];
        private static readonly ConcurrentDictionary<Type, MethodInfo[]> _disposableMethodsCache = [];
        private static readonly ConcurrentDictionary<Type, MethodInfo[]> _asyncDisposableMethodsCache = [];

        public static async Task InitializeAsync(object obj)
        {
            var type = obj.GetType();
            var methods = GetAsyncInitializeMethods(type);
            foreach (var method in methods)
            {
                if (method.Invoke(obj, null) is Task task)
                {
                    await task;
                }
            }
        }

        public static void Initialize(object obj)
        {
            var type = obj.GetType();
            var methods = GetInitializeMethods(type);
            foreach (var method in methods)
            {
                method.Invoke(obj, null);
            }
        }

        public static async ValueTask DisposeAsync(object obj)
        {
            var type = obj.GetType();
            var methods = GetAsyncDisposableMethods(type);
            foreach (var method in methods)
            {
                if (method.Invoke(obj, null) is ValueTask valueTask)
                {
                    await valueTask;
                }
            }
        }

        public static void Dispose(object obj)
        {
            var type = obj.GetType();
            var methods = GetDisposableMethods(type);
            foreach (var method in methods)
            {
                method.Invoke(obj, null);
            }
        }

        private static MethodInfo[] GetInitializeMethods(Type type)
        {
            if (!_initializeMethodsCache.TryGetValue(type, out var methods))
            {
                methods = [.. type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Where(m => m.GetCustomAttribute<InitializeAttribute>() != null
                                && m.GetParameters().Length == 0
                                && m.ReturnType == typeof(void))];
                _initializeMethodsCache[type] = methods;
            }
            return methods;
        }

        private static MethodInfo[] GetAsyncInitializeMethods(Type type)
        {
            if (!_asyncInitializeMethodsCache.TryGetValue(type, out var methods))
            {
                methods = [.. type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Where(m => m.GetCustomAttribute<AsyncInitializeAttribute>() != null
                                && typeof(Task).IsAssignableFrom(m.ReturnType)
                                && m.GetParameters().Length == 0)];
                _asyncInitializeMethodsCache[type] = methods;
            }
            return methods;
        }

        private static MethodInfo[] GetDisposableMethods(Type type)
        {
            if (!_disposableMethodsCache.TryGetValue(type, out var methods))
            {
                methods = [.. type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Where(m => m.GetCustomAttribute<DisposableAttribute>() != null
                                && m.GetParameters().Length == 0
                                && m.ReturnType == typeof(void))];
                _disposableMethodsCache[type] = methods;
            }
            return methods;
        }
        
        private static MethodInfo[] GetAsyncDisposableMethods(Type type)
        {
            if (!_asyncDisposableMethodsCache.TryGetValue(type, out var methods))
            {
                methods = [.. type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Where(m => m.GetCustomAttribute<AsyncDisposableAttribute>() != null
                                && typeof(ValueTask).IsAssignableFrom(m.ReturnType)
                                && m.GetParameters().Length == 0)];
                _asyncDisposableMethodsCache[type] = methods;
            }
            return methods;
        }
    }
}
