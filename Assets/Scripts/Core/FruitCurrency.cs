using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCurrency : MonoBehaviour
{
    [SerializeField] GameObject collectedVFX;

    public enum FruitType   
    { 
        Apple = 5,
        Kiwi = 12,
        Bananas = 4,
        Cherries = 6, 
        Melon = 7,
        Orange = 14,
        Pineapple = 13,
        Strawberry = 15
    }

    public FruitType fruitType;

    void Collected()
    {
        CheckFruitType();
        PlayerStats.Score += (int)fruitType;
        //PlayerStats.FruitTypes += (int)fruitType;
        Instantiate(collectedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }

    void CheckFruitType()
    {
        switch (fruitType)
        {
            case FruitType.Apple:
                PlayerStats.Apple++;
                break;
            case FruitType.Kiwi:
                PlayerStats.Kiwi++;
                break;
            case FruitType.Bananas:
                PlayerStats.Bananas++;
                break;
            case FruitType.Cherries:
                PlayerStats.Cherries++;
                break;
            case FruitType.Melon:
                PlayerStats.Melon++;
                break;
            case FruitType.Orange:
                PlayerStats.Orange++;
                break;
            case FruitType.Pineapple:
                PlayerStats.Pineapple++;
                break;
            case FruitType.Strawberry:
                PlayerStats.Strawberry++;
                break;
        }


        //if (fruitType == FruitType.Apple)
        //{
        //    PlayerStats.Apple++;
        //}
        //if (fruitType == FruitType.Kiwi)
        //{
        //    PlayerStats.Kiwi++;
        //}
        //if (fruitType == FruitType.Bananas)
        //{
        //    PlayerStats.Bananas++;
        //}
        //if (fruitType == FruitType.Cherries)
        //{
        //    PlayerStats.Cherries++;
        //}
        //if (fruitType == FruitType.Melon)
        //{
        //    PlayerStats.Melon++;
        //}
        //if (fruitType == FruitType.Orange)
        //{
        //    PlayerStats.Orange++;
        //}
        //if (fruitType == FruitType.Pineapple)
        //{
        //    PlayerStats.Pineapple++;
        //}
        //if (fruitType == FruitType.Strawberry)
        //{
        //    PlayerStats.Strawberry++;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collected();
        }
    }
}
