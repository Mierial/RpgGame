using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loot", menuName = "Loot Info")]
public class loot :ScriptableObject
{
    public GameObject lootObJ;
    public string lootName;
    public int dropChanse;

    public loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChanse = dropChance;
    }
}
