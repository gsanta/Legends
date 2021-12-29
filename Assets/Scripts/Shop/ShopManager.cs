using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public GameObject shopMenu, buyPanel, sellPanel;

    [SerializeField]
    private TextMeshProUGUI currentBitCoinText;

    public List<ItemManager> itemsForSale;

    [SerializeField]
    private GameObject itemButton;
    [SerializeField]
    private Transform buyItemsContainerParent;
    [SerializeField]
    private Transform sellItemsContainerParent;

    void Start()
    {
        instance = this;    
    }

    public void OpenShopMenu()
    {
        shopMenu.SetActive(true);
        GameManager.instance.shopOpen = true;
        currentBitCoinText.text = "BTC: " + GameManager.instance.currentBitcoins;
        buyPanel.SetActive(true);
    }

    public void CloseShopMenu() 
    {
        shopMenu.SetActive(false);
        GameManager.instance.shopOpen = false;
    }

    public void OpenBuyPanel()
    {
        buyPanel.SetActive(true);
        sellPanel.SetActive(false);

        UpdateItemsInShop(buyItemsContainerParent, itemsForSale);
    }

    public void OpenSellPanel()
    {
        buyPanel.SetActive(false);
        sellPanel.SetActive(true);

        UpdateItemsInShop(sellItemsContainerParent, Inventory.instance.GetItemManagerList());
    }

    private void UpdateItemsInShop(Transform itemsContainerParent, List<ItemManager> items)
    {
        foreach (Transform transform in itemsContainerParent)
        {
            Destroy(transform.gameObject);
        }

        foreach (ItemManager item in items)
        {
            RectTransform itemSlot = Instantiate(itemButton, itemsContainerParent).GetComponent<RectTransform>();
            Image itemImage = itemSlot.Find("Items Image").GetComponent<Image>();
            itemImage.sprite = item.itemsImage;
            TextMeshProUGUI amountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();
            amountText.text = "";

            itemSlot.GetComponent<ItemsButton>().itemOnButton = item;
        }
    }
}
