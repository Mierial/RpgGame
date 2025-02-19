using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    [SerializeField] private Text Text;
    private Item item_pref;
    [SerializeField] private InventoryManager inventoryManager;
    int value = 0;
    private void OnTriggerEnter(Collider other)
    {
        item_pref = inventoryManager.heldItem;
     Debug.Log($"?????????? item_pref:");
        
    }

    public void SellItem()
    {
        if (item_pref == null)
        {
            Debug.LogError("item_pref == null, ?? ????? ??????? ???????!");
            return;
        }

        value += item_pref.ItemValue;
        inventoryManager.SellItem(item_pref);
        Debug.Log($"Nice Work{value}");
    }
}
