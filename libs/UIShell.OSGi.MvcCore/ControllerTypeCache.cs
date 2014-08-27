using System;
using System.Collections.Concurrent;
using UIShell.OSGi.Collection;

namespace UIShell.OSGi.MvcCore
{
    public static class ControllerTypeCache
    {
        private static readonly ConcurrentDictionary<string, Type> ControllerTypes = new ConcurrentDictionary<string, Type>();

        private static string GetKey(string plugin, string controllerName)
        {
            return string.Format("{0}$:$:${1}", plugin, controllerName);
        }

        public static void AddControllerType(string plugin, string controllerName, Type controllerType)
        {
                ControllerTypes.AddOrUpdate(GetKey(plugin, controllerName), key => controllerType,
                    (key, existing) => controllerType);
        }
        public static Type GetControllerType(string plugin, string controllerName)
        {
            Type result;
            ControllerTypes.TryGetValue(GetKey(plugin, controllerName), out result);
            return result;
        }
    }
}