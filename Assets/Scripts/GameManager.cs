using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private PlayerStats[] playerStats;

    public bool gameMenuOpened = false;
    public bool dialogBoxOpened = false;
    public bool shopOpen = false;

    public int currentBitcoins;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        playerStats = FindObjectsOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpened || dialogBoxOpened || shopOpen)
        {
            Player.instance.isMovementDeactivated = true;
        } else
        {
            Player.instance.isMovementDeactivated = false;
        }
    }

    public PlayerStats[] GetPlayerStats()
    {
        return playerStats;
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Player_Pos_X", Player.instance.transform.position.x);
        PlayerPrefs.SetFloat("Player_Pos_Y", Player.instance.transform.position.y);
        PlayerPrefs.SetFloat("Player_Pos_Z", Player.instance.transform.position.z);
    }

    public void LoadData()
    {
        float x = PlayerPrefs.GetFloat("Player_Pos_X");
        float y = PlayerPrefs.GetFloat("Player_Pos_Y");
        float z = PlayerPrefs.GetFloat("Player_Pos_Z");

        Player.instance.transform.position = new Vector3(x, y, z);
    }
}
