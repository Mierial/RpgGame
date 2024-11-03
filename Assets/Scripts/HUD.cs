using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEvenstArg e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        foreach (Transform slot in inventoryPanel.transform)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if (!image.enabled || image.sprite == null)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }

}
