using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogText, nameText;
    [SerializeField]
    private GameObject dialogBox, nameBox;
    [SerializeField]
    private string[] dialogSentences;
    [SerializeField]
    private int currentSentence;

    public static DialogController instance;

    private bool dialogJustStarted = false;

    private void Start()
    {
        instance = this;
        dialogText.text = dialogSentences[currentSentence];
    }

    private void Update()
    {
        if (dialogBox.activeInHierarchy && Input.GetButtonUp("Fire1"))
        {
            if (!dialogJustStarted)
            {

                currentSentence = currentSentence + 1;
                if (currentSentence >= dialogSentences.Length)
                {
                    dialogBox.SetActive(false);
                    Player.instance.isMovementDeactivated = false;
                } else
                {
                    CheckForName();
                    dialogText.text = dialogSentences[currentSentence];
                }
            }
            else
            {
                dialogJustStarted = false;
            }
        }
    }

    public void ActivateDialog(string[] sentences)
    {
        dialogSentences = sentences;
        currentSentence = 0;

        CheckForName();
        dialogText.text = dialogSentences[currentSentence];
        dialogBox.SetActive(true);
        dialogJustStarted = true;

        Player.instance.isMovementDeactivated = true;
    }

    private void CheckForName()
    {
        if (dialogSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }

    public bool IsDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }
}
