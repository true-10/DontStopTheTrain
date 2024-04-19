
using True10.Characters;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour, IMovable
{
    //  [SerializeField]
    //private InputReader inputReader;
    [SerializeField]
    private float maxHp = 100f;
   // [SerializeField, Range(0f, 1f)]
   // private float armor = 1f;


    protected Rigidbody cachedRigidbody;
    protected Transform cachedTransform;

    //private IMovable movement;
    [SerializeField]
    //private MovementVelocityBased movement;
    private MovementCharacterControlBased movement;

    //  private TankWeapon currentWeapon;

    // public void SetWeapon(TankWeapon newWeapon) => currentWeapon = newWeapon;

    public void Start()
    {
        //movement = new PhysicsBasedMovement();
        //currentWeapon = weaponSwitcher.GetCurrentWeapon();
        //currentHp = maxHp;
    }

    public void Move(Vector3 direction)
    {
        movement.Move(direction);
        ///animator.SetFloat("Movement", direction.z);
    }

    public void Rotate(Vector3 angles)
    {
        movement.Rotate(angles);
    }

  /*  public override void Attack()
    {
        currentWeapon.Attack();
    }

    public override void Die()
    {
        //spawnFx
        Destroy(gameObject);
        base.Die();
    }

    protected override float GetArmorValue() => 1f - armor;
    public void SwitchWeaponToNext() => weaponSwitcher.SwitchToNext((weapon) => SetWeapon(weapon));
    
    public void SwitchWeaponToPrevious() => weaponSwitcher.SwitchToPrevious((weapon) => SetWeapon(weapon));*/
}
