using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    private bool canOpenShop;

    [SerializeField]
    private List<ItemManager> itemsForSale;


    void Update()
    {
        if (canOpenShop && Input.GetButtonDown("Fire1") && !Player.instance.isMovementDeactivated && 
            !ShopManager.instance.shopMenu.activeInHierarchy)
        {
            ShopManager.instance.itemsForSale = itemsForSale;
            ShopManager.instance.OpenShopMenu();
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpenShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpenShop = false;
        }
    }
}
