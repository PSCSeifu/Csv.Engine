using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Engine.CsvWrite
{
    public interface ICsvWrite
    {
        void WriteCsv<T>(IEnumerable<T> data, string filePath);
    }
}
