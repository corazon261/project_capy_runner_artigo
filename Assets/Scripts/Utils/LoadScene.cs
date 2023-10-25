using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LoadScene : MonoBehaviour
    {
        #if UNITY_EDITOR
            public SceneAsset SceneToLoad;
        #endif
        public string SceneName;
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // #if UNITY_EDITOR
                //     SceneManager.LoadScene(SceneToLoad.name);
                //     return;
                // #endif
                Debug.Log("Entrou");
                SceneManager.LoadScene(SceneName);
            }
        }
    }
}