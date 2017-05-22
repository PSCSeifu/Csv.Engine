using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Engine.CsvRead
{
    public interface ICsvRead
    {
        IEnumerable<T> CsvRead<T>(string filePath);
    }
}
