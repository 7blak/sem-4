using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.News
{
    public class CartesianProdEnum<T1, T2> : IEnumerator<(T1, T2)>
    {
        private readonly List<T1> _list1;
        private readonly List<T2> _list2;
        private int _list1index = -1;
        private int _list2index = 0;
        public CartesianProdEnum(List<T1> list1, List<T2> list2)
        {
            _list1 = list1 ?? throw new ArgumentNullException(nameof(list1));
            _list2 = list2 ?? throw new ArgumentNullException(nameof(list2));
        }
        public (T1, T2) Current => (_list1[_list1index], _list2[_list2index]);
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public bool MoveNext()
        {
            _list1index++;
            if (_list1index >= _list1.Count)
            {
                _list1index = 0;
                _list2index++;
            }
            return _list2index < _list2.Count;
        }
        public void Reset()
        {
            _list1index = -1;
            _list2index = 0;
        }
    }
}
