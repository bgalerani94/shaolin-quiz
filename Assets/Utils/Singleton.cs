using UnityEngine;

// ReSharper disable StaticMemberInGenericType
namespace Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static bool _applicationIsQuitting;

        public static T Instance
        {
            get
            {
                if (_applicationIsQuitting) return null;

                if (_instance != null) return _instance;

                _instance = (T) FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    Debug.LogWarning($"More than 1 component of type {typeof(T)} was found! Be aware of that!");
                    return _instance;
                }

                if (_instance != null) return _instance;

                GameObject singleton;
                var singletonPrefab = Resources.Load<T>(typeof(T).Name);

                if (singletonPrefab != null)
                {
                    _instance = Instantiate(singletonPrefab);
                    singleton = _instance.gameObject;
                }
                else
                {
                    singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();
                }

                singleton.name = typeof(T).Name;
                DontDestroyOnLoad(singleton);

                return _instance;
            }
        }

        public void OnDestroy()
        {
            _applicationIsQuitting = true;
        }
    }
}