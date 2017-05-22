using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public class CsvLinesMaker : ICsvLinesMaker
    {
        /// <summary>
        /// Creates a string, delimited by a seprator character, from a string collection.  Uses comma as  default delimiter.
        /// Can optionally wrap and/or trim each string item with a quote character (Uses double quote as default). . 
        /// Can optionally append an end of line string to the returned string.
        /// </summary>
        /// <param name="source">IEnumerable String Collection</param>
        /// <param name="addQuotes">Wraps items with quote char by default</param>
        /// <param name="trimItems">Trims each items by Default</param>
        /// <param name="separator">Default seaprator char is comma</param>
        /// <param name="quote">Default quote char is double quotes</param>
        /// <param name="lineTerminator">No Line terminator char is added by default</param>
        /// <returns>Delimited string</returns>
        public string MakeCsvLines(IEnumerable<string> source, bool addQuotes, bool trimItems, char separator, char quote,string lineTerminator)
        {
            string CsvLines = "";

            if (source == null || source.Count() <= 0)
            {
                return CsvLines;
            }
            if ((int)separator == 0)
            {
                separator = ',';
            }
            if ((int)quote == 0)
            {
                quote = '"';
            }

            var array = source.ToArray();            

            for (int i = 0; i < source.Count(); i++)
            {
                if (array[i] == null) { array[i] = ""; }
                if (trimItems) { array[i] = array[i].Trim(); }
                if (addQuotes) { array[i] = $"{quote.ToString()}{array[i]}{quote.ToString()}"; }
            }

            CsvLines = string.Join(separator.ToString(), array);

            if (!string.IsNullOrEmpty(lineTerminator))
            {
                CsvLines += lineTerminator;
            }

            return CsvLines;
        }

        /// <summary>
        /// Creates a string, delimited by a seprator character, from a string collection.  Uses comma as  default delimiter.
        /// Can optionally wrap and/or trim each string item with a quote character (Uses double quote as default). . 
        /// </summary>
        /// <param name="source">IEnumerable String Collection</param>
        /// <param name="addQuotes">Wraps items with quote char by default</param>
        /// <param name="trimItems">Trims each items by Default</param>
        /// <param name="separator">Default seaprator char is comma</param>
        /// <param name="quote">Default quote char is double quotes</param>        
        /// <returns>Delimited string</returns>
        public string MakeCsvLines(IEnumerable<string> sourceList, bool addQuotes ,bool trimItems, char separator, char quote)
           => MakeCsvLines(sourceList, addQuotes, trimItems, separator, quote, null);

        /// <summary>
        /// Creates a string, delimited by a seprator character, from a string collection. Uses comma as  default delimiter.
        /// Can optionally wrap each string item with a quote character (Uses double quote as default). 
        /// </summary>
        /// <param name="source">IEnumerable String Collection</param>
        /// <param name="addQuotes">Wraps items with quote char by default</param>       
        /// <param name="separator">Default seaprator char is comma</param>
        /// <param name="quote">Default quote char is double quotes</param>        
        /// <returns>Delimited string</returns>
        public string MakeCsvLines(IEnumerable<string> sourceList, bool addQuotes, char separator, char quote)
           => MakeCsvLines(sourceList, addQuotes, true, separator, quote, null);

        /// <summary>
        /// Creates a string, delimited by a seprator character, from a string collection. Uses comma as  default delimiter.
        /// Trims and Wraps each string item with a quote character (Uses double quote as default). 
        /// </summary>
        /// <param name="source">IEnumerable String Collection</param>             
        /// <param name="separator">Default seaprator char is comma</param>
        /// <param name="quote">Default quote char is double quotes</param>        
        /// <returns>Delimited string</returns>
        public string MakeCsvLines(IEnumerable<string> sourceList, char separator, char quote)
           => MakeCsvLines(sourceList, true, true, separator, quote, null);

        /// <summary>
        /// Creates a string, delimited by a seprator character, from a string collection. Uses comma as  default delimiter.
        /// Trims and Wraps each string item with a Double quote character.
        /// </summary>
        /// <param name="source">IEnumerable String Collection</param>             
        /// <param name="separator">Default seaprator char is comma</param>            
        /// <returns>Delimited string</returns>
        public string MakeCsvLines(IEnumerable<string> sourceList, char separator)
          => MakeCsvLines(sourceList, true, true, separator, '"', null);

        /// <summary>
        /// Creates a comma delimited string from a string collection.
        /// Trims and Wraps each string item with a Double quote character.
        /// </summary>
        /// <param name="source">IEnumerable String Collection</param>                               
        /// <returns>Delimited string</returns>
        public string MakeCsvLines(IEnumerable<string> sourceList)
         => MakeCsvLines(sourceList, true, true, ',', '"', null);
    }
}
