using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsCanvasManager : MonoBehaviour
{
    public GameObject IconIteraction;
    public GameObject IconChat;
    public GameObject AskBox;
    public EntrarSair ScriptEntrarSair;

    private void Start()
    {
        IconIteraction.SetActive(false);
        IconChat.SetActive(false);
        AskBox.SetActive(false);
    }

    public void Awnser(bool yes)
    {
        ScriptEntrarSair.Confirm(yes);
    }
    
}
