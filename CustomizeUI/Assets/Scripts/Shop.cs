using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] List<int> _currentGold;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI purchasedGoldText;
    [SerializeField] CharacterStatsSO characterStatsSO;

    void Start()
    {
        goldText.text = characterStatsSO.Gold.ToString();
        //  print(Toplam());
    }

    public void UpdateGold(bool isAdding, int amount, string name)
    {
        if (isAdding)
        {
            _currentGold.Add(amount);
            //print(Toplam() + "   " + name);
        }
        else
        {
            _currentGold.Remove(amount);
        }

        purchasedGoldText.text = Toplam().ToString();
    }
    public void ConfirmPurchase()
    {
        if (characterStatsSO.Gold >= Toplam())
        {
            characterStatsSO.Gold -= Toplam();
            purchasedGoldText.text = Toplam().ToString();

            goldText.text = characterStatsSO.Gold.ToString();
            ResetCurrentGold();
        }
        else { Debug.Log("yetersiz"); }
    }
    public int Toplam()
    {
        int x = 0;
        foreach (var item in _currentGold)
        {
            x += item;
            print(item);
        }
        return x;
    }
    public void ResetCurrentGold()
    {
        _currentGold.Clear();
        purchasedGoldText.text = Toplam().ToString();
    }
}
