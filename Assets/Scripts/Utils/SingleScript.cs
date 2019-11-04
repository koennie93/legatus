using UnityEngine;

public class SingleScript<T> where T : ScriptableObject
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindObjectOfType<T>();
                if (_instance == null)
                {
                    var path = "Singles/" + typeof(T).Name;
                    _instance = Resources.Load<T>(path);
                    if (_instance == null)
                    {
                        if (typeof(ScriptableObject).IsAssignableFrom(typeof(T)))
                        {
                            _instance = ScriptableObject.CreateInstance<T>();
                            #if UNITY_EDITOR
                            UnityEditor.AssetDatabase.CreateAsset(_instance, path);
                            #endif
                        }
                    }
                }
            }
            return _instance;
        }
    }
}