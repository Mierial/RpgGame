using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item;
    [SerializeField] private Image icon;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        InventoryManager.Instance.DropItem(item);
        InventoryManager.Instance.RemoveItem(item);
        ClearSlot();
    }

    public void UseItem()
    {
        if (item != null)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            if (item is Equipment equipment)
            {
                EquipmentManager.Instance.Equip(equipment);
            }
            else
            {
                InventoryManager.Instance.SetHeldItem(item);
            }
        }
    }
<<<<<<< HEAD
=======
=======
           InventoryManager.Instance.SetHeldItem(item);
        }
    }
>>>>>>> origin/test

    public bool ContainsItem(Item searchItem)
    {
        return item == searchItem;
    }
<<<<<<< HEAD
>>>>>>> d01ea85 (shop)
=======
>>>>>>> origin/test
=======
            InventoryManager.Instance.SetHeldItem(item);
        }
    }
>>>>>>> stas-nps
}
