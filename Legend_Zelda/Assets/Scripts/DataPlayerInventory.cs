using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataPlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;

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
        ToResetData();

        for (int i = 0; i < playerInventory.plInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}PlInventory.inv", i));
            BinaryFormatter binaryData = new BinaryFormatter();
            var jsonData = JsonUtility.ToJson(playerInventory.plInventory[i]);
            binaryData.Serialize(file, jsonData);
            file.Close();

        }

    }
    public void LoadFile()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.PlInventory.inv", i)))
        {
            string filePath = Application.persistentDataPath + string.Format("/{0}PlInventory.inv", i);
            var tempFile = ScriptableObject.CreateInstance<InventoryItem>();
            FileStream file = File.Open(filePath, FileMode.Open);
            BinaryFormatter binaryDta = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binaryDta.Deserialize(file), tempFile);
            file.Close();
            //if items doesn't' exist
            playerInventory.plInventory.Add(tempFile);
            i++;
        }

    }
    public void ToResetData()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}PlInventory.inv", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}PlInventory.inv", i));
            i++;
        }

    }
}
