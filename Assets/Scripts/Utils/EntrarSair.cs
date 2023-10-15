using System;
using System.Collections;
using System.Collections.Generic;
using Ui;
using UnityEngine;
using Utils;

public class EntrarSair : MonoBehaviour
{
    public Transform Destino;

    private IconsCanvasManager iconCanvasScript;
    private GameObject jogador;
    private ChangeCamera scriptChangeCamera;
    private bool isInside;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        scriptChangeCamera = GetComponent<ChangeCamera>();
        iconCanvasScript = GameObject.FindGameObjectWithTag("IconsCanvas").GetComponent<IconsCanvasManager>();
    }

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 0;
            iconCanvasScript.AskBox.SetActive(true);
        }
    }

    public void Confirm(bool yes)
    {
        if (yes)
        {
            Time.timeScale = 1;
            jogador.transform.position = Destino.position;
            iconCanvasScript.AskBox.SetActive(false);
            if (scriptChangeCamera != null)
            {
                scriptChangeCamera.ChangeActiveCamera();
            }
        }
        else
        {
            Time.timeScale = 1;
            iconCanvasScript.AskBox.SetActive(false);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        var iconsCanvasManager = iconCanvasScript;
        iconsCanvasManager.ScriptEntrarSair = GetComponent<EntrarSair>();
        iconsCanvasManager.IconIteraction.SetActive(true);
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        iconCanvasScript.IconIteraction.SetActive(false);
        isInside = false;
    }
}
