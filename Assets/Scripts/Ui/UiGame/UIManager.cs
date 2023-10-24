using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

#region Enum Related
public enum EScreenUI
{
    Nothing,
    Inventory,
    Book,
    Pause,
    FinishedGame
}
#endregion


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Space(10)]
    [Header("Dynamic Objects")]
    [SerializeField] GameObject objectForInventory;
    [SerializeField] GameObject objectForBook;
    [SerializeField] GameObject objectsForPause;
    [SerializeField] GameObject objectsForFinishedGame;

    [Space(10)]
    [Header("Screen UI")]
    [SerializeField] public EScreenUI screenUI;

    private void OnValidate()
    {
        EnableDynamicObjectForPreview();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ToggleObject(EScreenUI.Nothing);
    }

    #region Dynamic Objects Controller
    public void SetScreenUI(EScreenUI _screenUI)
    {
        ToggleObject(_screenUI);
    }

    private void ToggleObjectForInventory(bool value)
    {
        objectForInventory.SetActive(value);
    }

    private void ToggleObjectForBook(bool value)
    {
        objectForBook.SetActive(value);
    }

    private void ToggleObjectForPause(bool value)
    {
        objectsForPause.SetActive(value);
    }

    private void ToggleObjectForFinishedGame(bool value)
    {
        objectsForFinishedGame.SetActive(value);
    }    

    public void ToggleObject(EScreenUI _screenUI)
    {
        screenUI = _screenUI;

        switch (screenUI)
        {
            case EScreenUI.Pause:
                DisableAllToggleObjects();
                ToggleObjectForPause(true);
                break;
            case EScreenUI.Inventory:
                DisableAllToggleObjects();
                ToggleObjectForInventory(true);
                break;
            case EScreenUI.Book:
                DisableAllToggleObjects();
                ToggleObjectForBook(true);
                break;
            case EScreenUI.FinishedGame:
                DisableAllToggleObjects();
                ToggleObjectForFinishedGame(true);
                break;
            case EScreenUI.Nothing:
                DisableAllToggleObjects();
                break;
        }
    }

    void DisableAllToggleObjects()
    {
        objectForInventory.SetActive(false);
        objectForBook.SetActive(false);
        objectsForPause.SetActive(false);
        objectsForFinishedGame.SetActive(false);        
    }

    public void EnableDynamicObjectForPreview()
    {
        ToggleObject(screenUI);
    }
    #endregion    
}
