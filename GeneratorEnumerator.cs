using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class GeneratorEnumerator<T> : IEnumerator<T>
    {
        private readonly Func<int, T> _generatorFunc;
        private int _index;
        private T _current;
        
        public T Current => _current;

        public GeneratorEnumerator(Func<int, T> generatorFunc)
        {
            _generatorFunc = generatorFunc;
        }

        public bool MoveNext()
        {
            _current = _generatorFunc(_index++);
            return true;
        }

        public void Reset()
        {
            _current = default(T);
            _index = 0;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _current = default(T);
            _index = 0;
        }
    }
}
