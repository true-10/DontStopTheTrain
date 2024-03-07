using System.Collections.Generic;

namespace DontStopTheTrain.Events
{
    public class EventViewersManager
    {
        public IReadOnlyCollection<AbstractEventViewer> Viewers => _viewers.AsReadOnly();

        public List<AbstractEventViewer> _viewers = new();

        public bool TryToAddViewer(AbstractEventViewer newViewer)
        {
            if (_viewers.Contains(newViewer))
            {
                return false;
            }
            _viewers.Add(newViewer);
            return true;
        }

        public bool TryToRemoveViewer(AbstractEventViewer newViewer)
        {
            if (_viewers.Contains(newViewer) == false)
            {
                return false;
            }
            _viewers.Remove(newViewer);
            return true;
        }
    }
}
