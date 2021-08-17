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
    public interface IDict<TKey, TVal>
    {
        // добавление пары ключ-значение
        public void Add(TKey key, TVal val);

        // удаление конкретного значения по ключу
        public void RemovePair(TKey key, TVal val);

        //полное удаление ключа и всех значений с ним связанных        
        public void RemoveKey(TKey key);

        // может быть больше одного значения по ключу
        public TVal[] this[TKey key] { get; }

        // получить ключ для значения
        public TKey this[TVal value] { get; }
        
        // количество пар значений
        public int Count { get; }

        // массив ключей
        public TKey[] Keys { get; }

        // класс предусматривает наличие пустых ключей
        public bool? IsKeyEmpty(TKey key);
    }

    public partial class MyDictionary<TKey, TVal> : 
        IDict<TKey, TVal>, 
        IEnumerable<MyDictionary<TKey,TVal>.PairItem>, 
        IEnumerator<MyDictionary<TKey, TVal>.PairItem>
    {
        PairItem[] pairs;

        public MyDictionary()
        {
            pairs = new PairItem[] { };
        }        

        public TVal[] this[TKey key]
        {
            get
            {
                return DictTools.GetPairItem(pairs, key).Values;
            }
        }

        public TKey this[TVal value]
        {
            get
            {
                for (int i = 0; i < pairs.Length; i++)
                {
                    if (Array.Exists(pairs[i].Values, val => val.GetHashCode() == value.GetHashCode()))
                    {
                        return pairs[i].Key;
                    } 
                }
                return default(TKey);
            }
        }        

        public int CountOfPairs
        {
            get { return pairs.Length; }
        }

        public int Count
        {
            get
            {
                int sumOfPairs = 0;
                for(int i = 0; i<pairs.Length; i++)
                {
                    sumOfPairs += pairs[i].Values.Length;
                }
                return sumOfPairs;
            }
        }

        public TKey[] Keys
        {
            get
            {
                TKey[] keys = new TKey[] { };
                for(int i = 0; i < pairs.Length; i++)
                {
                    AddItemToArray(ref keys, pairs[i].Key);
                }
                return keys;
            }
        }

        // добавление пары ключ-значение
        public void Add(TKey key, TVal val)
        {
            if (DictTools.KeyExists(pairs, key))
            {
                PairItem pair = Array.Find(pairs, p => DictTools.KeysMatching(p, key));
                TVal[] newValues = pair.Values;
                AddItemToArray(ref newValues, val);
                pair.Values = newValues;
            }
            else
            {
                PairItem pair = new PairItem();
                pair.Key = key;
                TVal[] newValues = pair.Values;
                AddItemToArray(ref newValues, val);
                pair.Values = newValues;
                AddItemToArray(ref pairs, pair);
            }            
        }        

        public bool? IsKeyEmpty(TKey key)
        {
            if (DictTools.KeyExists(pairs, key))
            {
                var pair = DictTools.GetPairItem(pairs, key);
                return pair.Values.Length == 0 ? true : false;
            }

            return null;
        }

        // полностью удаляет все пары с заданным ключом
        // в списке не остаётся заданного ключа, даже пустого
        public void RemoveKey(TKey key)
        {
            if (DictTools.KeyExists(pairs, key))
            {
                RemoveItemFromArray(ref pairs, DictTools.GetPairItem(pairs, key));
            }
        }


        public void RemovePair(TKey key, TVal val)
        {
            if(DictTools.KeyExists(pairs, key))
            {
                var pair = DictTools.GetPairItem(pairs, key);
                TVal[] newValues = pair.Values;
                RemoveItemFromArray(ref newValues, val);
                pair.Values = newValues;
            }
        }

        

        // внутренний класс для представления ключ-значение
        public class PairItem
        {
            public TKey Key
            {
                get;
                set;
            }

            public TVal[] Values
            {
                get;
                set;
            }

            public PairItem()
            {
                Values = new TVal[] { };
            }
        }

        static class DictTools
        {
            public static PairItem GetPairItem(PairItem[] pairs, TKey key)
            {
                return Array.Find(pairs, p => DictTools.KeysMatching(p, key));
            }

            //public static bool ValueExists(TVal val)
            //{

            //}

            // поиск совпадения ключей - для предыдущего метода
            public static bool KeysMatching(PairItem p, TKey key)
            {
                return p.Key.GetHashCode() == key.GetHashCode();
            }

            public static bool KeyExists(PairItem[] pairs, TKey key)
            {
                return Array.Exists(pairs, p => KeysMatching(p, key));
            }
        }
    }
}
