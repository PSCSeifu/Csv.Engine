using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface IObjectToStringCollectionMapper
    {
        IEnumerable<CsvHeader> GetCsvHeader<T>();
        IEnumerable<string> CsvDecompose<T>(T sourceObject, IEnumerable<CsvHeader> csvHeader);        
    }
}
