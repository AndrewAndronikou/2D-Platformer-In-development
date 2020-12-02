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
        Instantiate(collectedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStats.Score += (int)fruitType;
          //  PlayerStats.FruitAmount 
            Debug.Log(PlayerStats.Score);
            Collected();
        }
    }
}
