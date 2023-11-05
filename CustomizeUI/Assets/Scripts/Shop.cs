using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO;

    [SerializeField] int _currentGold;
    [SerializeField] TextMeshProUGUI _textGold;
    [SerializeField] TextMeshProUGUI _textGold2;
    void Start()
    {
        _textGold.text = _playerSO.Gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyItem(bool x, int y)
    {
        if (x)
        {
            _currentGold += y;
  
            _textGold2.text = _currentGold.ToString();
        }
        if (!x)
        {
            _currentGold -= y;
      
            _textGold2.text = _currentGold.ToString();
        }
    }
    public void BuyItemC(int x)
    {
        if (_playerSO.Gold >= x)
        {
            _playerSO.Gold -= _currentGold;
            _currentGold = 0;
            _textGold2.text = _currentGold.ToString();
            _textGold.text = _playerSO.Gold.ToString();
        }
    }
}
