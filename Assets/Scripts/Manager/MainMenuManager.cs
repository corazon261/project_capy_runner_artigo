using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class MainMenuManager : MonoBehaviour
    {
        public void Jogar()
        {
            SceneManager.LoadScene("interior casa");
        }

        public void Sair()
        {
            Application.Quit();
        }

        public void Credits()
        {
            Debug.Log("Menu de creditos");
        }
    }
}
