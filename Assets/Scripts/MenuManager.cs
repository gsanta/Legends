using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    private GameObject menu;

    public static MenuManager instance;

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
            } else
            {
                menu.SetActive(true);
            }
        }
    }

    public void FadeImage()
    {
        Animator animator = fadeImage.GetComponent<Animator>();
        animator.SetTrigger("Start Fading");
    }
}
