
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : Singleton where T : Singleton<T>
{
    static T _instance;
    public static T Instance { get => _instance; set => _instance = value; }
    protected virtual void Awake()
    {

        Debug.Log("Awake T="+typeof(T));
        if (_instance != null) { Destroy(gameObject); } else { _instance = (T)this; }
    }
    protected virtual void OnDestroy()
    {
        Debug.Log("OnDestroy T="+typeof(T));
        _instance = null;
    }
}
public abstract class Singleton : MonoBehaviour
{
}