using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace UIShell.OSGi.MvcCore
{
    public static class Utility
    {
        public static string RedirectToBundlePath(string locationFormat, string bundleRelativePath)
        {
            return locationFormat.Replace("~", bundleRelativePath);
        }

        public static IEnumerable<string> RedirectToBundlePath(IEnumerable<string> locationFormats, string bundleRelativePath)
        {
            return locationFormats.Select(item => RedirectToBundlePath(item, bundleRelativePath));
        }

        public static string MapPathReverse(string fullServerPath)
        {
            return @"~\" + fullServerPath.Replace(HostingEnvironment.ApplicationPhysicalPath, String.Empty);
        }
    }
}
