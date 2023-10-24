using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class PauseScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Pause UI Methods
    public void PauseGame()
    {
        if (UIManager.Instance.screenUI == EScreenUI.Nothing)
        {
            UIManager.Instance.SetScreenUI(EScreenUI.Pause);
            GameManager.Instance.PauseGame();
        }
        else
        {
            if (UIManager.Instance.screenUI != EScreenUI.Pause) return;

            UIManager.Instance.SetScreenUI(EScreenUI.Nothing);
            GameManager.Instance.ResumeGame();
        }
    }

    public void ClickSairJogo()
    {
        UIManager.Instance.SetScreenUI(EScreenUI.Nothing);
        GameManager.Instance.ReturnMainMenu();
    }

    public void ClickContinuarJogando()
    {
        UIManager.Instance.SetScreenUI(EScreenUI.Nothing);
        GameManager.Instance.ResumeGame();
    }
    #endregion
}
