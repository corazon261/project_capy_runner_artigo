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
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.GameState != EGameState.Menu)
        {
            PauseScreenManager.PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.GameState != EGameState.Menu)
        {
            BookManager.OpenBook();
        }
    }
}
