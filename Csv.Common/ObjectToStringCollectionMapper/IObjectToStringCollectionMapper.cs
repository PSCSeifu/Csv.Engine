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
        List<string> GetCsvHeaderFields<T>();             

        List<string> CsvDecompose<T>(T sourceObject);
        List<string> CsvDecompose<T>(T sourceObject, List<CsvHeaderItem> requiredheaderItems);
        List<string> CsvDecompose<T>(T sourceObject, List<string> requiredFields);
    }
}
