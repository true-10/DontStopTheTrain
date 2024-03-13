using System;
using System.Collections.Generic;

namespace True10.Managers
{
    public abstract class DataManager<T>
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
            if (_items.Contains(itemToRemove))
            {
                return false;
            }
            _items.Remove(itemToRemove);
            OnItemRemoved?.Invoke(itemToRemove);
            return true;
        }

        public void Clear()
        {
            foreach (var item in Items)
            {   
                if (item != null)
                {
                    TryToRemove(item);
                }
            }
            _items.Clear();
            _items = null;
        }
    }
}
