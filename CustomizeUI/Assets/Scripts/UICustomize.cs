using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomize : MonoBehaviour
{
    [SerializeField] private GameObject[] GameObjects;
    [SerializeField] private PlayerSO _PlayerSO;
    [SerializeField] private Shop _shop;
    [SerializeField] private ObjectType _type;
    private bool isButtonLocked = false;
    [SerializeField] Button btnNext;
    [SerializeField] Button btnBack;
    [SerializeField] Button btnBuy;

    private int current = 0;
    private int gold = 999999;

    private void OnEnable()
    {

        if (_shop == null)
            return;

        _shop.ResetCurrentGold();
        print("OnEnable");
    }
    private void Awake()
    {

        current = _PlayerSO.DenemeGet(_type);
        SetActiveCharacter(current);
    }
    private void Start()
    {
        if (btnNext == null)
            return;

        btnNext.onClick.AddListener(NextUI);
        btnBack.onClick.AddListener(BackUI);
        btnBuy.onClick.AddListener(BtnBuy);
    }
    public void NextUI()
    {
        if (isButtonLocked) return;
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
                _shop.UpdateGold(false, currentCharacterPrice, name);
            }
            if (!GameObjects[nextCharacterIndex].GetComponent<FeaturesGameObject>().GameObjectSO()._available)
            {
                _shop.UpdateGold(true, nextCharacterPrice, name);
            }

            SetActiveCharacter(nextCharacterIndex);
            PlayerSave();
        }
    }

    public void BackUI()
    {
        if (isButtonLocked) return;
        StartCoroutine(UnlockButtonAfterDelay());
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
                _shop.UpdateGold(false, currentCharacterPrice, gameObject.name);
            }
            if (!GameObjects[previousCharacterIndex].GetComponent<FeaturesGameObject>().GameObjectSO()._available)
            {
                _shop.UpdateGold(true, previousCharacterPrice, gameObject.name);
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
        if (isButtonLocked) return;
        StartCoroutine(UnlockButtonAfterDelay());
        StartCoroutine(UnlockButtonAfterDelay());
        if ((_PlayerSO.Gold < GetCharacterPrice(current)) || !IsCharacterAvailable(current) || IsCharacterAvailable2(current))
        {
            return;
        }

        int characterPrice = GetCharacterPrice(current);
        _shop.ConfirmPurchase();
        SetCharacterAvailable(current, true);
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
        if (!IsCharacterAvailable2(current))
            return;

        _PlayerSO.DenemeSet(_type, current);
    }
    private IEnumerator UnlockButtonAfterDelay()
    {
        yield return new WaitForSeconds(0.3f); // Ýþlemden sonra belirli bir süre sonra butonu etkinleþtir
        isButtonLocked = false;
    }
}
