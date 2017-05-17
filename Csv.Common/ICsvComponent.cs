using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common
{
    public interface ICsvComponent
    {
        string Write(char separator, char quote);
        T Read<T>(string line, char separator, char quote);
    }
}
