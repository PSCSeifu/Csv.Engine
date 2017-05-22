using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Common.CsvComponent
{
    public class CsvCompositeComponent : ICsvComponent
    {
        private ICollection<ICsvComponent> children;

        public CsvCompositeComponent()
        {
            children = new List<ICsvComponent>();
        }

        public void Add()
        {
            foreach (var child in children)
            {
                child.Add();
            }
        }

        public void AddCsvComponent(ICsvComponent csvComponent)
        {
            children.Add(csvComponent);
        }

        public void RemoveCsvComponent(ICsvComponent csvComponent)
        {
            children.Remove(csvComponent);
        }
             
        

    }
}
