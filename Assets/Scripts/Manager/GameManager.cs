using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] GameObject ManagerObject;

        [SerializeField] EGameState GameState;

        public int teste;

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

            GameState = EGameState.Playing;
        }

        #region PlayGame Methods
        public void PlayGame()
        {
            LoadScene("interior casa");
        }
        #endregion

        #region SceneManagement
        public void LoadScene(string _nameScene)
        {
            SceneManager.LoadScene(_nameScene);
        }

        public void LoadScene(int _indexScene)
        {
            SceneManager.LoadScene(_indexScene);
        }
        #endregion

        #region InGame Methods
        public void PauseGame()
        {
            if (GameState == EGameState.Paused) return;

            GameState = EGameState.Paused;
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            if (GameState == EGameState.Playing) return;

            GameState = EGameState.Playing;
            Time.timeScale = 1f;
        }

        public void ReturnMainMenu()
        {
            //@ Resetar informações do player

            GameState = EGameState.Playing;
            Time.timeScale = 1f;
            LoadScene(0);            
        }

        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }
        #endregion
    }

    #region Enum Related
    enum EGameState
    {
        Playing,
        Paused
    }
    #endregion
}
