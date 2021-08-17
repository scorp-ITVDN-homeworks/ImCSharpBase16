using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using static InputTools.ArrayTools;

namespace UserCollections
{
    public interface IListTools<T>
    {
        public void Add(T newItem);
        public void AddAtIndex(T newItem, int index);
        public void Remove(T arrayItem);
        public void RemoveAtIndex(int index);
        public T this[int index] { get;set; }
        public int Count { get; }
    }

    public partial class MyList<T> : IListTools<T>, IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>
    {
        T[] itemsArray = new T[] { };

        //TODO добавить проверку выхода индекса за пределы массива
        public T this[int index]
        {
            get { return itemsArray[index]; }
            set { itemsArray[index] = value; }
        }

        public int Count
        {
            get { return itemsArray.Length; }
        }

        public void Add(T newItem)
        {
            AddItemToArray(ref itemsArray, newItem);
        }

        public void AddAtIndex(T newItem, int index)
        {
            AddItemToArray(ref itemsArray, newItem, index);
        }

        public void Remove(T arrayItem)
        {
            RemoveItemFromArray(ref itemsArray, arrayItem);
        }

        public void RemoveAtIndex(int index)
        {
            RemoveItemFromArray(ref itemsArray, index);
        }
    }
}
