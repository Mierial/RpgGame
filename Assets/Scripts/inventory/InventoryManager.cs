using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject uiPanel;
    public PlayerController playerController;
    public Transform inventoryPanel;
    public List<Slot> slots = new List<Slot>();

    public bool isOpened;

    private void Awake()
    {
        uiPanel.SetActive(true);
    }

    private void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            slots.Add(inventoryPanel.GetChild(i).GetComponent<Slot>());
        }
        uiPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
                isOpened = !isOpened;
                uiPanel.SetActive(!isOpened);
                Cursor.lockState = isOpened? CursorLockMode.Locked:CursorLockMode.None;
                Cursor.visible = !isOpened;
                playerController.enabled = isOpened;   
        }
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (Slot slot in slots)
        {
            if (slot.item == _item && (slot.amount + _amount <= _item.maxAmount))
            {
                slot.amount += _amount;
                slot.textItemAmount.text = slot.amount.ToString();
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.itemIcon); 
                slot.textItemAmount.text = _amount.ToString();
                return;
            }
        }
    }

}
