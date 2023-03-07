using System.IO;
using Navigation.Scripts;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public class SceneCreator : EditorWindow
    {
        private string _scenePath;
        private string _sceneName;

        public static void CreateNewScene(string path)
        {
            var window = GetWindow<SceneCreator>();

            window._scenePath = path;

            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Scene Creator", EditorStyles.boldLabel);

            _sceneName = EditorGUILayout.TextField("Scene Name", _sceneName);

            if (GUILayout.Button("Create"))
            {
                FixScenePath();

                CreateDirectoryIfNeeded(_scenePath);

                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

                EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

                EditorSceneManager.SaveScene(SceneManager.GetActiveScene(),
                    _scenePath + _sceneName + ".unity");

                var sceneSo = CreateInstance<SceneScriptableObject>();
                sceneSo.sceneName = _sceneName;

                AssetDatabase.CreateAsset(sceneSo, _scenePath + _sceneName + ".asset");
                AssetDatabase.SaveAssets();

                Selection.activeObject = sceneSo;
                EditorGUIUtility.PingObject(sceneSo);
                Close();
            }
        }

        private void FixScenePath()
        {
            if (!_scenePath.Contains("Resources"))
            {
                _scenePath += _scenePath.EndsWith("/") ? "Resources/" : "/Resources/";
            }

            if (!_scenePath.StartsWith("Assets/"))
            {
                _scenePath = "Assets/" + _scenePath;
            }

            if (!_scenePath.EndsWith("/"))
            {
                _scenePath += "/";
            }
        }

        private static void CreateDirectoryIfNeeded(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}