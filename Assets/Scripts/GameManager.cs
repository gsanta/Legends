using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private PlayerStats[] playerStats;

    public bool gameMenuOpened = false;
    public bool dialogBoxOpened = false;

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
        if (gameMenuOpened || dialogBoxOpened)
        {
            Player.instance.isMovementDeactivated = true;
        } else
        {
            Player.instance.isMovementDeactivated = false;
        }
    }
}
