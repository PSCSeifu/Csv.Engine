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
        T CsvCompose<T>(List<string> source);
        T CsvCompose<T>(List<string> source, List<string> requiredFields);

        CsvHeader CsvHeaderCompose<T>(IEnumerable<string> requiredFieldNames);
        CsvHeaderItem CsvHeaderItem(string fieldName, Type dataType, string defaultValue = "", bool forcedDefault = false, bool allowNull = true, int orderNo = 0, int maxSize = 0, int minSize = 0);

        CsvColumn CsvColumnCompose(IEnumerable<string> source, CsvHeaderItem csvHeaderItem);
        CsvColumn CsvColumnCompose(IEnumerable<string> source, Type columnType);
        CsvColumn CreateCsvColumn<T>(IEnumerable<string> dataItems, string fieldName);
               

        CsvFooter CsvFooterCompose(IEnumerable<string> footerItems);
    }
}
