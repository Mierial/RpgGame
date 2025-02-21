using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    [SerializeField] private Text infoText;
    [SerializeField] private InventoryManager inventoryManager;
    private Item item_pref;
    private int totalValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        item_pref = inventoryManager.heldItem;
    }

    public void SellItem()
    {
        if (item_pref == null)
        {
            return;
        }
        InventorySlot slotToClear = inventoryManager.FindSlotWithItem(item_pref);

        if (slotToClear != null)
        {
            slotToClear.ClearSlot();
        }

        totalValue += item_pref.ItemValue;
        inventoryManager.SellItem(item_pref);

        inventoryManager.onItemChangedCallback?.Invoke();

        inventoryManager.heldItem = null;
    }

}
