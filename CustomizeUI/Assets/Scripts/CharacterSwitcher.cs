using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] playerCharacters;
    int currentCharacterIndex;
    [SerializeField] CharacterStatsSO _characterStatsSO;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    public Shop shop;

    private void Start()
    {
        currentCharacterIndex = _characterStatsSO.currentPlayer;
        //   SetActiveCharacter(currentCharacterIndex);

        nextButton.onClick.AddListener(NextCharacter);
        previousButton.onClick.AddListener(PreviousCharacter);
    }

    private void NextCharacter()
    {
        if (currentCharacterIndex < playerCharacters.Length - 1)
        {
            SetActiveCharacter(currentCharacterIndex, false);
            currentCharacterIndex++;
            shop.ResetCurrentGold();
            _characterStatsSO.currentPlayer = currentCharacterIndex;
            SetActiveCharacter(currentCharacterIndex, true);
        }
    }

    private void PreviousCharacter()
    {
        if (currentCharacterIndex > 0)
        {
            SetActiveCharacter(currentCharacterIndex, false);
            currentCharacterIndex--;
            shop.ResetCurrentGold();
            _characterStatsSO.currentPlayer = currentCharacterIndex;
            SetActiveCharacter(currentCharacterIndex, true);
        }
    }

    private void SetActiveCharacter(int index, bool isActive = true)
    {
        if (index >= 0 && index < playerCharacters.Length)
        {
            playerCharacters[index].SetActive(isActive);
        }
    }

}
