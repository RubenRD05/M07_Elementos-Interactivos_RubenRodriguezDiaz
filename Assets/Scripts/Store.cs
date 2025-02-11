using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
 public ItemScriptableObjects Item1, Item2;
 public Image Image1, Image2;
 public TextMeshProUGUI textItem1, textItem2;
 public Button Buy1, Buy2;

 void OnEnable() 
 {
    Image1.sprite = Item1.image;
    Image2.sprite = Item2.image;
    CheckIfCanBuy(Item1, textItem1, Buy1);
    CheckIfCanBuy(Item2, textItem2, Buy2);
 }

 public void BuyItem1()
 {
    GameManager.gameManager.ItemCollected(Item1.image, 4);
    GameManager.gameManager.CoinCollected(-Item1.price);
    CheckIfCanBuy(Item1, textItem1, Buy1);
    CheckIfCanBuy(Item2, textItem2, Buy2);
 }
 public void BuyItem2()
 {
    GameManager.gameManager.ItemCollected(Item2.image, 5);
    GameManager.gameManager.CoinCollected(-Item2.price);
    CheckIfCanBuy(Item1, textItem1, Buy1);
    CheckIfCanBuy(Item2, textItem2, Buy2);
 }
 private void CheckIfCanBuy(ItemScriptableObjects item, TextMeshProUGUI INSUCoins, Button buyButton)
 {
    if (GameManager.gameManager.Coins >= item.price)
    {
        INSUCoins.text = "" + item.price;
        INSUCoins.color = Color.yellow;
        buyButton.interactable = true;
    }
    else
    {
        INSUCoins.text = "Insuficient Coins:" + item.price;
        INSUCoins.color = Color.red;
        buyButton.interactable = false;  
    }
 }
}
