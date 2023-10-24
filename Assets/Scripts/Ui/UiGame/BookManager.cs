using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] List<GameObject> pages;
    [SerializeField] int currentPage = 0;

    private void Awake()
    {
        SetTheFristPage();
    }

    public void OpenBook()
    {
        if (UIManager.Instance.screenUI == EScreenUI.Nothing)
        {
            UIManager.Instance.SetScreenUI(EScreenUI.Book);
            GameManager.Instance.PauseGame();
        }
        else
        {
            if (UIManager.Instance.screenUI != EScreenUI.Book) return;
            
            UIManager.Instance.SetScreenUI(EScreenUI.Nothing);
            GameManager.Instance.ResumeGame();
        }
    }

    public void NextPage()
    {
        if (currentPage + 1 <= pages.Count - 1)
        {
            pages[currentPage].SetActive(false);

            currentPage++;

            pages[currentPage].SetActive(true);

        }
    }

    public void PreviousPage()
    {
        Debug.Log(currentPage - 1 + " E " + (pages.Count - 1));
        if (currentPage - 1 >= 0)
        {
            pages[currentPage].SetActive(false);

            currentPage--;

            pages[currentPage].SetActive(true);

        }
    }

    private void SetTheFristPage()
    {
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }

        currentPage = 0;
        pages[currentPage].SetActive(true);        
    }
}
