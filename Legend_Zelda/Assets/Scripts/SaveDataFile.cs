using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveDataFile : MonoBehaviour
{
    public List<ScriptableObject> allObjects = new List<ScriptableObject>();

    void OnEnable()
    {
        ToResetData();
        LoadFile();
    }
    void OnDisable()
    {

        SaveTofile();
    }

    public void SaveTofile()
    {
        for (int i = 0; i < allObjects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.dat", i));
            BinaryFormatter binaryData = new BinaryFormatter();
            var jsonData = JsonUtility.ToJson(allObjects[i]);
            binaryData.Serialize(file, jsonData);
            file.Close();
        }

    }
    public void LoadFile()
    {
        for (int i = 0; i < allObjects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binaryDta = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binaryDta.Deserialize(file), allObjects[i]);
                file.Close();

            }
        }
    }
    public void ToResetData()
    {
        Debug.Log("toResetCalled..");
        for (int i = 0; i < allObjects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.dat", i));
            }
        }
    }
}
