using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dialogues
{
    public class ChangeSceneAfterDialogue : MonoBehaviour
    {
        public string SceneName;
        
        public void ChangeScene()
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}