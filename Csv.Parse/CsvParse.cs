using Csv.Common;
using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Parse
{
    public interface ICsvParse
    {
        PscCsv ParseCsv<T>(IEnumerable<string> source);
    }

    public class CsvParse //: ICsvParse
    {
        private ICsvLineSplitter _csvLineSplitter;

        public  CsvParse(ICsvLineSplitter csvLineSplitter)
        {
            this._csvLineSplitter = csvLineSplitter;
        }

        //public PscCsv ParseCsv<T>(IEnumerable<string> source)
        //{
        //    PscCsv pscCsv = new PscCsv();
        //    if (source == null || source.Count() <= 0)
        //    {
        //        pscCsv.Errors.Add(new CsvError());
        //    }
        //}
    }
}
