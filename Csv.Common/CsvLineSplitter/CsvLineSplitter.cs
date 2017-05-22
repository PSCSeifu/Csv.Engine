using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public class CsvLineSplitter : ICsvLineSplitter
    {
        /// <summary>
        /// Returns list of string. Splits the source string using provided seprator. Defaults to empty string list.
        /// Optionally removes provided quotes and trim each split item. By default trims each result Collection Item.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="stripQuotes"></param>
        /// <param name="trimSource"></param>
        /// <param name="separator"></param>
        /// <param name="quote"></param>
        /// <returns>List<string></returns>
        public List<string> CsvSplit(string source, bool stripQuotes, bool trimItems, char separator, char quote)
        {
            List<string> stringList = new List<string>();
            string str1 = "\"\"";
            int startIndex = -1;
            int num = -1;

            if ((int)separator == 0)
            {
                separator = ',';
            }
            if ((int)quote == 0)
            {
                quote = '"';
            }
            else
            {
                str1 = quote.ToString() + quote.ToString();
            }
            if (string.IsNullOrEmpty(source))
            {
                return stringList;
            }

            if (source.Length < 3)
            {
                return stringList;
            }
            string input = source.Trim();


            for (int length = 0; length < input.Length; ++length)
            {
                if ((int)input[length] == (int)separator && num == -1)
                {
                    if (startIndex == -1)
                    {
                        stringList.Add(  (trimItems) ? 
                                input.Substring(0, length).Trim() :
                                input.Substring(0, length)
                            );
                        startIndex = length + 1;
                    }
                    else
                    {
                        if (stripQuotes)
                        {
                            string str2 = input.Substring(startIndex, length - startIndex);
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
                                if (trimItems)
                                    str2 = str2.Trim();
                                stringList.Add(str2);
                            }
                        }
                        else if (trimItems)
                            stringList.Add(input.Substring(startIndex, length - startIndex).Trim());
                        else
                            stringList.Add(input.Substring(startIndex, length - startIndex));
                        startIndex = length + 1;
                    }
                }
                if ((int)input[length] == (int)quote)
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

            if (startIndex >= 0)
            {
                string str4 = input.Substring(startIndex, input.Length - startIndex);
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
                        if (trimItems)
                            str4 = str4.Trim();
                        stringList.Add(str4);
                    }
                }
                else if (trimItems)
                { stringList.Add(str4.Trim()); }
                else
                { stringList.Add(str4); }
            }

            return stringList;
        }
        
        /// <summary>
        /// By default trims the source string line.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="stripQuotes"></param>
        /// <param name="separator"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        public List<string> CsvSplit(string source, bool stripQuotes, char separator, char quote)
        => CsvSplit(source, stripQuotes, true, separator, quote);

        /// <summary>
        /// By default strips the quotes and trims the source string line
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <param name="quote"></param>
        /// <returns>List<string></returns>
        public List<string> CsvSplit(string source, char separator, char quote)
            => CsvSplit(source, true, true, separator, quote);

        /// <summary>
        /// By default strips the quotes and trims the source string line. Uses the double quote character i.e. "
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public List<string> CsvSplit(string source, char separator)
            => CsvSplit(source, true, true, separator, '"');

        /// <summary>
        /// Use double quotes (") and comma (,) as default. Strips the quotes and trims the source string line
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<string> CsvSplit(string source)
           => CsvSplit(source, true, true, ',', '"');

    }
}
