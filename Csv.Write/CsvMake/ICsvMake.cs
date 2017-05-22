using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.CsvMake.Write
{
    public interface ICsvMake
    {
        IEnumerable<string> MakeCsv(PscCsv pscCsv);
    }
}
