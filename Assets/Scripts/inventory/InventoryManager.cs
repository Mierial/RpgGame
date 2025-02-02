using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than 1 instance");
            return;
        }
        Instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;

    public Item heldItem; // Текущий предмет в руке
    public Transform handTransform; // Точка, куда будет появляться предмет

    private GameObject heldObject; // Текущий объект в руке

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough space in inventory.");
            return false;
        }

        items.Add(item);
        onItemChangedCallback?.Invoke();
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        // Если удаляем предмет, который в руке - он тоже выбрасывается
        if (heldItem == item)
        {
            DropItem(item);
            heldItem = null;
        }
    }

    public void SetHeldItem(Item item)
    {
        heldItem = item;
        HoldItem(item);
        Debug.Log("Item in hand: " + item.name);
    }

    private void HoldItem(Item item)
    {
        if (heldObject != null)
        {
            Destroy(heldObject);
        }

        if (item.prefab != null && handTransform != null)
        {
            heldObject = Instantiate(item.prefab, handTransform.position, handTransform.rotation, handTransform);

            // Отключаем скрипт ItemPickUp
            ItemPickUp itemPickUp = heldObject.GetComponent<ItemPickUp>();
            if (itemPickUp != null)
            {
                itemPickUp.enabled = false;
            }

            // Отключаем коллайдер у предмета в руке
            Collider col = heldObject.GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = false;
            }

            // Делаем объект кинематическим
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    public void DropItem(Item item)
    {
        if (item != null)
        {
            Vector3 dropPosition = handTransform.position + handTransform.forward * 2f;
            GameObject droppedObject = Instantiate(item.prefab, dropPosition, Quaternion.identity);

            // Включаем скрипт ItemPickUp у выброшенного предмета
            ItemPickUp itemPickUp = droppedObject.GetComponent<ItemPickUp>();
            if (itemPickUp != null)
            {
                itemPickUp.enabled = true;
            }

            // Включаем коллайдер у выброшенного предмета
            Collider col = droppedObject.GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = true;
            }

            // Отключаем кинематику (делаем объект физическим)
            Rigidbody rb = droppedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            Debug.Log("Dropped: " + item.name);

            if (heldObject != null)
            {
                Destroy(heldObject);
                heldItem = null;
            }
        }
    }
}
