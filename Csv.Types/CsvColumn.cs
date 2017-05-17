using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvColumn
    {
        public CsvHeaderItem Header { get; set; }
        public List<CsvLineItem> Lines { get; set; }
        public CsvError MyProperty { get; set; }
        public int LineCount { get; set; }
    }
}
