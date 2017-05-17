using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvError
    {
        public string Message { get; set; }
        public CsvErrorType ErrorType { get; set; }
        public int RowNo { get; set; }
        public string ErrorRow { get; set; }

        public enum CsvErrorType
        {
            Unknown,
            IsNull,
            InCorrectData,
            HeaderMismatch
        }
    }
}
