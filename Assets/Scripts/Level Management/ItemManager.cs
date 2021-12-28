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

    public void UseItem(int characterToUseOn)
    {
        PlayerStats selectedCharacter = GameManager.instance.GetPlayerStats()[characterToUseOn];

        if (itemType == ItemType.Item)
        {
            if (affectType == AffectType.HP)
            {
                selectedCharacter.AddHP(amountOfAffect);
            } else if (affectType == AffectType.Mana)
            {
                selectedCharacter.AddMana(amountOfAffect);
            }
        } else if (itemType == ItemType.Weapon) 
        {
            if (selectedCharacter.equippedWeaponName != "")
            {
                Inventory.instance.AddItemManager(selectedCharacter.equipedWeapon);
            }

            selectedCharacter.EquipWeapon(this);
        } else if (itemType == ItemType.Armor) 
        {
            if (selectedCharacter.equippedArmorName != "")
            {
                Inventory.instance.AddItemManager(selectedCharacter.equipedArmor);
            }

            selectedCharacter.EquipArmor(this);
        } 
    }
}
