using MoreLinq;
using MoreLinq.Experimental;

namespace Yield
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Main1();

            Console.WriteLine("Zle");

            foreach (var item in DataAwfulGenerator.GetViewers())
            {
                string message = $"Czytam : {item.Name} \t Daje kom: {item.CanGiveComment}";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("Dobrze");

            foreach (var item in DataBetterGenerator.GetViewers())
            {
                string message = $"Czytam : {item.Name} \t Daje kom: {item.CanGiveComment}";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("Dzialanie Take");
            Console.WriteLine("Zle");
            var v1 = DataAwfulGenerator.GetViewers().Take(2);

            Console.WriteLine("Dobrze");
            var v2 = DataBetterGenerator.GetViewers().Take(2);

            Console.WriteLine("Iteracja po kolekcji v2:");
            foreach (var item in v2)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Etap generatora liczb");

            var randomNumbers = RandomNumberGenerator.RandomNumberCollection().Take(10);

            string message1 = "";
            foreach (var number in randomNumbers)
            {
                message1 += number + ",";
            }

            Console.WriteLine(message1);

            Console.WriteLine("Etap generowania liczb pierwszych");

            Console.WriteLine();
            var primeNumbers = PrideNumberGenerator.GetPrideNumbers().Take(10);

            foreach (var number in primeNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Iterowanie nie poprzez foreach, a poprzez iterator:");

            var iterator = primeNumbers.GetEnumerator();

            while (true)
            {
                if (iterator.MoveNext())
                {
                    Console.WriteLine(iterator.Current);
                }
                else
                {
                    break;
                }
            }

            int count = primeNumbers.Count();
            Console.WriteLine("Count: " + count);

            Console.WriteLine("Prograwmowanie funkcyjne");

            var even =  EnumerableEX.From(x => x * 2).Take(10);

            foreach (var number in even)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Memorization");
            var even2 = EnumerableEX.From(x => 2 * x);
            var data1 = even2.Take(4).ToList();
            var data2 = even2.Take(8).ToList();

            foreach (var number in data1)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            foreach (var number in data2)
            {
                Console.WriteLine(number);   
            }

            Console.WriteLine("MoreLinq");

            var even3 = EnumerableEX.From(x => 2 * x).Memoize();
            var data3 = even3.Take(5).ToList();
            var data4 = even3.Take(10).ToList();

            foreach (var number in data3)
            {
                Console.WriteLine(number);   
            }

            Console.WriteLine();
            data4.ForEach(Console.WriteLine);

            Console.WriteLine("Paraller");

            //var result = EnumerableEX
            //    .From(x => x - (x * 2))
            //    .Take(10)
            //    .AsParallel()
            //    .ToList();

            IEnumerable<decimal> someNumbers = EnumerableEX
                .From<decimal>(x => 4 * x)
                .Take(5)
                .ToList();

            IEnumerable<string> strings = EnumerableEX
                .From<string>(x => $"x to: {x}")
                .Take(5);

            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }


            Console.WriteLine("Calculation class");
            var messages = EnumerableEX.From<Calculations>
            (x =>
                new Calculations()
                {
                    X = x,
                    Y = 3,
                    Result = Math.Pow(2, x)
                }
            );

            foreach (var number in messages.Take(20)) 
            {
                Console.WriteLine("X = {0}, Y = {1}, Result = {2}", number.X, number.Y, number.Result); 
            }

            Console.WriteLine("Implementation a IEnumerable interface");

            var newGeneratorResult = EnumerableEX.From2(x => 2*x).Take(5);

            foreach (var number in newGeneratorResult)
            {
                Console.WriteLine(number);   
            }

            Console.WriteLine();

            var newGeneratorResult2 = EnumerableEX.From2(x => $"siabadadada {x}").Take(5);

            foreach (var item in newGeneratorResult2)
            {
                Console.WriteLine(item);    
            }
            
        }

        public static void Main1()
        {
            var x = GetYieldedData();

            foreach (var item in x)
            {
                Console.WriteLine(item);

                if (item > 5)
                {
                    break;
                }
            }

            Console.WriteLine();

            var y = GetData();

            foreach (var item in y)
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<int> GetYieldedData()
        {
            Console.WriteLine("Yield version, get data start");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Yield version, get data element {i}");
                yield return i;

                if (i == 3)
                {
                    yield break;
                }
            }

            Console.WriteLine("Yield version, get data stop");
        }

        static IEnumerable<int> GetData()
        {
            Console.WriteLine("Get data start");
            var result = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Get data element: {i}");
                result.Add(i);
            }

            Console.WriteLine("Get data stop");
            return result;
        }
    }
}