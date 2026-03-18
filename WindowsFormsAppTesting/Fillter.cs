using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppTesting
{
    public class Filter
    {
        public string Column { get; set; }          // Tên cột
        public string Operator { get; set; }        // =, >, <, LIKE, IN...
        public object Value { get; set; }           // Giá trị
        public string Logic { get; set; } = "AND";  // AND / OR
    }
}
