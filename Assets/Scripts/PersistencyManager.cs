using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistencyManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.SaveData();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.instance.LoadData();
        }
    }
}
