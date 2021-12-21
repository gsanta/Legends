using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    public string[] sentences;
    private bool canActivate;

    private void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1") && !DialogController.instance.IsDialogBoxActive())
        {
            DialogController.instance.ActivateDialog(sentences);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = false;
        }
    }
}
