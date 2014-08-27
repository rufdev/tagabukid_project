using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Web.Mvc;

namespace UIShell.OSGi.MvcCore
{
    /// <summary>
    /// The default controller source, this is used when the page locates in a non plugin folder.
    /// </summary>
    public class DefaultControllerConfig
    {
        public static HashSet<string> DefaultNamespaces = new HashSet<string>();

        public static void Register(Assembly assembly)
        {
            foreach (var type in assembly.GetExportedTypes())
            {
                if (!type.IsAbstract && typeof (IController).IsAssignableFrom(type) )
                {
                    if (type.Namespace != null)
                    {
                        DefaultNamespaces.Add(type.Namespace);
                    }
                }
            }
        }

        public static void Register(params string[] namespaces)
        {
            DefaultNamespaces.UnionWith(namespaces);
        }
    }
}
