using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour
{
    static string path = "All Questions.txt";
    public static void Save()
    {
        SaveData sd = new SaveData();
        string json = JsonUtility.ToJson(sd);
        File.WriteAllText(path, json);
        Debug.Log("Saved");
    }
    public static void Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData sd = JsonUtility.FromJson<SaveData>(json);

            Game.instance.quests = sd.quests;
            Game.instance.players = sd.players;
            Debug.Log("Loaded");
        }
        else
        {
            Debug.Log("File was not found");
        }
    }
}
