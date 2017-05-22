using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvLineSplitter
    {
        List<string> CsvSplit(string source, bool stripQuotes, bool trimItems, char separator, char quote);
        List<string> CsvSplit(string source, bool stripQuotes, char separator, char quote);
        List<string> CsvSplit(string source, char separator, char quote);
        List<string> CsvSplit(string source, char separator);
        List<string> CsvSplit(string source);
    }
}
