using Battle;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SaveData
{
    public int money;
    public List<PartyMember> activeMembers;
}

public static class SaveManager
{
    [SerializeField] private static string saveFileName = "gameData.json";

    public static void SaveGameData()
    {
        SaveData saveData = new SaveData();
        saveData.money = InfoController.Money;

        saveData.activeMembers = new List<PartyMember>();
        foreach (var member in Party.activeMembers)
        {
            saveData.activeMembers.Add(member);
        }

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(GetSavePath(), json);
    }

    public static void LoadGameData()
    {
        if (File.Exists(GetSavePath()))
        {
            string json = File.ReadAllText(GetSavePath());

            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            InfoController.Money = saveData.money;

            Party.activeMembers.Clear();

            foreach (var memberData in saveData.activeMembers)
            {
                Party.AddActiveMember(memberData);
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }

    private static string GetSavePath()
    {
        return Path.Combine(Application.dataPath, saveFileName);
    }

    public static void ClearData()
    {
        if (File.Exists(GetSavePath()))
        {
            File.Delete(GetSavePath());
            Debug.Log("Save data cleared.");
        }
        else
        {
            Debug.LogWarning("No save data found to clear.");
        }
    }
}
