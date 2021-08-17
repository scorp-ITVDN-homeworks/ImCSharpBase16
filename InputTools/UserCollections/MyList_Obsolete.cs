using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections
{
    public partial class MyList<T>
    {
        //public void AddItem(T newItem)
        //{
        //    Array.Resize<T>(ref itemsArray, itemsArray.Length + 1);
        //    itemsArray[itemsArray.Length - 1] = newItem;
        //}

        //public void AddItem(T newItem, int index)
        //{
        //    // получить элементы от заданного индекса включительно
        //    T[] tempArray = new T[itemsArray.Length - index];
        //    Array.Copy(itemsArray, index, tempArray, 0, tempArray.Length);
        //    // увеличение длины массива на 1
        //    Array.Resize(ref itemsArray, itemsArray.Length + 1);
        //    // и перезапись заданного по индексу элемента массива
        //    itemsArray[index] = newItem;
        //    // запись в исходный массив из временного
        //    Array.Copy(tempArray, 0, itemsArray, index + 1, tempArray.Length);
        //}

        //public void RemoveItem(T arrayItem)
        //{
        //    int index = Array.IndexOf(itemsArray, arrayItem);
        //    RemoveItemAtIndex(index);
        //}

        //public void RemoveItemAtIndex(int index)
        //{
        //    if (index >= itemsArray.Length) return;
        //    // получить элементы от заданного индекса, исключая элемент по индексу
        //    T[] tempArray = new T[itemsArray.Length - index - 1];
        //    Array.Copy(itemsArray, index + 1, tempArray, 0, tempArray.Length);
        //    // уменьшение длины массива на 1
        //    Array.Resize(ref itemsArray, itemsArray.Length - 1);
        //    // запись в исходный массив из временного
        //    Array.Copy(tempArray, 0, itemsArray, index, tempArray.Length);
        //}
    }
}
