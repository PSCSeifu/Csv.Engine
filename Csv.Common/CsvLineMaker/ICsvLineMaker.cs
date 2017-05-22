using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvLinesMaker
    {
        string MakeCsvLines(IEnumerable<string> source, bool addQuotes, bool trimItems, char separator, char quote, string lineTerminator);
        
        string MakeCsvLines(IEnumerable<string> source, bool addQuotes, bool trimItems, char separator, char quote);

        string MakeCsvLines(IEnumerable<string> source, bool addQuotes, char separator, char quote);

        string MakeCsvLines(IEnumerable<string> source, char separator, char quote);

        string MakeCsvLines(IEnumerable<string> source, char separator);

        string MakeCsvLines(IEnumerable<string> source);
    }
}
