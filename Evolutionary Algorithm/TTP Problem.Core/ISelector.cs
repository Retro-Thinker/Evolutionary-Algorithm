using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.TTP_Problem.Core
{
    public interface ISelector<T> where T : ISpecimen
    {
        List<T> Select(List<T> specimens);
    }
}
