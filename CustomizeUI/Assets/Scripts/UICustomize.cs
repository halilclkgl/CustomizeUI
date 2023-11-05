using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomize : MonoBehaviour
{
    [SerializeField] private GameObject[] GameObjects;
    [SerializeField] private PlayerSO _PlayerSO;
    [SerializeField] private Shop _shop;
    [SerializeField] private ObjectType _type;

    private int current = 0;
    private int gold = 999999;

    private void Awake()
    {
        current = _PlayerSO.DenemeGet(_type);
        SetActiveCharacter(current);
    }

    public void NextUI()
    {
        int nextCharacterIndex = current + 1;
        if (nextCharacterIndex < GameObjects.Length)
        {
            if (!IsCharacterAvailable(nextCharacterIndex))
            {
                return;
            }

            int currentCharacterPrice = GameObjects[current].GetComponent<FeaturesGameObject>().GameObjectSO()._price;
            int nextCharacterPrice = GameObjects[nextCharacterIndex].GetComponent<FeaturesGameObject>().GameObjectSO()._price;
            if (!GameObjects[current].GetComponent<FeaturesGameObject>().GameObjectSO()._available)
            {
                _shop.BuyItem(false, currentCharacterPrice);
            }
            if (!GameObjects[nextCharacterIndex].GetComponent<FeaturesGameObject>().GameObjectSO()._available)
            {
                _shop.BuyItem(true, nextCharacterPrice);
            }

            SetActiveCharacter(nextCharacterIndex);
            PlayerSave();
        }
    }

    public void BackUI()
    {
        int previousCharacterIndex = current - 1;
        if (previousCharacterIndex >= 0)
        {
            if (!IsCharacterAvailable(previousCharacterIndex))
            {
                return;
            }

            int currentCharacterPrice = GameObjects[current].GetComponent<FeaturesGameObject>().GameObjectSO()._price;
            int previousCharacterPrice = GameObjects[previousCharacterIndex].GetComponent<FeaturesGameObject>().GameObjectSO()._price;

            if (!GameObjects[current].GetComponent<FeaturesGameObject>().GameObjectSO()._available)
            {
                _shop.BuyItem(false, currentCharacterPrice);
            }
            if (!GameObjects[previousCharacterIndex].GetComponent<FeaturesGameObject>().GameObjectSO()._available)
            {
                _shop.BuyItem(true, previousCharacterPrice);
            }
            // _shop.BuyItem(false, currentCharacterPrice);
            SetActiveCharacter(previousCharacterIndex);
            //_shop.BuyItem(true, previousCharacterPrice);
            PlayerSave();
        }
    }

    public void SavePlayer()
    {
        if (IsCharacterAvailable2(current))
        {
            _PlayerSO.DenemeSet(_type, current);
        }

    }
    public void BtnBuy()
    {
        if ((_PlayerSO.Gold > GetCharacterPrice(current)) && IsCharacterAvailable(current) && !IsCharacterAvailable2(current))
        {
            return;
        }

        int characterPrice = GetCharacterPrice(current);
        _shop.BuyItemC(characterPrice);
        print("asdasdas");
        SetCharacterAvailable(current, true);
        Debug.Log(gold);
        PlayerSave();
    }

    private bool IsCharacterAvailable(int index)
    {
        return GameObjects[index].GetComponent<FeaturesGameObject>().GameObjectSO().discovered;
    }
    private bool IsCharacterAvailable2(int index)
    {
        return GameObjects[index].GetComponent<FeaturesGameObject>().GameObjectSO()._available;
    }

    private int GetCharacterPrice(int index)
    {
        return GameObjects[index].GetComponent<FeaturesGameObject>().GameObjectSO()._price;
    }

    private void SetCharacterAvailable(int index, bool available)
    {
        GameObjects[index].GetComponent<FeaturesGameObject>().GameObjectSO()._available = available;
    }

    private void SetActiveCharacter(int index)
    {
        if (current >= 0 && current < GameObjects.Length)
        {
            GameObjects[current].SetActive(false);
        }

        GameObjects[index].SetActive(true);
        current = index;
    }

    private void PlayerSave()
    {
        _PlayerSO.DenemeSet(_type, current);
    }
}
