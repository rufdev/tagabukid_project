using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Personnel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }

    }
}
