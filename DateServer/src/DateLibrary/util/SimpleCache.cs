using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;

namespace drules.dates.library.util
{
    /// <summary>
    /// Simple generic cache
    /// </summary>
    /// <typeparam name="TK"></typeparam>
    /// <typeparam name="TV"></typeparam>
    public class SimpleCache<TK,TV>
    {
        public delegate IDateRule MissingItemHandler(TK key);

        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private readonly IDictionary<TK, TV> _map;
        private readonly LinkedList<TK> _queue = new LinkedList<TK>();
        private readonly int _size;
        private readonly MissingItemHandler _handler;

        public SimpleCache(int size, MissingItemHandler handler)
        {
            _map = new Dictionary<TK, TV>(size);
            _size = size;
            _handler = handler;
        }

        public TV GetValue(TK key)
        {
            TV result;

            _lock.EnterUpgradeableReadLock();
            try
            {
                if (!_map.TryGetValue(key, out result))
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        if (_queue.Count == _size)
                        {
                            LinkedListNode<TK> node = _queue.First;

                            _map.Remove(node.Value);
                            _queue.Remove(node);
                        }

                        result = (TV) _handler.Invoke(key);
                        _map.Add(key, result);
                        _queue.AddLast(key);                        
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }
            } finally
            {
                _lock.ExitUpgradeableReadLock();
            }

            return result;
        }
    }
}
