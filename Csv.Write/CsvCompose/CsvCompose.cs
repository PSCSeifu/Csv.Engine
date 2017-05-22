using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types;

namespace Csv.Write.CsvCompose
{
    public class CsvCompose : ICsvCompose
    {
        #region " PscCsv "
        
        public PscCsv ComposeCsv(CsvHeader csvHeader, CsvLines CsvLines, CsvFooter csvFooter)
        {
            throw new NotImplementedException();
        }

        public PscCsv ComposeCsv(CsvColumn csvColumn, CsvFooter csvFooter)
        {
            throw new NotImplementedException();
        }

        public PscCsv ComposeCsv(CsvColumn csvColumn)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "  Csv Column" 

        public CsvColumn CreateCsvColumn<T>(IEnumerable<string> dataItems, string fieldName)
        {
            throw new NotImplementedException();
        }

        public CsvColumn CreateCsvColumn<T>(IEnumerable<T> objectItems, string fieldName)
        {
            throw new NotImplementedException();
        }

        public CsvColumn CreateCsvColumn<T>(IEnumerable<T> objectItems, CsvHeaderItem headerItem)
        {
            throw new NotImplementedException();
        }

        public List<CsvColumn> CreateCsvColumns<T>(IEnumerable<T> objectItems, List<string> requiredfields)
        {
            throw new NotImplementedException();
        }

        public List<CsvColumn> CreateCsvColumns<T>(IEnumerable<T> objectItems, List<CsvHeaderItem> requiredHeaderItems)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region " Csv Footer"

        public CsvFooter CreateCsvFooter()
        {
            throw new NotImplementedException();
        }

        public CsvFooter CreateCsvFooter(string footerString)
        {
            throw new NotImplementedException();
        }

        public CsvFooter CreateCsvFooter(string footerString, int count)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "  Csv Error"

        public CsvErrorItem CreateErrorItem<T>(T objectItem)
        {
            throw new NotImplementedException();
        }

        public CsvError CreateErrors<T>(IEnumerable<CsvErrorItem> errorItems)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region " Csv header "

        public CsvHeader CreateHeader<T>()
        {
            throw new NotImplementedException();
        }

        public CsvHeader CreateHeader<T>(T objectItem)
        {
            throw new NotImplementedException();
        }

        public CsvHeader CreateHeader<T>(IEnumerable<string> requiredFields)
        {
            throw new NotImplementedException();
        }

        public CsvHeader CreateHeader<T>(IEnumerable<CsvHeaderItem> requiredheaderItems)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region " Csv Lines"


        public CsvLines ExtractCsvData<T>(IEnumerable<T> objectItems)
        {
            throw new NotImplementedException();
        }

        public CsvLines ExtractCsvData<T>(IEnumerable<T> objectItems, int rowNo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
