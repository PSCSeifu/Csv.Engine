using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Parse.CsvDecompose
{
    public interface ICsvDecompose 
    {
        CsvHeader GetHeader(PscCsv pscCsv);
        CsvHeaderItem GetHeaderItem(PscCsv pscCsv, string fieldName);
        CsvHeaderItem GetHeaderItem(PscCsv pscCsv, int index);

        CsvLines GetCsvLines(PscCsv pscCsv);
        CsvLines GetCsvLines(PscCsv pscCsv,int startRow, int endRow);
        CsvLineItem GetCsvLine(PscCsv pscCsv, int rowNo);

        CsvFooter GetCsvFooter(PscCsv pscCsv);

        CsvError GetCsvError(PscCsv pscCsv);
        CsvErrorItem GetErrorItem(PscCsv pscCsv, int rowNo);

        CsvColumn GetCsvColumn(PscCsv pscCsv, int fieldName);
        IEnumerable<CsvColumn> GetCsvColumns(PscCsv pscCsv, IEnumerable<string> feildNames);
        IEnumerable<CsvColumn> GetCsvColumns(PscCsv pscCsv, IEnumerable<CsvHeaderItem> HeaderItems);

        string GetCsvElement(CsvLineItem csvLineItem, string fieldName);
        string GetCsvElement(CsvLineItem csvLineItem, int index);
    }
}
