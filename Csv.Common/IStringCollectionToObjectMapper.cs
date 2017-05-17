using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface IStringCollectionToObjectMapper
    {
        T CsvCompose<T>(IEnumerable<string> source);
        IEnumerable<CsvHeader> CsvHeaderCompose(IEnumerable<string> source, IEnumerable<string> requiredFields);
        CsvFooter CsvFooterCompose(IEnumerable<string> source);
    }
}
