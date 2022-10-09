using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary_Algorithm.TTP_Problem.Core
{
    public interface ICrossover<T> where T : ISpecimen
    {
        List<T> Evaluate(List<T> specimens);
    }
}
