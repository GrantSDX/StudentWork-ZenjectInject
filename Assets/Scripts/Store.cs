using System.Collections;
using UnityEngine;
using Zenject;

public class Store : MonoBehaviour
{
    [Inject] private LootBox.Factory _lootBoxFactory;
    [Inject] private UICanvas _uiCanvas;

    private void Awake()
    {
        transform.SetParent(_uiCanvas.transform, false);
    }

    [ContextMenu("Create LootBox")]
    
    private void CreateLootBox()
    {
        var box =_lootBoxFactory.Create();
        box.transform.SetParent(transform);


    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            CreateLootBox();
    }
}
    