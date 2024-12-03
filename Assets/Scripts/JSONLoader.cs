using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONLoader : MonoBehaviour
{
    public Inventory inventory;

    void Start() {
        inventory = Inventory.Instance;
    }

    public void SaveData() {
        string json = JsonUtility.ToJson(inventory);
        Debug.Log(json);
        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "TownInventory.json")) {
            writer.Write(json);
        }
    }

    public void LoadData() {
        string json = string.Empty;
        using(StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "TownInventory.json")) {
            json = reader.ReadToEnd();
        }
        inventory = JsonUtility.FromJson<Inventory>(json);
    }
}
