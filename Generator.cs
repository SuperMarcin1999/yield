using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class Generator<T> : IEnumerable<T>
    {
        private GeneratorEnumerator<T> _generatorEnumerator;

        public Generator(Func<int, T> func)
        {
            _generatorEnumerator = new GeneratorEnumerator<T>(func);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _generatorEnumerator;
        }
    }
}
