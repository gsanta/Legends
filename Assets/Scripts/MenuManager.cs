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
    private GameObject menu;
    [SerializeField]
    private GameObject panels;
    [SerializeField]
    private GameObject[] statsButtons;

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField]
    private TextMeshProUGUI[] nameText, hpText, manaText, currentXPText, xpText;
    [SerializeField]
    private Slider[] xpSlider;
    [SerializeField]
    private Image[] characterImage;
    [SerializeField]
    private GameObject[] characterPanel;

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
        }
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
