using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections
{
    public partial class MyList<T> : IListTools<T>, IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>
    {


        #region Реализация интерфейсов IEnumerable и IEnumerable<T>       

        // почему эта реализация метода из IEnumerator не может иметь модификаторы - ни public, ни private
        // ПОЧИТАТЬ ЕЩЁ ПРО ИНТЕРФЕЙСЫ И РЕАЛИЗАЦИЮ ОДНОИМЕННЫХ МЕТОДОВ
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return this as IEnumerator<T>;
        }

        #endregion

        //
        //
        //

        #region Реализация интерфейсов IEnumerator и IEnumerator<T>
        
        int position = -1;

        /* с методами MoveNext и Reset нет никаких вопросов -
         * простейшая реализация из материалов уроков
         */
        public bool MoveNext()
        {
            if(position < itemsArray.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        /* вижу, что в классе List<T> от Microsoft есть подкласс Enumerator
         * в нём нет реализации свойства Current
         * от меня же редактор, что естественно, требует реализации обоих интерфейсов, полностью
         * не понимаю
         *  
         */

        // почему эта реализация свойства из IEnumerator не может иметь модификаторы - ни public, ни private
        object IEnumerator.Current { get { return itemsArray[position]; } }
        
        public T Current { get { return itemsArray[position]; } }

        #endregion

        //
        //
        //

        #region Реализация интерфейса IDisposable из IEnumerator<T>

        public void Dispose()
        {
            /* почитать на будущее, а пока хз что с этим делать
             * https://docs.microsoft.com/ru-ru/dotnet/standard/garbage-collection/implementing-dispose
             */
        }

        #endregion
    }
}
