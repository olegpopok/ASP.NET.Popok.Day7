using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task3.Library
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private const int _DefaultCapasity = 4;

        private T[] _array;
        private int _size;
        private int _head;
        private int _tail;
        private int _version;

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
            _version = 0;

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
            _version++;
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
            _version++;
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

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        private T GetElement(int index)
        {
            return _array[(_head + index) % _array.Length];
        }

        public class Enumerator : IEnumerator<T>, System.Collections.IEnumerator
        {
            private CustomQueue<T> _queue;
            private int _index;
            private T _currentElement;
            private int _version;

            internal Enumerator(CustomQueue<T> queue)
            {
                _queue = queue;
                _version = _queue._version;
                _index = -1;
                _currentElement = default(T);

            }

            void IDisposable.Dispose()
            {
                _index = -2;
                _currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (_version != _queue._version)
                {
                    throw new InvalidOperationException("Enumerator version feiled.");
                }
                if (_index == -2)
                {
                    return false;
                }
                _index++;

                if (_index == _queue._size)
                {
                    return false;
                }

                _currentElement = _queue.GetElement(_index);
                return true;
            }

            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        if(_index == -1)
                        {
                            throw new InvalidOperationException("Enum not started.");
                        }
                        else
                        {
                            throw new InvalidOperationException("Enum ended.");
                        }
                    }

                    return _currentElement;
                }
            }

            public void Reset()
            {
                if(_version != _queue._version)
                {
                    throw new InvalidOperationException("Enumerator version feiled.");
                }
                _index = -1;
                _currentElement = default(T);
            }
        }
    }
}
