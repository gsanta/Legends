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
}
