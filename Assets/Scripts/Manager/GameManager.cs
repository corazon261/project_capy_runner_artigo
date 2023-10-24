using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        #region InGame Methods
        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
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
}
