using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Default, Food, Instrument
}

public class ItemScriptableObject : ScriptableObject
{
    public string ItemName;
    public int maxAmount;
    public GameObject ItemPrefab;
    public Sprite itemIcon;
    public ItemType ItemType;
}
