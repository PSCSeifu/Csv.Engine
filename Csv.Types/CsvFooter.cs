using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvFooter // : ICsvComponent
    {
        public string Eof { get; set; } = "EOF";
        public int DataLineCount { get; set; }
        public DateTime TimeStamp { get; set; }

        //public CsvFooter()
        //{

        //}

        //public CsvFooter Read<CsvFooter>(string line, char separator, char quote)
        //{
        //    CsvFooter footer = new 
        //    var eofString =  CsvLinesplit.CsvSplit(line, separator, quote);

        //}

        //public string Write(char separator, char quote)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
