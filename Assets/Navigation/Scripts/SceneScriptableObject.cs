using UnityEngine;
using UnityEngine.Serialization;

namespace Navigation.Scripts
{
    [CreateAssetMenu(menuName = "Shaolin/SOs/SceneSO", fileName = "New Scene Scriptable Object")]
    public class SceneScriptableObject : ScriptableObject
    {
        public string sceneName;
        public SceneEnum sceneEnum;
        public GameObject transitionIn;
        public GameObject transitionOut;
    }
}
