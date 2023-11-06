using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] CharacterStatsSO _characterStatsSO;
    [SerializeField] private GameObject[] playerCharacters;
    int currentCharacterIndex;
    private void Awake()
    {
        currentCharacterIndex = _characterStatsSO.currentPlayer;
        SetActiveCharacter(currentCharacterIndex);

      
    }
    public CharacterStatsSO CharacterStatsSo()
    {
        return _characterStatsSO;
    }

    private void SetActiveCharacter(int index, bool isActive = true)
    {
        if (index >= 0 && index < playerCharacters.Length)
        {
            playerCharacters[index].SetActive(isActive);
        }
    }
}
