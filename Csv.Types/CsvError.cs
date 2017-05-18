using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvErrorItem
    {
        public string Message { get; set; }
        public CsvErrorType ErrorType { get; set; }
        public int RowNo { get; set; }
        public string ErrorRow { get; set; }
    }

    public class CsvError
    {
        public List<CsvErrorItem> Error { get; set; }
    }

        public enum CsvErrorType
    {
        Unknown,
        IsNull,
        InCorrectData,
        HeaderMismatch
    }
}
