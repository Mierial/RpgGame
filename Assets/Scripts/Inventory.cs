using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 9;
    private List<IInventoryItem> m_items = new List<IInventoryItem>();

    public event EventHandler<InventoryEvenstArg> ItemAdded;

    public void AddItem(IInventoryItem item)
    {
        if (m_items.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;

                m_items.Add(item);
                item.OnPickUp();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEvenstArg(item));
                }
            }
        }
    }
}
