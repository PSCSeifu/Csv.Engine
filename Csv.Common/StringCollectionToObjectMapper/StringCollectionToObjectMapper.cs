using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types;
using System.Reflection;
using System.ComponentModel;

namespace Csv.Common.StringCollectionToObjectMapper
{
    public sealed class StringCollectionToObjectMapper : IStringCollectionToObjectMapper
    {
        #region " Csv To Object "

        public T CsvCompose<T>(List<string> source, List<string> requiredFields)
        {
            if (requiredFields == null)
            {
                requiredFields = GetCsvHeaderFields<T>();
            }

            T sourceObject = Activator.CreateInstance<T>();

            if (requiredFields == null || requiredFields.Count == 0 || (source == null || source.Count == 0) || source.Count < requiredFields.Count)
                return sourceObject;

            foreach (PropertyInfo property in sourceObject.GetType().GetProperties())
            {
                if (property.CanRead && property.CanWrite)
                {
                    DisplayNameAttribute[] customAttributes = (DisplayNameAttribute[])property.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                    int index1 = -1;
                    for (int index2 = 0; index2 <= requiredFields.Count - 1; ++index2)
                    {
                        if (requiredFields[index2].Trim().ToLower() == property.Name.Trim().ToLower())
                            index1 = index2;
                        else if (customAttributes != null && customAttributes.Length != 0 && requiredFields[index2].Trim().ToLower() == customAttributes[0].DisplayName.Trim().ToLower())
                            index1 = index2;
                    }
                    if (index1 > -1)
                    {
                        if (index1 < source.Count)
                        {
                            try
                            {
                                object obj = (object)null;
                                Type type = property.GetValue((object)sourceObject, (object[])null)?.GetType();
                                if ((object)type == (object)typeof(string))
                                {
                                    try
                                    {
                                        obj = (object)source[index1].Trim();
                                    }
                                    catch
                                    {
                                        obj = (object)"";
                                    }
                                }
                                else if ((object)type == (object)typeof(int) || (object)type == (object)typeof(int))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        if (IsNumeric(source[index1]))
                                        {
                                            try
                                            {
                                                obj = (object)Convert.ToInt32(source[index1].Trim());
                                                goto label_62;
                                            }
                                            catch
                                            {
                                                obj = (object)Convert.ToInt32(0);
                                                goto label_62;
                                            }
                                        }
                                    }
                                    obj = (object)Convert.ToInt32(0);
                                }
                                else if ((object)type == (object)typeof(short))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        if (IsNumeric(source[index1]))
                                        {
                                            try
                                            {
                                                obj = (object)Convert.ToInt16(source[index1].Trim());
                                                goto label_62;
                                            }
                                            catch
                                            {
                                                obj = (object)Convert.ToInt16(0);
                                                goto label_62;
                                            }
                                        }
                                    }
                                    obj = (object)Convert.ToInt16(0);
                                }
                                else if ((object)type == (object)typeof(long))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        if (IsNumeric(source[index1]))
                                        {
                                            try
                                            {
                                                obj = (object)Convert.ToInt64(source[index1].Trim());
                                                goto label_62;
                                            }
                                            catch
                                            {
                                                obj = (object)Convert.ToInt64(0);
                                                goto label_62;
                                            }
                                        }
                                    }
                                    obj = (object)Convert.ToInt64(0);
                                }
                                else if ((object)type == (object)typeof(float))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        if (IsNumeric(source[index1]))
                                        {
                                            try
                                            {
                                                obj = (object)Convert.ToSingle(source[index1]);
                                                goto label_62;
                                            }
                                            catch
                                            {
                                                obj = (object)Convert.ToSingle(0);
                                                goto label_62;
                                            }
                                        }
                                    }
                                    obj = (object)Convert.ToSingle(0);
                                }
                                else if ((object)type == (object)typeof(double))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        if (IsNumeric(source[index1]))
                                        {
                                            try
                                            {
                                                obj = (object)Convert.ToDouble(source[index1].Trim());
                                                goto label_62;
                                            }
                                            catch
                                            {
                                                obj = (object)Convert.ToDouble(0);
                                                goto label_62;
                                            }
                                        }
                                    }
                                    obj = (object)Convert.ToDouble(0);
                                }
                                else if ((object)type == (object)typeof(Decimal))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        if (IsNumeric(source[index1]))
                                        {
                                            try
                                            {
                                                obj = (object)Convert.ToDecimal(source[index1].Trim());
                                                goto label_62;
                                            }
                                            catch
                                            {
                                                obj = (object)Convert.ToDecimal(0);
                                                goto label_62;
                                            }
                                        }
                                    }
                                    obj = (object)Convert.ToDecimal(0);
                                }
                                else if ((object)type == (object)typeof(bool))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        try
                                        {
                                            obj = (object)Convert.ToBoolean(source[index1].Trim());
                                        }
                                        catch
                                        {
                                            obj = (object)false;
                                        }
                                    }
                                    else
                                        obj = (object)Convert.ToDouble(0);
                                }
                                else if ((object)type == (object)typeof(DateTime))
                                {
                                    if (!string.IsNullOrEmpty(source[index1]))
                                    {
                                        try
                                        {
                                            obj = (object)ToDate(source[index1]);
                                        }
                                        catch
                                        {
                                            obj = (object)new DateTime(1900, 1, 1);
                                        }
                                    }
                                    else
                                        obj = (object)new DateTime(1900, 1, 1);
                                }
                                label_62:
                                if (obj != null)
                                    property.SetValue((object)sourceObject, obj, (object[])null);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }

            return sourceObject;
        }

        public T CsvCompose<T>(List<string> source)
            => CsvCompose<T>(source, null);

        #endregion

        #region "  Column "

        public CsvColumn CsvColumnCompose(IEnumerable<string> source, CsvHeaderItem csvHeaderItem)
        {
            throw new NotImplementedException();
        }

        public CsvColumn CsvColumnCompose(IEnumerable<string> source, Type columnType)
        {
            throw new NotImplementedException();
        }

        public CsvColumn CreateCsvColumn<T>(IEnumerable<string> dataItems, string fieldName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region " Header "

        public CsvHeader CsvHeaderCompose<T>(IEnumerable<string> requiredFieldNames)
        {
            T sourceObject = Activator.CreateInstance<T>();
            CsvHeader csvHeader = null;
            PropertyInfo[] propertyInfoArray = sourceObject.GetType().GetProperties();

            if (propertyInfoArray != null && propertyInfoArray.Count() > 0)
            {
                foreach (PropertyInfo property in sourceObject.GetType().GetProperties())
                {
                    try
                    {
                        var fieldName = property?.Name;
                        if (string.IsNullOrEmpty(fieldName) && requiredFieldNames.Contains(fieldName))
                            csvHeader.Headers.Add(CsvHeaderItem(fieldName, property.GetType()));
                    }
                    catch { }
                }
            }

            return csvHeader;
        }

        public CsvHeaderItem CsvHeaderItem(string fieldName, Type dataType, string defaultValue = "", bool forcedDefault = false, bool allowNull  = true, int orderNo = 0, int maxSize = 0, int minSize = 0)
        {
            CsvHeaderItem csvHeaderItem = null;

            csvHeaderItem.FieldName = fieldName ?? "";          
            csvHeaderItem.DataType = dataType;
            csvHeaderItem.DefaultValue = defaultValue;
            csvHeaderItem.ForcedDefault = forcedDefault;
            csvHeaderItem.AllowNull = allowNull;
            csvHeaderItem.OrderNo = orderNo;
            csvHeaderItem.MaxSize = maxSize;
            csvHeaderItem.MinSize = minSize;

            return csvHeaderItem;
        }

        #endregion

        #region "  Footer "

        public CsvFooter CsvFooterCompose(IEnumerable<string> source)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region " Private "

        private List<string> GetCsvHeaderFields<T>()
        {
            T sourceObject = Activator.CreateInstance<T>();
            List<string> fields = new List<string>();

            foreach (PropertyInfo property in sourceObject.GetType().GetProperties())
                fields.Add(property?.Name ?? "");

            return fields;
        }

        public static DateTime ToDate(string value)
        {
            DateTime defaultValue = new DateTime(1900, 1, 1);
            return ToDate(value, defaultValue);
        }

        public static DateTime ToDate(string value, DateTime defaultValue)
        {
            return ToDate(value, defaultValue, false);
        }

        public static DateTime ToDate(string value, DateTime defaultValue, bool isUs)
        {
            int day = 0;
            int year = 0;
            int minute = 0;
            int hour = 0;
            int second = 0;
            bool flag = false;
            if (string.IsNullOrEmpty(value))
                return defaultValue;
            value = value.ToLower();
            string[] strArray1;
            if (value.Contains("t"))
            {
                string[] strArray2 = value.Split('t');
                strArray1 = strArray2[0].Split('-');
                flag = true;
                if (strArray2.Length == 2)
                {
                    string[] strArray3 = strArray2[1].Split(':');
                    if (strArray3.Length == 3)
                    {
                        hour = Convert.ToInt32(strArray3[0]);
                        minute = Convert.ToInt32(strArray3[1]);
                        second = Convert.ToInt32(Convert.ToDecimal(strArray3[2]));
                    }
                }
            }
            else if (value.Contains(":"))
            {
                value = value.Replace("pm", "");
                value = value.Replace("am", "");
                value = value.Trim();
                string[] strArray2 = value.Split(' ');
                if (value.Contains("/"))
                    strArray1 = strArray2[0].Split('/');
                else
                    strArray1 = strArray2[0].Split('-');
                if (strArray2.Length == 2)
                {
                    string[] strArray3 = strArray2[1].Split(':');
                    if (strArray3.Length == 3)
                    {
                        hour = Convert.ToInt32(strArray3[0]);
                        minute = Convert.ToInt32(strArray3[1]);
                        second = Convert.ToInt32(Convert.ToDecimal(strArray3[2]));
                    }
                }
            }
            else if (value.Contains("/"))
                strArray1 = value.Split('/');
            else if (value.Contains("-"))
                strArray1 = value.Split('-');
            else
                strArray1 = value.Split(' ');
            if (strArray1.Length < 3 || strArray1.Length > 4)
                return defaultValue;
            int num = strArray1.Length != 4 ? 0 : 1;
            if (strArray1[0].Length == 4 && strArray1[1].Length == 2 && strArray1[2].Length == 2)
                flag = true;
            else if (strArray1[0].Length == 2 && strArray1[1].Length == 2 && strArray1[2].Length == 4)
                flag = false;
            int month;
            if (flag)
            {
                if (IsNumeric(strArray1[2 + num]))
                    day = Convert.ToInt32(strArray1[2 + num]);
                month = !IsNumeric(strArray1[1 + num]) ? GetMonthFromString(strArray1[1 + num]) : Convert.ToInt32(strArray1[1 + num]);
                if (IsNumeric(strArray1[0 + num]))
                    year = Convert.ToInt32(strArray1[0 + num]);
            }
            else if (isUs)
            {
                if (IsNumeric(strArray1[1 + num]))
                    day = Convert.ToInt32(strArray1[1 + num]);
                month = !IsNumeric(strArray1[0 + num]) ? GetMonthFromString(strArray1[1 + num]) : Convert.ToInt32(strArray1[0 + num]);
                if (IsNumeric(strArray1[2 + num]))
                    year = Convert.ToInt32(strArray1[2 + num]);
            }
            else
            {
                if (IsNumeric(strArray1[0 + num]))
                    day = Convert.ToInt32(strArray1[0 + num]);
                month = !IsNumeric(strArray1[1 + num]) ? GetMonthFromString(strArray1[1 + num]) : Convert.ToInt32(strArray1[1 + num]);
                if (IsNumeric(strArray1[2 + num]))
                    year = Convert.ToInt32(strArray1[2 + num]);
            }
            if (day > 0 && month > 0)
            {
                if (year > 0)
                {
                    try
                    {
                        return new DateTime(year, month, day, hour, minute, second);
                    }
                    catch
                    {
                        try
                        {
                            return Convert.ToDateTime(value);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return ToDateVerbose(value, defaultValue);
        }


        public static DateTime ToDateVerbose(string value, string separator = "/", DateFormat format = DateFormat.UK)
        {
            return ToDateVerbose(value, new DateTime(1900, 1, 1), separator, format);
        }

        public static DateTime ToDateVerbose(string value, DateTime defaultValue, string separator = "/", DateFormat format = DateFormat.UK)
        {
            string[] strArray1 = new string[14]
            {
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sun",
        "Mon",
        "Tue",
        "Wed",
        "Thu",
        "Fri",
        "Sat"
            };
            int day = 0;
            int year = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;
            if (string.IsNullOrEmpty(value))
                return defaultValue;
            string[] strArray2;
            if (value.Contains("/"))
                strArray2 = value.Split('/');
            else if (value.Contains("-"))
                strArray2 = value.Split('-');
            else if (value.Contains("|"))
                strArray2 = value.Split('|');
            else if (value.Contains(separator))
                strArray2 = value.Split(separator.ToCharArray());
            else
                strArray2 = value.Split(' ');
            if (strArray2.Length < 3)
                return defaultValue;
            if (strArray2.Length > 3)
            {
                string[] strArray3 = strArray2[4].Trim().Split(':');
                if (strArray3.Length == 3)
                {
                    try
                    {
                        hour = Convert.ToInt32(strArray3[0]);
                        minute = Convert.ToInt32(strArray3[1]);
                        second = Convert.ToInt32(strArray3[2]);
                    }
                    catch
                    {
                    }
                }
            }
            int month;
            if (format == DateFormat.UK)
            {
                int num = strArray2.Length != 4 ? 0 : 1;
                if (IsNumeric(strArray2[0 + num]))
                    day = Convert.ToInt32(strArray2[0 + num]);
                month = !IsNumeric(strArray2[1 + num]) ? GetMonthFromString(strArray2[1 + num]) : Convert.ToInt32(strArray2[1 + num]);
                if (IsNumeric(strArray2[2 + num]))
                    year = Convert.ToInt32(strArray2[2 + num]);
            }
            else if (format == DateFormat.US)
            {
                if (IsNumeric(strArray2[1]))
                    day = Convert.ToInt32(strArray2[1]);
                month = !IsNumeric(strArray2[0]) ? GetMonthFromString(strArray2[0]) : Convert.ToInt32(strArray2[0]);
                if (IsNumeric(strArray2[2]))
                    year = Convert.ToInt32(strArray2[2]);
            }
            else
            {
                if (IsNumeric(strArray2[2]))
                    day = Convert.ToInt32(strArray2[2]);
                month = !IsNumeric(strArray2[1]) ? GetMonthFromString(strArray2[1]) : Convert.ToInt32(strArray2[1]);
                if (IsNumeric(strArray2[0]))
                    year = Convert.ToInt32(strArray2[0]);
            }
            if (day > 0 && month > 0)
            {
                if (year > 0)
                {
                    try
                    {
                        return new DateTime(year, month, day, hour, minute, second);
                    }
                    catch
                    {
                    }
                }
            }
            return defaultValue;
        }

        private static bool IsNumeric(string value)
        {
            double result;
            return !string.IsNullOrEmpty(value) && double.TryParse(value, out result);
        }

        public static DateTime ToDateVerbose(string value, DateTime defaultValue)
        {
            string[] strArray1 = new string[14]
            {
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sun",
        "Mon",
        "Tue",
        "Wed",
        "Thu",
        "Fri",
        "Sat"
            };
            int day = 0;
            int year = 0;
            if (string.IsNullOrEmpty(value))
                return defaultValue;
            string[] strArray2;
            if (value.Contains("/"))
                strArray2 = value.Split('/');
            else
                strArray2 = value.Split(' ');
            if (strArray2.Length < 3 || strArray2.Length > 4)
                return defaultValue;
            int num = strArray2.Length != 4 ? 0 : 1;
            if (IsNumeric(strArray2[0 + num]))
                day = Convert.ToInt32(strArray2[0 + num]);
            int month = !IsNumeric(strArray2[1 + num]) ? GetMonthFromString(strArray2[1 + num]) : Convert.ToInt32(strArray2[1 + num]);
            if (IsNumeric(strArray2[2 + num]))
                year = Convert.ToInt32(strArray2[2 + num]);
            if (day > 0 && month > 0)
            {
                if (year > 0)
                {
                    try
                    {
                        return new DateTime(year, month, day);
                    }
                    catch
                    {
                    }
                }
            }
            return defaultValue;
        }

        public static string ToCsvString(DateTime value)
        {
            return value.Year.ToString() + ":" + (object)value.Month + ":" + (object)value.Day + ":" + (object)value.Hour + ":" + (object)value.Minute + ":" + (object)value.Second;
        }

        private static int GetMonthFromString(string value)
        {
            string[] strArray = new string[24]
            {
        "january",
        "febuary",
        "march",
        "april",
        "may",
        "june",
        "july",
        "august",
        "september",
        "october",
        "november",
        "december",
        "jan",
        "feb",
        "mar",
        "apr",
        "may",
        "jun",
        "jul",
        "aug",
        "sep",
        "oct",
        "nov",
        "dec"
            };
            if (string.IsNullOrEmpty(value))
                return 0;
            value = StripNonAlphaChars(value.ToLower());
            for (int index = 0; index <= strArray.Length - 1; ++index)
            {
                if (strArray[index].ToLower() == value)
                {
                    if (index > 11)
                        return index - 11;
                    return index + 1;
                }
            }
            return 0;
        }

        public static string StripNonAlphaChars(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = value.ToCharArray();
            for (int index = 0; index <= charArray.Length - 1; ++index)
            {
                if ((int)charArray[index] > 96 && (int)charArray[index] < 122)
                    stringBuilder.Append(charArray[index]);
            }
            return stringBuilder.ToString();
        }

        

        public enum DateFormat
        {
            UK,
            US,
            ISO,
        }

        #endregion
    }
}
