using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    Item item;
    [SerializeField] private Image icon;

    public Button removeButton;

    private Interactable interactable;

    [SerializeField] private Transform playerPosition;

    private void Start() {
        interactable = GetComponent<Interactable>();
    }
    public void AddItem(Item newItem) {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton() {

            Vector3 dropPosition = playerPosition.position + playerPosition.forward * 2f;


            Instantiate(item.prefab, dropPosition, Quaternion.identity);


            InventoryManager.Instance.RemoveItem(item);

            // Очищаем слот
            ClearSlot();
        }
    


    public void UseItem() {
        if (item != null) {
            item.Use();
        }
    }
}