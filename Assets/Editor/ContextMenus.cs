using UnityEditor;

namespace Editor
{
    public class ContextMenus : UnityEditor.Editor
    {
        private const string DefaultScenePath = "Assets/Navigation/Scenes";

        [MenuItem("Assets/Create/Shaolin/Create New Scene")]
        public static void CreateSceneOption(MenuCommand command)
        {
            var folderObject = Selection.activeObject;
            var path = folderObject != null && folderObject is DefaultAsset
                ? AssetDatabase.GetAssetPath(folderObject)
                : DefaultScenePath;

            SceneCreator.CreateNewScene(path);
        }
    }
}