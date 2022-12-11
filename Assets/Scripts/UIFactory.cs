using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIFactory<T> : PlaceholderFactory<T> where T : Component
{
    [Inject] private UICanvas _uiCanvas;

    public override T Create()
    {
        var instance = base.Create();

        instance.transform.SetParent(_uiCanvas.transform, false);

        return instance;
    }
}
