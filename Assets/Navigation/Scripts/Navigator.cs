using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Navigation.Scripts
{
    public class Navigator : Singleton<Navigator>
    {
        [SerializeField] private List<SceneScriptableObject> scenesSos;

        public bool Navigate(SceneEnum newScene)
        {
            var sceneToGo = scenesSos.FirstOrDefault(scene => scene.sceneEnum == newScene);
            if (sceneToGo == null)
            {
                Debug.LogError($"Couldn't find the scene {newScene} to load." +
                               "\nPlease, check the Editor Build Settings and the Navigator prefab.");
                return false;
            }

            PerformTransition(sceneToGo);
            return true;
        }

        private void PerformTransition(SceneScriptableObject newScene)
        {
            //TODO Create the transition here.
            SceneManager.LoadScene(newScene.sceneName);
        }
    }
}