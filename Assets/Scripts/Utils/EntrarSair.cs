using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EntrarSair : MonoBehaviour
{
    public Canvas IconCanvas;
    public Transform Destino;

    private GameObject jogador;
    private ChangeCamera scriptChangeCamera;
    private bool isInside;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        scriptChangeCamera = GetComponent<ChangeCamera>();
    }

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 0;
            IconCanvas.GetComponent<IconsCanvasManager>().AskBox.SetActive(true);
        }
    }

    public void Confirm(bool yes)
    {
        if (yes)
        {
            Time.timeScale = 1;
            jogador.transform.position = Destino.position;
            IconCanvas.GetComponent<IconsCanvasManager>().AskBox.SetActive(false);
            if (scriptChangeCamera != null)
            {
                scriptChangeCamera.ChangeActiveCamera();
            }
        }
        else
        {
            Time.timeScale = 1;
            IconCanvas.GetComponent<IconsCanvasManager>().AskBox.SetActive(false);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        var iconsCanvasManager = IconCanvas.GetComponent<IconsCanvasManager>();
        iconsCanvasManager.ScriptEntrarSair = GetComponent<EntrarSair>();
        iconsCanvasManager.IconIteraction.SetActive(true);
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.X))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IconCanvas.GetComponent<IconsCanvasManager>().IconIteraction.SetActive(false);
        isInside = false;
    }
}
