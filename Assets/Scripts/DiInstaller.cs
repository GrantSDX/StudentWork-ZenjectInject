using UnityEngine;
using Zenject;

public class DiInstaller : MonoInstaller
{

    [SerializeField] private UICanvas uiCanvas;
    [SerializeField] private LootBox lootBox;
    [SerializeField] private Store store;

    public override void InstallBindings()
    {
        BindUICanvas(); 
        BindLootBoxFactory();
        BindStore();
    }


    private void BindUICanvas()
    {
        var canvas = Container.InstantiatePrefabForComponent<UICanvas>(uiCanvas);
        Container
            .Bind<UICanvas>()
            .FromInstance(canvas)
            .AsSingle();

    }

    private void BindLootBoxFactory()
    {
        Container
            .BindFactory<LootBox, LootBox.Factory>()
            .FromComponentInNewPrefab(lootBox)
            .AsSingle();
    }

    private void BindStore()
    {
        var storeOnScene = Container.InstantiatePrefabForComponent<Store>(store);
        Container
            .Bind<Store>()
            .FromInstance(storeOnScene)
            .AsCached();
    }
}