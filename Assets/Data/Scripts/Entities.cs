
namespace DontStopTheTrain
{
    public interface IEntity
    {
        int Id { get; }
        int Type { get; }//unit, tool, part
    }

    public interface IEntityFactory
    {
        
    }

    public interface IEntityManager
    {

    }
}
