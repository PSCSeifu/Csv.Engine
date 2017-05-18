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
                //Get the header line here
                if (moreItems)
                {
                    pscCsv.Headers.RawHeaderLine = enumerator.Current;
                }

                int count = 0;
                while (moreItems)
                {
                    count++;
                    string stringLine = enumerator.Current;
                    //Do stuff
                    pscCsv.Data.Lines.Add(new CsvLineItem(stringLine,count,""));
                    moreItems = enumerator.MoveNext();
                }
                //Take last line and add to csv footer...
            }

            return pscCsv;
        }

        public PscCsv ProcessCsv<T>(PscCsv pscCsv /*Ilogger ?*/)
        {
            //Set CSvHeader items from raw header line - Add errors

            //Set footer items from last line items, remove last line - add errors

            //Set line items to the T type container  - add errors

            return pscCsv;
        }
    }
}
