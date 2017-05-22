using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types;
using System.Reflection;
using System.Collections;

namespace Csv.Common.ObjectToStringCollectionMapper
{
    public sealed class ObjectToStringCollectionMapper : IObjectToStringCollectionMapper
    {
        public List<string> CsvDecompose<T>(T sourceObject)
            => CsvDecompose<T>(sourceObject, new List<string>());

        public List<string> CsvDecompose<T>(T sourceObject, List<CsvHeaderItem> requiredheaderItems)
        {
            if (requiredheaderItems == null || requiredheaderItems.Count == 0 || sourceObject == null)
                return new List<string>();

            return CsvDecompose<T>(sourceObject, GetObjectMap<T>(sourceObject, requiredheaderItems));
        }

        public List<string> CsvDecompose<T>(T sourceObject, List<string> requiredFields)
        {
            if (requiredFields == null || requiredFields.Count == 0 || requiredFields == null)
                return new List<string>();

            return CsvDecompose<T>(sourceObject, GetObjectMap<T>(sourceObject, requiredFields));
        }

        
        public List<string> GetCsvHeaderFields<T>()
        {
            T sourceObject = Activator.CreateInstance<T>();
            List<string> fields = new List<string>();

            foreach (PropertyInfo property in sourceObject.GetType().GetProperties())
                fields.Add(property?.Name ?? "");

            return fields;
        }

        #region "  Private Functions "

        private  List<string> CsvDecompose<T>(T sourceObject, List<CsvObjectMap> objectMapList)
        {
            List<string> data = new List<string>();

            if (objectMapList == null || objectMapList.Count == 0 || sourceObject == null)
                return data;
                       
            if (objectMapList == null && objectMapList.Count > 0) return data;

            foreach (var item in objectMapList)
            {
                var value = sourceObject.GetType()
                                        .GetProperty(item.FieldName)
                                        .GetValue(sourceObject, null);

                if (item.Type.Equals(typeof(string)) || item.Type.Equals(typeof(int)) || (item.Type.Equals(typeof(DateTime))
                    || item.Type.Equals(typeof(bool)) || item.Type.Equals(typeof(short))
                    || item.Type.Equals(typeof(float)) || item.Type.Equals(typeof(double))
                    || item.Type.Equals(typeof(long))))
                    data.Add(value.ToString());

                else if (item.Type.Equals(typeof(int?)) || (item.Type.Equals(typeof(DateTime?))
                    || item.Type.Equals(typeof(bool?)) || item.Type.Equals(typeof(short?))
                    || item.Type.Equals(typeof(float?)) || item.Type.Equals(typeof(double?))
                    || item.Type.Equals(typeof(long?))))
                    data.Add(value?.ToString() ?? "");
                else
                    data.Add("");
            }

            return data;
        }

        private List<CsvObjectMap> GetObjectMapWithDataValue<T>(T sourceObject, List<string> fields)
        {
            List<CsvObjectMap> objectMapList = new List<CsvObjectMap>();

            if (fields != null && fields.Count > 0)
            {
                foreach (var field in fields)
                {
                    var property = sourceObject.GetType().GetProperties()
                                                .Where(x => x.Name == field)
                                                .SingleOrDefault();

                    var value = sourceObject.GetType().GetProperty(field).GetValue(sourceObject, null);

                    objectMapList.Add(new CsvObjectMap(field, property?.PropertyType ?? typeof(string), value));
                }
            }

            return objectMapList;
        }

        private List<CsvObjectMap> GetObjectMapWithDataValue<T>(T sourceObject, List<CsvHeaderItem> headerItems)
            => GetObjectMapWithDataValue<T>(sourceObject, ExtractFields(headerItems));        

        private List<CsvObjectMap> GetObjectMap<T>(T sourceObject, List<string> fields)
        {
            List<CsvObjectMap> objectMapList = new List<CsvObjectMap>();

            if (fields != null && fields.Count > 0)
            {
                foreach (var field in fields)
                {
                    var property = sourceObject.GetType().GetProperties()
                                                .Where(x => x.Name == field)
                                                .SingleOrDefault();
                    objectMapList.Add(new CsvObjectMap(field, property?.PropertyType ?? typeof(string)));
                }
            }

            return objectMapList;
        }

        private List<CsvObjectMap> GetObjectMap<T>(T sourceObject, List<CsvHeaderItem> headerItems)        
            =>  GetObjectMap<T>(sourceObject, ExtractFields(headerItems));        

        private List<string> ExtractFields(List<CsvHeaderItem> headerItems)
        {
            List<string> fields = new List<string>();
            if (headerItems != null && headerItems.Count() > 0)
            {
                foreach (var header in headerItems)
                {
                    fields.Add(header?.FieldName ?? "");
                }
            }
            return fields;
        }

        #endregion
    }
}
