using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvLineMaker
    {
        string MakeCsvLine(IEnumerable<string> sourceList, bool addQuotes, bool trim, char separator, char quote);
    }
}
