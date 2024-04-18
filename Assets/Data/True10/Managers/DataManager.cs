using System;
using System.Collections.Generic;
using True10.Interfaces;

namespace True10.Managers
{
    public abstract class DataManager<T> : IGameLifeCycle
    {
        public Action<T> OnItemAdded { get; set; }
        public Action<T> OnItemRemoved { get; set; }

        public IReadOnlyCollection<T> Items => _items;

        protected List<T> _items = new();

        public abstract void Initialize();
        public abstract void Dispose();

        public virtual bool TryToAdd(T newItem)
        {
            if (_items.Contains(newItem))
            {
                UnityEngine.Debug.Log($"Item {typeof(T).Name} already added ");
                return false;
            }
            _items.Add(newItem);
            OnItemAdded?.Invoke(newItem);
            return true;
        }

        public virtual bool TryToRemove(T itemToRemove)
        {
            if (_items.Contains(itemToRemove) == false)
            {
                return false;
            }
            _items.Remove(itemToRemove);
            OnItemRemoved?.Invoke(itemToRemove);
            return true;
        }

        public void Clear()
        {
            _items.Clear();
            _items = null;
        }
    }
}
