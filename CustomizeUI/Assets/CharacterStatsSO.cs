using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 51)]
public class CharacterStatsSO : ScriptableObject
{
    [SerializeField] GameObject[] _player;
    [SerializeField] public int Gold;
    [SerializeField] public int currentPlayer;

}
