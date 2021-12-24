using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int maxLevel = 50;
    [SerializeField]
    private int playerLevel = 1;
    [SerializeField]
    private int currentXP;
    [SerializeField]
    private int[] xpForNextLevel;
    [SerializeField]
    private int baseLevelXP = 100;


    [SerializeField]
    private int maxHP = 100;
    [SerializeField]
    private int currentHP;

    [SerializeField]
    private int maxMana = 30;
    [SerializeField]
    private int currentMana;

    [SerializeField]
    private int dexterity;
    [SerializeField]
    private int defence;
    // Start is called before the first frame update
    void Start()
    {
        xpForNextLevel = new int[maxLevel];
        xpForNextLevel[1] = baseLevelXP;

        for (int i = 2; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] = (int) (0.02f * Mathf.Pow(i, 3) + 3.06f * Mathf.Pow(i, 2) + 105.6f * i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddXP(100);
        }
    }

    public void AddXP(int amountOfXp)
    {
        currentXP += amountOfXp;
        if (currentXP > xpForNextLevel[playerLevel])
        {
            currentXP -= xpForNextLevel[playerLevel];
            playerLevel++;

            maxHP = (int) (maxHP * 1.06f);
            currentHP = maxHP;
            maxMana = (int) (maxMana * 1.06f);
            currentMana = maxMana;
            if (playerLevel % 2 == 0)
            {
                dexterity++;
            } else
            {
                defence++;
            }
        }
    }
}
