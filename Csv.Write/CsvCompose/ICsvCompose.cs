using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Write.CsvCompose
{
    public interface ICsvCompose
    {
        CsvHeader CreateHeader<T>();
        CsvHeader CreateHeader<T>(T objectItem);
        CsvHeader CreateHeader<T>(IEnumerable<string> requiredFields);
        CsvHeader CreateHeader<T>(IEnumerable<CsvHeaderItem> requiredheaderItems);

        CsvLines ExtractCsvData<T>(IEnumerable<T> objectItems);
        CsvLines ExtractCsvData<T>(IEnumerable<T> objectItems,int rowNo);

        CsvFooter CreateCsvFooter();
        CsvFooter CreateCsvFooter(string footerString);
        CsvFooter CreateCsvFooter(string footerString, int count);

        CsvErrorItem CreateErrorItem<T>(T objectItem);
        CsvError CreateErrors<T>(IEnumerable<CsvErrorItem> errorItems);

        CsvColumn CreateCsvColumn<T>(IEnumerable<string> dataItems, string fieldName);
        CsvColumn CreateCsvColumn<T>(IEnumerable<T> objectItems, string fieldName);
        CsvColumn CreateCsvColumn<T>(IEnumerable<T> objectItems, CsvHeaderItem headerItem);


        List<CsvColumn> CreateCsvColumns<T>(IEnumerable<T> objectItems, List<string> requiredfields);
        List<CsvColumn> CreateCsvColumns<T>(IEnumerable<T> objectItems, List<CsvHeaderItem> requiredHeaderItems);
        
        PscCsv ComposeCsv(CsvHeader csvHeader, CsvLines CsvLines, CsvFooter csvFooter);
        PscCsv ComposeCsv(CsvColumn csvColumn, CsvFooter csvFooter);
        PscCsv ComposeCsv(CsvColumn csvColumn);
    }
}
