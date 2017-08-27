using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.Models
{
    public interface IExampleRepository
    {
        IEnumerable<ExampleModel> Models();
    }
}
