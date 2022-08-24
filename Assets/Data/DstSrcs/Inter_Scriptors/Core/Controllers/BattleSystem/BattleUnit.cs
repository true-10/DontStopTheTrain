using True10.DamageSystems.Damagables;

namespace Interceptors.BattleSystem
{
    
    public interface ICarRig//??
    {

    }

    public interface IBattleUnit
    {
        IDamagable Damagable { get; }
        //ICarRig CarRig { get; }
    }

    //BattleUnitÑontroller?
    public class BattleUnit : IBattleUnit//, IDamagable
    {
        #region properies
        public IDamagable Damagable => damagable;

        #endregion
        #region vars
        private IDamagable damagable;

        #endregion

        public BattleUnit(IDamagable damagable)
        {
            this.damagable = damagable;
        }
    }
}
