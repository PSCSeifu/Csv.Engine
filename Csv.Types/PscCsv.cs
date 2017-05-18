using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class PscCsv
    {
        public CsvHeader Headers { get; set; }
        public CsvLines  Data { get; set; }
        public CsvFooter Footer { get; set; }
        public CsvError Errors { get; set; }
        public int LineCount { get; set; }
        public char Separator { get; set; }
        public char Quote { get; set; }
        public bool IsQuoted { get; set; }
        public bool HasSeparator { get; set; }

        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }
    }
}
