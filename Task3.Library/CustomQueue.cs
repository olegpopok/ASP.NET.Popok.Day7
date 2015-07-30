using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public class CustomQueue<T>
    {
        private const int _DefaultCapasity = 4;

        private T[] _array;
        private int _size;
        private int _head;
        private int _tail;

        public CustomQueue()
        {
            _array = new T[0];
        }

        public CustomQueue(int capasity)
        {
            _array = new T[capasity];
            _size = 0;
            _head = 0;
            _tail = 0;
        }

        public CustomQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            _array = new T[_DefaultCapasity];
            _size = 0;

            foreach (T item in collection)
            {
                EnQueue(item);
            }
        }

        public int Count 
        { 
            get { return _size; } 
        }

        public void EnQueue(T item)
        {
            if (_size == _array.Length)
            {
                int newCapasity = (int)((long)_array.Length * (long)2);
                if (newCapasity < _array.Length + _DefaultCapasity)
                {
                    newCapasity = _array.Length + _DefaultCapasity;
                }
                SetCapasity(newCapasity);
            }
            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            _size++;
        }

        public T DeQueue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T removed = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            _size--;
            return removed;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _array[_head];
        }

        private void SetCapasity(int capasity)
        {
            T[] newArray = new T[capasity];
            if (_size > 0)
            {
                if (_size > 0)
                {
                    if (_head < _tail)
                    {
                        Array.Copy(_array, _head, newArray, 0, _size);
                    }
                    else
                    {
                        Array.Copy(_array, _head, newArray, 0, _array.Length - _head);
                        Array.Copy(_array, 0, newArray, _array.Length - _head, _tail);
                    }
                }
            }
            _array = newArray;
            _head = 0;
            _tail = _size;
        }
        
    }
}
