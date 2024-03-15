using DontStopTheTrain;
using DontStopTheTrain.Events;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "InventoryScriptableInstaller", menuName = "DST/DI/Installers/InventoryScriptableInstaller")]
public class InventoryScriptableInstaller : ScriptableObjectInstaller<InventoryScriptableInstaller>
{
    [SerializeField]
    private ItemsStaticStorage _itemsStaticStorage;
    public override void InstallBindings()
    {
        Container.Bind<ItemsStaticStorage>().FromScriptableObject(_itemsStaticStorage).AsSingle();        
        //Container.Bind<ItemsManager>().AsSingle();
        Container.Bind<Inventory>().AsSingle();
    }
}