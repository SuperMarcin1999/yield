using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class RandomNumberGenerator
    {
        public static IEnumerable<int> RandomNumberCollection()
        {
            while (true)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());

                int number = r.Next();

                yield return number;
            }
        }
    }
}
