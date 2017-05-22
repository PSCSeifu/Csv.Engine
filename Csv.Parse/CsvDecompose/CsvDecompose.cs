using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types;

namespace Csv.Parse.CsvDecompose
{
    public class CsvDecompose : ICsvDecompose
    {
        public CsvColumn GetCsvColumn(PscCsv pscCsv, int fieldName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CsvColumn> GetCsvColumns(PscCsv pscCsv, IEnumerable<string> feildNames)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CsvColumn> GetCsvColumns(PscCsv pscCsv, IEnumerable<CsvHeaderItem> HeaderItems)
        {
            throw new NotImplementedException();
        }

        public string GetCsvElement(CsvLineItem csvLineItem, string fieldName)
        {
            throw new NotImplementedException();
        }

        public string GetCsvElement(CsvLineItem csvLineItem, int index)
        {
            throw new NotImplementedException();
        }

        public CsvError GetCsvError(PscCsv pscCsv)
        {
            throw new NotImplementedException();
        }

        public CsvFooter GetCsvFooter(PscCsv pscCsv)
        {
            throw new NotImplementedException();
        }

        public CsvLineItem GetCsvLine(PscCsv pscCsv, int rowNo)
        {
            throw new NotImplementedException();
        }

        public CsvLines GetCsvLines(PscCsv pscCsv, int startRow, int endRow)
        {
            throw new NotImplementedException();
        }

        public CsvLines GetCsvLines(PscCsv pscCsv)
        {
            throw new NotImplementedException();
        }

        public CsvErrorItem GetErrorItem(PscCsv pscCsv, int rowNo)
        {
            throw new NotImplementedException();
        }

        public CsvHeader GetHeader(PscCsv pscCsv)
        {
            throw new NotImplementedException();
        }

        public CsvHeaderItem GetHeaderItem(PscCsv pscCsv, string fieldName)
        {
            throw new NotImplementedException();
        }

        public CsvHeaderItem GetHeaderItem(PscCsv pscCsv, int index)
        {
            throw new NotImplementedException();
        }
    }
}
