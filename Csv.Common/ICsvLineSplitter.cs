using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvLineSplitter
    {
        IEnumerable<string> CsvSplit(string source, bool stripQuotes, bool trimSource, char separator, char quote);
        IEnumerable<string> CsvSplit(string source, bool stripQuotes, char separator, char quote);
        IEnumerable<string> CsvSplit(string source, char separator, char quote);
        IEnumerable<string> CsvSplit(string source, char separator);
        IEnumerable<string> CsvSplit(string source);
    }
}
