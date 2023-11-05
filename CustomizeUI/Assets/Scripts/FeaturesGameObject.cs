using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeaturesGameObject : MonoBehaviour
{
    [SerializeField] GameObjectSO _gameObjectSO;

    public GameObjectSO GameObjectSO()
    {
        return _gameObjectSO;
    }
}
