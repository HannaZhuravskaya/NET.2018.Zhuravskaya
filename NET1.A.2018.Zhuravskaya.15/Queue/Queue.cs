using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">
    /// Specifies the type of elements in the queue.
    /// </typeparam>
    public class Queue<T> : IEnumerable, IEnumerable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _array;
        private int _head;
        private int _tail;
        private int _capacity;
        private int _size;
        private int _version;

        #region Queue.Constructors

        /// <summary>
        /// Initializes a new instance of the Queue class that is empty and has the default initial capacity.
        /// </summary>
        public Queue() : this(DefaultCapacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Queue class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">
        /// The initial number of elements that the Queue can contain.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// capacity is less than zero.
        /// </exception>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            _capacity = capacity;
            _size = _tail - _head;
            _version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Queue class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied. 
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied to the new Queue.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// collection is null.
        /// </exception>
        public Queue(IEnumerable<T> collection) : this(DefaultCapacity)
        {
            if (collection is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                this.Enqueue(element);
            }
        }

        #endregion

        #region Queue.Properties

        /// <summary>
        /// Gets the number of elements contained in the Queue.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the Queue.
        /// </returns>
        public int Count => _size;

        /// <summary>
        /// Determines whether Queue is empty.
        /// </summary>
        /// <returns>
        /// true if Queue is empty; otherwise, false.
        /// </returns>
        public bool IsEmpty => _size == 0;

        #endregion

        #region Queue.PublicMethods

        /// <summary>
        /// Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="item">
        /// The object to add to the Queue. The value can be null for reference types.
        /// </param>
        public void Enqueue(T item)
        {
            if (_size == _capacity)
            {
                var tempArray = new T[_capacity * 2];
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, tempArray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, tempArray, 0, _size - _tail);
                    Array.Copy(_array, 0, tempArray, _size - _tail, _size - _head);
                }

                _array = tempArray;
                _capacity *= 2;
                _head = 0;
                _tail = _size;
            }

            _array[_tail] = item;
            _tail = (_tail + 1) % _capacity;
            _size++;
            _version++;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>
        /// The object that is removed from the beginning of the Queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The Queue is empty.
        /// </exception>
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }

            T firstElement = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _capacity;

            _size--;
            _version++;
            return firstElement;
        }

        /// <summary>
        /// Copies the Queue elements to an existing one-dimensional System.Array, starting at the specified array index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements copied from Queue. The System.Array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">
        /// The zero-based index in array at which copying begins.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// arrayIndex is less than zero.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The number of elements in the source Queue is greater than the available space from arrayIndex to the end of the destination array.
        /// </exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (arrayIndex + _size > array.Length)
            {
                throw new ArgumentException();
            }

            if (_head < _tail)
            {
                Array.Copy(_array, _head, array, arrayIndex, _size);
            }
            else
            {
                Array.Copy(_array, _head, array, arrayIndex, _size - _tail);
                Array.Copy(_array, 0, array, _size - _tail + arrayIndex, _size - _head);
            }
        }

        /// <summary>
        /// Removes all objects from the Queue.
        /// </summary>
        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_array, _head, _size);
            }
            else
            {
                Array.Clear(_array, _head, _capacity - _head);
                Array.Clear(_array, 0, _tail);
            }

            _head = 0;
            _tail = 0;
            _size = 0;
            _version++;
        }

        /// <summary>
        /// Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="item">
        /// The object to locate in the Queue. The value can be null for reference types.
        /// </param>
        /// <returns>
        /// true if item is found in the Queue; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;

            if (_head < _tail)
            {
                for (int i = _head; i < _tail; ++i)
                {
                    if (equalityComparer.Equals(_array[i], item))
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < _tail; ++i)
                {
                    if (equalityComparer.Equals(_array[i], item))
                    {
                        return true;
                    }
                }

                for (int i = _head; i < _capacity; ++i)
                {
                    if (equalityComparer.Equals(_array[i], item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Copies the Queue elements to a new array.
        /// </summary>
        /// <returns>
        /// A new array containing elements copied from the Queue.
        /// </returns>
        public T[] ToArray()
        {
            var resultArray = new T[_size];
            if (_head < _tail)
            {
                Array.Copy(_array, _head, resultArray, 0, _size);
            }
            else
            {
                Array.Copy(_array, _head, resultArray, 0, _size - _tail);
                Array.Copy(_array, 0, resultArray, _size - _tail, _size - _head);
            }

            return resultArray;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>
        /// The object at the beginning of the Queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The Queue is empty.
        /// </exception>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }

            return _array[_head];
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the Queue, if that number is less than 90 percent of current capacity.
        /// </summary>
        public void TrimExcess()
        {
            if (_capacity * 0.9 > _size)
            {
                var tempArray = new T[_size];
                CopyTo(tempArray, 0);
                _array = tempArray;
                _capacity = _size;
                _head = 0;
                _tail = 0;
                _version++;
            }
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        #endregion

        #region Queue.InterfaceExpliciteImplementations

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Queue.Enumerator

        /// <summary>
        /// Enumerates the elements of a Queue.
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            private readonly Queue<T> _queue;

            private readonly int _version;

            private int _index;

            private int _numberOfIterations;

            /// <summary>
            /// Initializes a new instance of the Queue.Enumerator struct.
            /// </summary>
            /// <param name="queue">
            /// Queue object that will be iterated.
            /// </param>
            public Enumerator(Queue<T> queue)
            {
                _queue = queue;
                _version = queue._version;
                _index = _queue._head - 1;
                _numberOfIterations = 0;
            }

            /// <summary>
            /// Gets the element at the current position of the enumerator.
            /// </summary>
            /// <returns>
            /// The element in the Queue at the current position of the enumerator.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public T Current
            {
                get
                {
                    if (_version != _queue._version)
                    {
                        throw new InvalidOperationException();
                    }

                    return _queue._array[_index];
                }
            }

            object IEnumerator.Current => Current;

            /// <summary>
            /// Releases all resources used by the Queue.Enumerator.
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Advances the enumerator to the next element of the Queue.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public bool MoveNext()
            {
                if (_version != _queue._version)
                {
                    throw new InvalidOperationException();
                }

                if (_numberOfIterations == _queue._size)
                {
                    return false;
                }

                _numberOfIterations++;
                _index = (_index + 1) % _queue._capacity;

                return true;
            }

            void IEnumerator.Reset()
            {
                _index = _queue._head - 1;
                _numberOfIterations = 0;
            }
        }

        #endregion
    }
}