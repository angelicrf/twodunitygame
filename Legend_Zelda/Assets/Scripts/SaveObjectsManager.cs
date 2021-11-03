using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class SaveObjectsManager : MonoBehaviour
{
    public static SaveObjectsManager saveObjectsManager;
    public List<ScriptableObject> allObjects;
    public void Awake()
    {
        if (saveObjectsManager != null)
        {
            saveObjectsManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        if (allObjects != null)
        {
            allObjects = new List<ScriptableObject>();
        }
    }

}
