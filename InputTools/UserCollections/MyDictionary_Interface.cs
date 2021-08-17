using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static InputTools.ProgramElementEdit;
using static InputTools.ArrayTools;

using System.Collections;

namespace UserCollections
{
    public partial class MyDictionary<TKey, TVal> :
        IDict<TKey, TVal>,
        IEnumerable<MyDictionary<TKey, TVal>.PairItem>,
        IEnumerator<MyDictionary<TKey, TVal>.PairItem>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        public IEnumerator<MyDictionary<TKey, TVal>.PairItem> GetEnumerator()
        {
            return this as IEnumerator<MyDictionary<TKey, TVal>.PairItem>;
        }

        int position = -1;

        public bool MoveNext()
        {
            if (position < pairs.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }        

        public void Dispose()
        {
            
        }

        public MyDictionary<TKey, TVal>.PairItem Current { get { return pairs[position]; } }

        object IEnumerator.Current { get { return pairs[position]; } }
    }
}
