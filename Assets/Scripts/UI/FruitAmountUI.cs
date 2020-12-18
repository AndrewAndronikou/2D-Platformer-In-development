using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitAmountUI : MonoBehaviour
{
    [SerializeField] Text fruitAmountText;

    public FruitCurrency.FruitType fruitType;

    void Update()
    {
        switch (fruitType)
        {
            case FruitCurrency.FruitType.Apple:
                fruitAmountText.text = PlayerStats.Apple.ToString();
                break;
            case FruitCurrency.FruitType.Kiwi:
                fruitAmountText.text = PlayerStats.Kiwi.ToString();
                break;
            case FruitCurrency.FruitType.Bananas:
                fruitAmountText.text = PlayerStats.Bananas.ToString();
                break;
            case FruitCurrency.FruitType.Cherries:
                fruitAmountText.text = PlayerStats.Cherries.ToString();
                break;
            case FruitCurrency.FruitType.Melon:
                fruitAmountText.text = PlayerStats.Melon.ToString();
                break;
            case FruitCurrency.FruitType.Orange:
                fruitAmountText.text = PlayerStats.Orange.ToString();
                break;
            case FruitCurrency.FruitType.Pineapple:
                fruitAmountText.text = PlayerStats.Pineapple.ToString();
                break;
            case FruitCurrency.FruitType.Strawberry:
                fruitAmountText.text = PlayerStats.Strawberry.ToString();
                break;
        }
    }
}
