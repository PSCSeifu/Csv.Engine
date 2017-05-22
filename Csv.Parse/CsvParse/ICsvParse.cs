using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Parse.CsvParse
{
    public interface ICsvParse
    {
        PscCsv ParseCsv<T>(IEnumerable<string> source);
    }
}
