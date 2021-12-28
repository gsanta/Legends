using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField]
    public string playerName;
    [SerializeField]
    public Sprite characterImage;
    [SerializeField]
    public int maxLevel = 50;
    [SerializeField]
    public int playerLevel = 1;
    [SerializeField]
    public int currentXP;
    [SerializeField]
    public int[] xpForNextLevel;
    [SerializeField]
    public int baseLevelXP = 100;


    [SerializeField]
    public int maxHP = 100;
    [SerializeField]
    public int currentHP;

    [SerializeField]
    public int maxMana = 30;
    [SerializeField]
    public int currentMana;

    [SerializeField]
    public int dexterity;
    [SerializeField]
    public int defence;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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

    public void AddHP(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
    
    public void AddMana(int amount)
    {
        currentMana += amount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }
}
