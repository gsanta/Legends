using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    public GameObject menu;
    [SerializeField]
    private GameObject panels;
    [SerializeField]
    private GameObject[] statsButtons;

    public static MenuManager instance;
    [SerializeField]
    private PlayerStats[] playerStats;
    [SerializeField]
    private TextMeshProUGUI[] nameText, hpText, manaText, currentXPText, xpText;
    [SerializeField]
    private Slider[] xpSlider;
    [SerializeField]
    private Image[] characterImage;
    [SerializeField]
    private GameObject[] characterPanel;

    [SerializeField]
    private TextMeshProUGUI statName, statHp, statMana, statDex, statDef, statEquipedWeapon, statEquipedArmor;
    [SerializeField]
    private TextMeshProUGUI statWeaponPower, statArmorDefence;
    [SerializeField]
    private Image characterStatImage;
    [SerializeField]
    private GameObject itemButton;
    [SerializeField]
    private Transform itemsContainer;

    public TextMeshProUGUI itemName, itemDescription;

    public ItemManager activeItem;

    [SerializeField]
    private GameObject characterChoicePanel;
    [SerializeField]
    private TextMeshProUGUI[] itemsCharacterChoiceNames;

    void Start()
    {
        instance = this;

        for (int i = 0; i < characterPanel.Length; i++)
        {
            characterPanel[i].SetActive(false);
        }

        for (int i = 0; i < statsButtons.Length; i++)
        {
            statsButtons[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
                GameManager.instance.gameMenuOpened = false;
            } else
            {
                UpdateStats();
                menu.SetActive(true);
                GameManager.instance.gameMenuOpened = true;
            }
        }
    }

    public void UpdateStats()
    {
        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
        {
            PlayerStats stats = playerStats[i];
            characterPanel[i].SetActive(true);

            nameText[i].text = stats.playerName;
            hpText[i].text = "HP: " + stats.currentHP + "/" + stats.maxHP;
            manaText[i].text = "Mana: " + stats.currentMana + "/" + stats.maxMana;
            currentXPText[i].text = "Current XP: " + stats.currentXP;

            characterImage[i].sprite = playerStats[i].characterImage;

            xpText[i].text = stats.currentXP.ToString() + "/" + stats.xpForNextLevel[stats.playerLevel];
            xpSlider[i].maxValue = stats.xpForNextLevel[stats.playerLevel];
            xpSlider[i].value = stats.currentXP;
        }
    }

    public void OpenPanel(string panelName)
    {
        foreach (Transform child in panels.transform)
        {
            if (child.gameObject.name == panelName)
            {
                child.gameObject.SetActive(true);
            } else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void StatsMenu()
    {
        for (int i = 0; i < playerStats.Length; i++)
        {
            statsButtons[i].SetActive(true);
            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].playerName;
        }

        StatsMenuUpdate(0);
    }

    public void StatsMenuUpdate(int playerIndex)
    {
        var stat = playerStats[playerIndex];
        statName.text = stat.playerName;
        statHp.text = stat.currentHP + "/" + stat.maxHP;
        statMana.text = stat.currentMana + "/" + stat.maxMana;
        statDex.text = stat.dexterity.ToString();
        statDef.text = stat.defence.ToString();

        characterStatImage.sprite = stat.characterImage;

        statEquipedWeapon.text = stat.equippedWeaponName;
        statEquipedArmor.text = stat.equippedArmorName;
        statWeaponPower.text = stat.weaponPower.ToString();
        statArmorDefence.text = stat.armorDefence.ToString();
    }

    public void UpdateItemsInventory()
    {
        foreach (Transform transform in itemsContainer)
        {
            Destroy(transform.gameObject);
        }

        foreach (ItemManager item in Inventory.instance.GetItemManagerList())
        {
            RectTransform itemSlot = Instantiate(itemButton, itemsContainer).GetComponent<RectTransform>();
            Image itemImage = itemSlot.Find("Items Image").GetComponent<Image>();
            itemImage.sprite = item.itemsImage;
            TextMeshProUGUI amountText = itemSlot.Find("Amount Text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                amountText.text = item.amount.ToString(); 
            } else
            {
                amountText.text = "";
            }

            itemSlot.GetComponent<ItemsButton>().itemOnButton = item;
        }
    }

    public void DiscardItem()
    {
        RemoveItem();
        AudioManager.instance.PlaySFX(3);
    }

    public void UseItem(int selectedCharacter)
    {
        if (activeItem)
        {
            activeItem.UseItem(selectedCharacter);
            OpenCharacterChoicePanel();
            RemoveItem();
            AudioManager.instance.PlaySFX(8);
        }
    }

    private void RemoveItem()
    {
        if (activeItem)
        {
            if (Inventory.instance.RemoveItem(activeItem))
            {
                activeItem = null;
            }
            UpdateItemsInventory();
        }
    }

    public void OpenCharacterChoicePanel()
    {
        characterChoicePanel.SetActive(true);

        if (activeItem)
        {
            for (int i = 0; i < playerStats.Length; i++)
            {
                PlayerStats activePlayer = GameManager.instance.GetPlayerStats()[i];
                itemsCharacterChoiceNames[i].text = activePlayer.playerName;

                bool activePlayerAvailable = activePlayer.gameObject.activeInHierarchy;

                itemsCharacterChoiceNames[i].transform.parent.gameObject.SetActive(activePlayerAvailable);
            }
        }
    }

    public void CloseCharacterChoicePanel()
    {
        characterChoicePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FadeImage()
    {
        Animator animator = fadeImage.GetComponent<Animator>();
        animator.SetTrigger("Start Fading");
    }
}
