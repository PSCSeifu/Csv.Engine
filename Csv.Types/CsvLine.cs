using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvLineItem
    {
        public string Line { get; set; }
        public int RowNo { get; set; }
        public string RowTerminator { get; set; }

        public CsvLineItem(string line, int rowno, string rowTerminator)
        {
            this.Line = line;
            this.RowNo = rowno;
            this.RowTerminator = rowTerminator;
        }
    }

    public class CsvLines
    {
        public List<CsvLineItem> Lines { get; set; }
    }
}
