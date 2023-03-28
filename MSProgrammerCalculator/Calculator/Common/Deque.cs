using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Deque<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
    {
        public int Count => _deque.Count;

        object ICollection.SyncRoot => _syncRoot == null ? Interlocked.CompareExchange<object>(ref _syncRoot, new object(), (object)null) : _syncRoot;

        bool ICollection.IsSynchronized => false;

        [NonSerialized]
        private object _syncRoot;

        private readonly LinkedList<T> _deque;

        public Deque() 
        {
            _deque = new LinkedList<T>();
        }

        public void EnqueueFirst(T item)
        {
            _deque.AddFirst(item);
        }

        public void EnqueueLast(T item)
        {
            _deque.AddLast(item);
        }

        public T DequeueFirst()
        {
            if (_deque.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty.");
            }

            var item = _deque.First.Value;
            _deque.RemoveFirst();
            return item;
        }

        public T DequeueLast()
        {
            if (_deque.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty.");
            }

            var item = _deque.Last.Value;
            _deque.RemoveLast();
            return item;
        }

        public void Clear()
        {
            _deque.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _deque.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
