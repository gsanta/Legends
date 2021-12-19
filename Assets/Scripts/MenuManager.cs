using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    public static MenuManager instance;

    void Start()
    {
        instance = this;
    }

    public void FadeImage()
    {
        Animator animator = fadeImage.GetComponent<Animator>();
        animator.SetTrigger("Start Fading");
    }
}
