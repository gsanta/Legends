using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private List<ItemManager> itemManagerList;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        itemManagerList = new List<ItemManager>();
    }

    public List<ItemManager> GetItemManagerList()
    {
        return itemManagerList;
    }
    

    public void AddItemManager(ItemManager itemManager)
    {
        if (itemManager.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (ItemManager manager in itemManagerList)
            {
                if (manager.itemName == itemManager.itemName)
                {
                    manager.amount += itemManager.amount;
                    itemAlreadyInInventory = true;
                }

            }

            if (!itemAlreadyInInventory)
            {
                itemManagerList.Add(itemManager);
            }
        } else
        {
            itemManagerList.Add(itemManager);
        }
    }

    public bool RemoveItem(ItemManager item)
    {
        if (item.isStackable)
        {
            ItemManager inventoryItem = null;

            foreach (ItemManager itemInInventory in itemManagerList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amount -= 1;
                    inventoryItem = itemInInventory;
                }
            }

            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                itemManagerList.Remove(inventoryItem);
                return true;
            }
        } else
        {
            itemManagerList.Remove(item);
            return true;
        }

        return false;
    }
}
