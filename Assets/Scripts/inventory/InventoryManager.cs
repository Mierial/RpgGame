using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour { 

    #region Singleton
    public static InventoryManager Instance;

    private void Awake() {
        if (Instance != null) {
            Debug.LogWarning("more than 1 instance");
            return;
        }

        Instance = this;
    }
    #endregion 

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;

    public bool Add(Item item) {
        if (items.Count >= space) {
            Debug.Log("Not enough space in inventory.");
            return false;
        }

        items.Add(item);
        onItemChangedCallback?.Invoke();
        return true;
    }

    public void RemoveItem(Item item) {
        items.Remove(item);
    }
}
