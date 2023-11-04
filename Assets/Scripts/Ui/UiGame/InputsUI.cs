using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsUI : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] PauseScreenManager PauseScreenManager;
    [SerializeField] BookManager BookManager;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("btnPause")) && GameManager.Instance.GameState != EGameState.Menu)
        {
            if (GameManager.Instance.inUIGame && GameManager.Instance.GameState != EGameState.Paused) return;
            PauseScreenManager.PauseGame();
        }

        if ((Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("btnBook")) && GameManager.Instance.GameState != EGameState.Menu)
        {
            if (GameManager.Instance.inUIGame && GameManager.Instance.GameState != EGameState.Paused) return;
            BookManager.OpenBook();
        }
    }
}
