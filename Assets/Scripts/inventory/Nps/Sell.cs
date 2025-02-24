using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    [SerializeField] private Text infoText;
    [SerializeField] private InventoryManager inventoryManager;
    public Text valueText;
    private Item item_pref;

    public Image itemImage;
    public int totalValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        valueText.text = totalValue.ToString();
        item_pref = inventoryManager.heldItem;
        itemImage.sprite = item_pref.icon;
        infoText.text = item_pref.ItemValue.ToString();
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
        UpdateText();
        inventoryManager.SellItem(item_pref);

        inventoryManager.onItemChangedCallback?.Invoke();

        inventoryManager.heldItem = null;
    }

    public void UpdateText()
    {
        valueText.text = totalValue.ToString();
    }

}
