using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MenuSystem.Pages
{
    [RequireComponent(typeof(Canvas))]
    [DisallowMultipleComponent]
    public class PageController : MonoBehaviour
    {
        [SerializeField] private Page initialPage;
        [SerializeField] private GameObject firstFocusItem;

        private Canvas rootCanvas;

        private List<Page> pages;
        private Stack<Page> pageStack = new Stack<Page>();

        private void Awake()
        {
            rootCanvas = GetComponent<Canvas>();
            
            pages = new List<Page>();
            pages = GetComponentsInChildren<Page>(true).ToList();
        }

        private void Start()
        {
            if (firstFocusItem != null)
            {
                EventSystem.current.SetSelectedGameObject(firstFocusItem);
            }

            DisableAllPagesButInitial();

            if (initialPage != null)
            {
                PushPage(initialPage);
            }
        }

        private void OnCancel()
        {
            if (rootCanvas.enabled && rootCanvas.gameObject.activeInHierarchy)
            {
                if (pageStack.Count != 0)
                {
                    PopPage();
                }
            }
        }

        private void DisableAllPagesButInitial()
        {
            foreach (var page in pages)
            {
                if(page != initialPage) {
                    page.gameObject.SetActive(true);
                    page.Disable();
                }
            }
        }

        public bool IsPageInStack(Page _page)
        {
            return pageStack.Contains(_page);
        }

        public bool IsPageOnTopOfStack(Page Page)
        {
            return pageStack.Count > 0 && Page == pageStack.Peek();
        }

        public void PushPage(Page _page)
        {
            _page.Enter(true);

            if (pageStack.Count > 0)
            {
                Page currentPage = pageStack.Peek();

                if (currentPage.ExitOnNewPagePush)
                {
                    currentPage.Exit(false);
                }
            }

            pageStack.Push(_page);
        }

        public void PopPage()
        {
            if (pageStack.Count > 1)
            {
                Page page = pageStack.Pop();
                page.Exit(true);

                Page newCurrentPage = pageStack.Peek();
                if (newCurrentPage.ExitOnNewPagePush)
                {
                    newCurrentPage.Enter(false);
                }
            }
            else
            {
                Debug.LogWarning("Trying to pop a page but only 1 page remains in the stack!");
            }
        }

        public void PopAllPages()
        {
            for (int i = 1; i < pageStack.Count; i++)
            {
                PopPage();
            }
        }
    }
}