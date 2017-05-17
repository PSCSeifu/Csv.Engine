using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class PscCsv
    {
        public IEnumerable<CsvHeader> Headers { get; set; }
        public IEnumerable<string>  Lines { get; set; }
        public CsvFooter Footer { get; set; }
        public IEnumerable<CsvError> Errors { get; set; }
        public int LineCount { get; set; }
        public char Separator { get; set; }
        public char Quote { get; set; }
    }
}
