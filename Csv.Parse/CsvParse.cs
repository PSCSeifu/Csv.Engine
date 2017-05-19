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

        public PscCsv ProcessCsv<T>(PscCsv pscCsv,ICsvLineSplitter csvlineSplitter /*Ilogger ?*/)
        {
            if (pscCsv.Data != null && pscCsv.Data.Lines != null)
            {
                //Set CSvHeader items from the first line - Add errors
                if (pscCsv.HasHeader)
                {
                    pscCsv.Headers.RawHeaderLine = pscCsv.Data.Lines.First().Line ?? "";
                    //run method/s to calcualte header properties from T
                }
                else { /*TODO: ? */}

                //Set footer items from last line items, remove last line - add errors
                if (pscCsv.HasFooter)
                {
                    /* Remove last line*/

                    if (pscCsv.Data.Lines.Last().Line
                        == pscCsv.Data.Lines.First().Line)
                    {
                        //TODO : can this be set to represent no data?
                    }
                    else
                    {
                        //Anti-pattern warning - footer needs an interface, be extensible for future requirements
                        var lastLine = pscCsv.Data.Lines.Last().Line;                                           
                        var footerElements = csvlineSplitter.CsvSplit(
                            lastLine, pscCsv.IsQuoted, true, pscCsv.Separator, pscCsv.Quote);
                        //Run footer get and set   
                    }
                }           
            }
            else
            {
                //Check pscCsv.Errors
            }

            //Set line items to the T type container  - add errors

            return pscCsv;
        }
    }
}
