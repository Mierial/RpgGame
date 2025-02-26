using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Text Text;
    private Item item_pref;
    [SerializeField] private InventoryManager inventoryManager;
    int value = 0;
=======
    [SerializeField] private Text infoText;
    [SerializeField] private InventoryManager inventoryManager;
    public Text valueText;
    private Item item_pref;

    public Image itemImage;
    public int totalValue = 0;

>>>>>>> d01ea85 (shop)
    private void OnTriggerEnter(Collider other)
    {
        valueText.text = totalValue.ToString();
        item_pref = inventoryManager.heldItem;
<<<<<<< HEAD
     Debug.Log($" item_pref:");
        
=======
        itemImage.sprite = item_pref.icon;
        infoText.text = item_pref.ItemValue.ToString();
>>>>>>> d01ea85 (shop)
    }

    public void SellItem()
    {
        if (item_pref == null)
        {
            Debug.LogError("item_pref == null");
            return;
        }
        else
        {
            value += item_pref.ItemValue;
            inventoryManager.SellItem(item_pref);
            Debug.Log($"Nice Work{value}");
        }
<<<<<<< HEAD
    }
=======

        totalValue += item_pref.ItemValue;
        UpdateText();
        inventoryManager.SellItem(item_pref);

        inventoryManager.onItemChangedCallback?.Invoke();

        inventoryManager.heldItem = null;
    }

    public void UpdateText()
    {
        valueText.text = totalValue.ToString();
    }

>>>>>>> d01ea85 (shop)
}
