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

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField]
    private TextMeshProUGUI[] nameText, hpText, manaText, lvlText, xpText;
    [SerializeField]
    private Slider[] xpSlider;
    [SerializeField]
    private Image[] characterImage;
    [SerializeField]
    private GameObject[] characterPanel;

    void Start()
    {
        instance = this;
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
                menu.SetActive(true);
                GameManager.instance.gameMenuOpened = true;
            }
        }
    }

    public void FadeImage()
    {
        Animator animator = fadeImage.GetComponent<Animator>();
        animator.SetTrigger("Start Fading");
    }
}
