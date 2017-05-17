using Csv.Lib.Domain.Functional;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public class CsvFileProvider : ICsvFileProvider
    {
        public Result<IEnumerable<string>, Error> GetCsvData(string fullFilePath)
        {
            if(string.IsNullOrEmpty(fullFilePath))
            {
                return Result<IEnumerable<string>, Error>.Fail(Error.Exception("Full File path is nul or empty"));
            }

            if (!Directory.Exists(fullFilePath))
            {
                return Result<IEnumerable<string>, Error>.Fail(Error.Exception("The given path does not refer to an existing directory"));
            }

            if (!File.Exists(fullFilePath)) {
                return Result<IEnumerable<string>, Error>.Fail(Error.Exception("The specified file does not exist"));
            }

            var list = new List<string>();
            using (StreamReader sr = new StreamReader(fullFilePath))
            {
                try
                {
                    list.Add(sr.ReadLine());
                }
                catch { }
            }

            return Result<IEnumerable<string>, Error>.Ok(list);

        }

        public Result<Unit, Error> WriteCsvData<T>(IEnumerable<string> csvdata, string fullFilePath)
        {
            if (string.IsNullOrEmpty(fullFilePath))
            {
                return Result<Unit, Error>.Fail(Error.Exception("Full File path is nul or empty"));
            }

            if (!Directory.Exists(fullFilePath))
            {
                return Result<Unit, Error>.Fail(Error.Exception("The given path does not refer to an existing directory"));
            }

            if (!File.Exists(fullFilePath))
            {
                return Result<Unit, Error>.Fail(Error.Exception("The specified file does not exist"));
            }
            if(csvdata == null)
            {
                return Result<Unit, Error>.Fail(Error.Exception("The csv data is null"));
            }

            using (StreamWriter sw = new StreamWriter(fullFilePath, true))
            {
                if (csvdata.Count() > 0)
                {
                    foreach (var csvline in csvdata)
                    {
                        sw.WriteLine(csvline);
                    }
                }
            }

            return Result<Unit, Error>.Ok(F.Unit());
        }
    }
}
