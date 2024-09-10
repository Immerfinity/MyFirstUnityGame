using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectGenerator : MonoBehaviour
{
    [MenuItem("Utilities/GenerateUsableItems")]
    public static void GenerateUsableItems()
    {
        string[] itemData = File.ReadAllLines("Assets/Editor/CSVs/Items.csv");

        foreach (string item in itemData.Skip(1))
        {
            UsableItem usableItem = ScriptableObject.CreateInstance<UsableItem>();

            string[] itemProperties = item.Split(',');

            usableItem.ItemName = itemProperties[0];
            usableItem.ItemDescription = itemProperties[1];
            usableItem.CanUseInMenu = bool.Parse(itemProperties[2]);
            usableItem.CanUseInBattle = bool.Parse(itemProperties[3]);

            AssetDatabase.CreateAsset(usableItem, $"Assets/Resources/ScriptableObjects/InventoryItems/UsableItems/{usableItem.ItemName}.asset");
        }

        AssetDatabase.SaveAssets();
    }
}
