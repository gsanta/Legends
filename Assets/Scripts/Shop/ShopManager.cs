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

    [SerializeField]
    private ItemManager selectedItem;
    [SerializeField]
    private TextMeshProUGUI buyItemName, buyItemDescription, buyItemValue;
    [SerializeField]
    private TextMeshProUGUI sellItemName, sellItemDescription, sellItemValue;

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

    public void SelectedBuyItem(ItemManager item)
    {
        selectedItem = item;
        buyItemName.text = selectedItem.itemName;
        buyItemDescription.text = selectedItem.itemDescription;
        buyItemValue.text = "Value: " + selectedItem.valueInCoins;
    }

    public void SelectedSellItem(ItemManager item)
    {
        selectedItem = item;
        sellItemName.text = selectedItem.itemName;
        sellItemDescription.text = selectedItem.itemDescription;
        sellItemValue.text = "Value: " + (int)(selectedItem.valueInCoins * 0.75);
    }


    public void BuyItem()
    {
        if (GameManager.instance.currentBitcoins >= selectedItem.valueInCoins)
        {
            GameManager.instance.currentBitcoins -= selectedItem.valueInCoins;
            Inventory.instance.AddItemManager(selectedItem);

            currentBitCoinText.text = "BTC: " + GameManager.instance.currentBitcoins;
        }
    }

    public void SellItem()
    {
        if (selectedItem)
        {
            GameManager.instance.currentBitcoins += (int)(selectedItem.valueInCoins * 0.75);
            Inventory.instance.RemoveItem(selectedItem);

            currentBitCoinText.text = "BTC: " + GameManager.instance.currentBitcoins;
            selectedItem = null;

            OpenSellPanel();
        }
    }
}
