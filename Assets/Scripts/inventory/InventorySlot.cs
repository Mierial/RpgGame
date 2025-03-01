using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    [SerializeField] private Image icon;
    public Button removeButton;

    private void Start() { }

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
           InventoryManager.Instance.SetHeldItem(item);
        }
    }
<<<<<<< HEAD
=======

    public bool ContainsItem(Item searchItem)
    {
        return item == searchItem;
    }
>>>>>>> d01ea85 (shop)
}
