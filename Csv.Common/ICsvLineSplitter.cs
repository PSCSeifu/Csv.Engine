using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvLineSplitter
    {
       IEnumerable<string> CsvSplit(string source, bool stripQuotes, bool trim, char separator, char quote);
    }
}
