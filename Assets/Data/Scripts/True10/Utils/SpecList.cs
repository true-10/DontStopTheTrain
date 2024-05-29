using System.Collections.Generic;

namespace True10.Utils
{
    public class SpecList<T>
    {
        private int _currentIndex = 0;
        private List<T> _items;

        public void SetItems(List<T> items)
        {
            _items = items;
        }

        public T GetNextItem()
        {
            if (IsItemAvailable())
            {
                _currentIndex++;
                SetCurrentItem();
            }
            return _items[_currentIndex];
        }

        public T GetPrevItem()
        {
            if (IsItemAvailable())
            {
                _currentIndex--;
                SetCurrentItem();
            }
            return _items[_currentIndex];

        }

        private bool IsItemAvailable()
        {
            if (_items == null || _items.Count < 2)
            {
                return false;
            }

            return true;
        }
        private void SetCurrentItem()
        {
            _currentIndex = Clamp(_currentIndex, _items.Count);
        }

        private int Clamp(int index, int max)
        {
            if (index < 0)
            {
                return max - 1;
            }
            if (index > max - 1)
            {
                return 0;
            }
            return index;
        }
    }
}
