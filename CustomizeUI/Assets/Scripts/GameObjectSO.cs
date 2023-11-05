using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Object", menuName = "ScriptableObjects/GameObject", order = 51)]
public class GameObjectSO : ScriptableObject
{
    [SerializeField] public GameObject _gameObject;
    [SerializeField] int _id;
    [SerializeField] string _name;
    [SerializeField] ObjectType _objectType;
    [SerializeField] public int _price;
    [SerializeField] public bool _available;
    [SerializeField] public bool discovered;


    public void Buy()
    {
        _available = true;
        Debug.Log(_available);
    }


}
