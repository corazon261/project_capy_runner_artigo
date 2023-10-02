using System;
using System.Collections;
using System.Collections.Generic;
using Ui;
using UnityEngine;

public class DetectAndActiveEye : MonoBehaviour
{
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<Canvas>().GetComponent<UIManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.ShowEye(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiManager.ShowEye(false);
        }
    }
}
