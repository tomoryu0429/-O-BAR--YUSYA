using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    static bool AllowInstanceCreation { get; set; } = true;
    public static T Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = (T)FindObjectOfType(typeof(T));

            if (instance == null)
            {
                Debug.LogWarning(typeof(T) + "was not found");
                if (AllowInstanceCreation)
                {
                    Debug.LogWarning(typeof(T) + "was Created");
                    GameObject go = new GameObject(typeof(T).Name);
                    instance = go.AddComponent<T>();
                }
                else
                {
                    Debug.LogError(typeof(T) + "is null");
                }
                
            }

            return instance;
        }
    }

    public static T InstanceNullable
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning(typeof(T) + $" is multiple created\n" +
                $"{this.gameObject.name} was Deleted", this);
            Destroy(this.gameObject);
            return;
        }

        instance = this as T;
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
