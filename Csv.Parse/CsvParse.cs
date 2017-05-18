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

        public PscCsv ParseCsv<T>(IEnumerable<string> source)
        {
            PscCsv pscCsv = new PscCsv();
            if (source == null || source.Count() <= 0)
            {
                //Anti-pattern, new key work, refactor to an interface 
                var error = new CsvErrorItem();
                error.Message = "Input string collection is null or empty";
                pscCsv.Errors.Error.Add(error);
            }

            using (IEnumerator<string> enumerator = source.GetEnumerator())
            {
                bool moreItems = enumerator.MoveNext();
                while (moreItems)
                {
                    string stringLine = enumerator.Current;
                    //Do stuff
                    //pscCsv.Line
                    moreItems = enumerator.MoveNext();
                }
            }

            return pscCsv;
        }
    }
}
