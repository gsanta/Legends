using UnityEngine;

public class ItemsButton : MonoBehaviour
{
    public ItemManager itemOnButton;

    public void Press()
    {
        MenuManager.instance.itemName.text = itemOnButton.itemName;
        MenuManager.instance.itemDescription.text = itemOnButton.itemDescription;

        MenuManager.instance.activeItem = itemOnButton;
    }
}
