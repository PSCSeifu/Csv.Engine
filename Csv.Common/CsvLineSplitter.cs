using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public  class CsvLineSplitter : ICsvLineSplitter
    {
        /// <summary>
        /// Returns list of string. Splits the source string using provided seprator. Defaults to empty string list.
        /// Optionally removes provided quotes and trim each split item. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="stripQuotes"></param>
        /// <param name="trim"></param>
        /// <param name="separator"></param>
        /// <param name="quote"></param>
        /// <returns>List<string></returns>
        public IEnumerable<string> CsvSplit(string source, bool stripQuotes, bool trim, char separator, char quote)
        {
            string str1 = "\"\"";
            int startIndex = -1;
            int num = -1;
            if ((int)separator == 0)
                separator = ',';
            if ((int)quote == 0)
                quote = '"';
            else
                str1 = quote.ToString() + quote.ToString();
            List<string> stringList = new List<string>();
            if (string.IsNullOrEmpty(source))
                return stringList;
            source.Trim();
            if (source.Length < 3)
                return stringList;
            for (int length = 0; length < source.Length; ++length)
            {
                if ((int)source[length] == (int)separator && num == -1)
                {
                    if (startIndex == -1)
                    {
                        stringList.Add(source.Substring(0, length));
                        startIndex = length + 1;
                    }
                    else
                    {
                        if (stripQuotes)
                        {
                            string str2 = source.Substring(startIndex, length - startIndex);
                            if (str2 == str1)
                            {
                                stringList.Add("");
                            }
                            else
                            {
                                if (str2.Length > 2 && (int)str2[0] == (int)quote)
                                {
                                    string str3 = str2;
                                    int index = str3.Length - 1;
                                    if ((int)str3[index] == (int)quote)
                                        str2 = str2.Substring(1, str2.Length - 2);
                                }
                                if (trim)
                                    str2 = str2.Trim();
                                stringList.Add(str2);
                            }
                        }
                        else if (trim)
                            stringList.Add(source.Substring(startIndex, length - startIndex).Trim());
                        else
                            stringList.Add(source.Substring(startIndex, length - startIndex));
                        startIndex = length + 1;
                    }
                }
                if ((int)source[length] == (int)quote)
                {
                    if (num == -1)
                    {
                        num = length;
                        if (startIndex == -1)
                            startIndex = length;
                    }
                    else
                        num = -1;
                }
            }
            string str4 = source.Substring(startIndex, source.Length - startIndex);
            if (stripQuotes)
            {
                if (str4 == str1)
                {
                    stringList.Add("");
                }
                else
                {
                    if (str4.Length > 2 && (int)str4[0] == (int)quote)
                    {
                        string str2 = str4;
                        int index = str2.Length - 1;
                        if ((int)str2[index] == (int)quote)
                            str4 = str4.Substring(1, str4.Length - 2);
                    }
                    if (trim)
                        str4 = str4.Trim();
                    stringList.Add(str4);
                }
            }
            else if (trim)
                stringList.Add(str4.Trim());
            else
                stringList.Add(str4);
            return stringList;
        }

        public IEnumerable<string> CsvSplit(string source, bool stripQuotes,char separator, char quote)
            => CsvSplit(source, stripQuotes, true, separator, quote);

        public IEnumerable<string> CsvSplit(string source, char separator, char quote)
            =>  CsvSplit(source, true, true, separator, quote);

        public IEnumerable<string> CsvSplit(string source, char separator)
            => CsvSplit(source, true, true, separator,'"');

        public IEnumerable<string> CsvSplit(string source)
           => CsvSplit(source, true, true, ',', '"');

    }
}
