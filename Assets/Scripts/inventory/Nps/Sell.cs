<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
=======
>>>>>>> origin/test
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private Text Text;
    private Item item_pref;
    [SerializeField] private InventoryManager inventoryManager;
    int value = 0;
=======
=======
>>>>>>> origin/test
    [SerializeField] private Text infoText;
    [SerializeField] private InventoryManager inventoryManager;
    public Text valueText;
    private Item item_pref;

    public Image itemImage;
    public int totalValue = 0;

<<<<<<< HEAD
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
=======
    private void OnTriggerEnter(Collider other)
    {
        UpdateItemInfo();
    }

    private void UpdateItemInfo()
    {
        item_pref = inventoryManager.heldItem;

        if (item_pref != null)
        {
            itemImage.sprite = item_pref.icon;
            itemImage.gameObject.SetActive(true);
            infoText.text = item_pref.ItemValue.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            infoText.text = "0";
        }
>>>>>>> origin/test
    }

    public void SellItem()
    {
        if (item_pref == null)
        {
<<<<<<< HEAD
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
=======
            return;
        }

        InventorySlot slotToClear = inventoryManager.FindSlotWithItem(item_pref);

        if (slotToClear != null)
        {
            slotToClear.ClearSlot();
        }

        if (InventoryManager.Instance.heldItem != null)
        {
            totalValue += item_pref.ItemValue;
            inventoryManager.SellItem(item_pref);
            inventoryManager.heldItem = null;
        }

        inventoryManager.onItemChangedCallback?.Invoke();
        UpdateItemInfo();
        UpdateText();
>>>>>>> origin/test
    }

    public void UpdateText()
    {
        valueText.text = totalValue.ToString();
    }
<<<<<<< HEAD

>>>>>>> d01ea85 (shop)
=======
>>>>>>> origin/test
}
