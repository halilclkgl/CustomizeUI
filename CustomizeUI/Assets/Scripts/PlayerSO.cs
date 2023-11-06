using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 51)]

public class PlayerSO : ScriptableObject
{
    [Header("General Information")]
    [SerializeField] private string _name;
    [SerializeField] private GameObject _player;

    [Header("Economy")]
    [SerializeField] private int gold;

    [Header("Character Customization")]
    [SerializeField] private int male_00_Head;
    [SerializeField] private int male_01_Eyebrows;

    public string Name { get { return _name; } }
    public GameObject Player { get { return _player; } }
    public void DenemeSet(ObjectType _type, int x)
    {
        if (_type == ObjectType.Male_00_Head)
        {
            male_00_Head = x;
        }
        if (_type == ObjectType.Male_01_Eyebrows)
        {
            male_01_Eyebrows = x;
        }
    }
    public int DenemeGet(ObjectType _type)
    {
        if (_type == ObjectType.Male_00_Head)
        {
            return male_00_Head;
        }
        if (_type == ObjectType.Male_01_Eyebrows)
        {
            return male_01_Eyebrows;
        }
        return 0;
    }
 
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }


}

