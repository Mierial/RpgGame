using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<loot> lootList = new List<loot> ();

    loot GetDropedtem()
    {
        int randomNumber = Random.Range(1, 101);
        List<loot> possibleItems = new List<loot>();
        foreach (loot item in lootList)
        {
            if (randomNumber <= item.dropChanse)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No loot");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition) 
    {
        loot droppedItem = GetDropedtem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            
        }
    }


    
}
