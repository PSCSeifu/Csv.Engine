using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvLineItem
    {
        public List<string> Line { get; set; }
        public int RowNo { get; set; }
        public string RowTerminator { get; set; }
    }

    public class CsvLine
    {
        public List<CsvLineItem> Line { get; set; }
    }
}
