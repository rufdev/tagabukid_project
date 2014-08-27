using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIShell.OSGi.MvcCore
{
    public interface IInjectionService
    {
        object Resolve(Type type);
        TService InjectProperties<TService>(TService instance);
    }
}
