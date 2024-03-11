namespace DontStopTheTrain.Events
{
    /// <summary>
    /// камнепад
    /// достопримечательность
    /// комета
    /// затмение
    /// 
    /// 
    /// </summary>
    public class ViewEventViewer : AbstractEventViewer
    {
        public override EventType Type => EventType.View;

        protected override void OnCompleteEvent(IEvent eventData)
        {

        }

        protected override void OnStartEvent(IEvent eventData)
        {

        }
    }
}
