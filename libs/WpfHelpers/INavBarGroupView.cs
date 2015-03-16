using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHelpers
{
    public interface INavBarGroupView
    {
        string GroupName { get; }
    }
    public interface INavBarItemView
    {
        string GroupName { get; }
    }
}
