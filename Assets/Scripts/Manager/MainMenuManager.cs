using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class MainMenuManager : MonoBehaviour
    {
        public void Jogar()
        {
            GameManager.Instance.PlayGame();           
        }

        public void Sair()
        {
            GameManager.Instance.QuitGame();
        }

        public void Credits()
        {
            Debug.Log("Menu de creditos");
        }
    }
}
