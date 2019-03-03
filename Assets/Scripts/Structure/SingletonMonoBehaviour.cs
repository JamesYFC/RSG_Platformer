using UnityEngine;

namespace RSGPlatformer
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    T foundInstance = GameObject.FindObjectOfType<T>() as T;
                    if (foundInstance != null)
                    {
                        _instance = foundInstance;
                        return _instance;
                    }
                    else
                    {
                        Debug.LogError("No instance of " + typeof(T).ToString() + " found!");
                        return default(T);
                    }
                }
                else
                {
                    return _instance;
                }
            }
            private set => _instance = value;
        }
    }
}