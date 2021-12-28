using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum ItemType { Item, Weapon, Armor }
    public ItemType itemType;

    public string itemName, itemDescription;
    public int valueInCoins;
    public Sprite itemsImage;

    public int amountOfAffect;
    public enum AffectType { HP, Mana }
    public AffectType affectType;

    public int weaponDexterity;
    public int weaponDefence;

    public bool isStackable;
    public int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddItemManager(this);
            //gameObject.SetActive(false);
            SelfDestroy();
        }
    }

    public void SelfDestroy()
    {
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        if (itemType == ItemType.Item)
        {
            if (affectType == AffectType.HP)
            {
                PlayerStats.instance.AddHP(amountOfAffect);
            } else if (affectType == AffectType.Mana)
            {
                PlayerStats.instance.AddMana(amountOfAffect);
            }
        }
    }
}
