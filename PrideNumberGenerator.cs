using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class PrideNumberGenerator
    {
        public static IEnumerable<int> GetPrideNumbers()
        {
            int counter = 1;
            while (counter != int.MaxValue)
            {
                if(IsPrideNumber(counter))
                    yield return counter;

                counter++;
            }
        }

        private static bool IsPrideNumber(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
