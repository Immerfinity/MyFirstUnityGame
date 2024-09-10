using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public string ItemName
    {
        get => itemName;
        set => itemName = value;
    }

    public string ItemDescription
    {
        get => itemDescription;
        set => itemDescription = value;
    }
}