using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputTools
{
    public static partial class ArrayTools
    {
        #region Методы добавления элементов в массив


        /* Метод для добавления в массив элементов нового элемента
         * Элемент добавляется только в конец массива.
         */
        public static void AddItemToArray<T>(ref T[] itemsArray, T newItem)
        {
            if (itemsArray is null)
            {
                itemsArray = new T[] { };
            }

            Array.Resize<T>(ref itemsArray, itemsArray.Length + 1);
            itemsArray[itemsArray.Length - 1] = newItem;
        }


        /* Метод для добавления в массив элементов нового элемента
         * Элемент добавляется в массив по индексу
         * Часть массива сдвигается на один от заднного индекса
         */
        public static void AddItemToArray<T>(ref T[] itemsArray, T newItem, int index)
        {
            // получить элементы от заданного индекса включительно
            T[] tempArray = new T[itemsArray.Length - index];
            Array.Copy(itemsArray, index, tempArray, 0, tempArray.Length);
            // увеличение длины массива на 1
            Array.Resize(ref itemsArray, itemsArray.Length + 1);
            // и перезапись заданного по индексу элемента массива
            itemsArray[index] = newItem;
            // запись в исходный массив из временного
            Array.Copy(tempArray, 0, itemsArray, index + 1, tempArray.Length);
        }

        #endregion


        #region МЕТОДЫ УДАЛЕНИЯ ЭЛЕМЕНТОВ ИЗ МАССИВА

        /* метод удаления элемента из массива
         * массив укорачивается на один элемент
         */
        public static void RemoveItemFromArray<T>(ref T[] itemsArray, T arrayItem)
        {
            int index = Array.IndexOf(itemsArray, arrayItem);
            RemoveItemFromArray(ref itemsArray, index);
        }


        /* перегрузка метода - удаляется элемент по индексу
         * массив укорачивается на один элемент
         */
        public static void RemoveItemFromArray<T>(ref T[] itemsArray, int index)
        {
            if (index >= itemsArray.Length) return;
            // получить элементы от заданного индекса, исключая элемент по индексу
            T[] tempArray = new T[itemsArray.Length - index - 1];
            Array.Copy(itemsArray, index + 1, tempArray, 0, tempArray.Length);
            // уменьшение длины массива на 1
            Array.Resize(ref itemsArray, itemsArray.Length - 1);
            // запись в исходный массив из временного
            Array.Copy(tempArray, 0, itemsArray, index, tempArray.Length);
        }


        /*Метод для удаления элементы из массива
         * Случай упрощённый, удаляются только элементы из конца массива
         */
        [Obsolete]
        public static void RemoveItemFromArray<T>(ref T[] itemsArray)
        {
            if (itemsArray.Length > 0)
                Array.Resize<T>(ref itemsArray, itemsArray.Length - 1);
        }


        /*Метод для удаления заданного элемента из массива*/
        [Obsolete]
        public static void RemoveItemFromArrayVar<T>(ref T[] itemsArray, T arrayItem)
        {
            bool itemExists = Array.Exists(itemsArray, i => i.GetHashCode() == arrayItem.GetHashCode());

            if (itemExists)
            {
                int indexToDelete = Array.IndexOf<T>(itemsArray, arrayItem);
                int swipeLength = itemsArray.Length - 1 - indexToDelete;

                for (int i = indexToDelete; i <= itemsArray.Length - 1; i++)
                {
                    if (i < itemsArray.Length - 1)
                        itemsArray[i] = itemsArray[i + 1];
                }

                Array.Resize<T>(ref itemsArray, itemsArray.Length - 1);
            }
        }
        #endregion
    }
}
