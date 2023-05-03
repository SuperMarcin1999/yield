using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class EnumerableEX
    {
        public static IEnumerable<int> From(Func<int, int> func)
        {
            int counter = 1;

            while (counter != int.MaxValue)
            {
                yield return func.Invoke(counter);
                counter++;
            }
        }

        public static IEnumerable<T> From<T>(Func<int, T> func)
        {
            int counter = 1;

            while (counter != int.MaxValue)
            {
                yield return func.Invoke(counter);
                counter++;
            }
        }

        public static IEnumerable<T> From2<T>(Func<int, T> func)
        {
            return new Generator<T>(func);
        }
    }
}
