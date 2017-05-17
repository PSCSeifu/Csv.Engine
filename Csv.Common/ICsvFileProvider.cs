
using Csv.Lib.Domain.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvFileProvider
    {
        Result<IEnumerable<string>,Error> GetCsvData(string fullFilePath);
        Result<Unit, Error> WriteCsvData<T>(IEnumerable<string> csvdata, string fullFilePath);
    }
}
