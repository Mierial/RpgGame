using UnityEngine;
using System.Collections.Generic;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private Equipment[] currentEquipment;

    [Header("Слоты для брони")]
    public Transform headSlot;
    public Transform chestSlot;
    public Transform legsSlot;
    public Transform feetSlot;
    public Transform weaponSlot;
    public Transform shieldSlot;

    private Dictionary<EquipmentSlot, Transform> slotTransforms;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        // Заполняем словарь с трансформами слотов
        slotTransforms = new Dictionary<EquipmentSlot, Transform>()
        {
            { EquipmentSlot.Head, headSlot },
            { EquipmentSlot.Chest, chestSlot },
            { EquipmentSlot.Legs, legsSlot },
            { EquipmentSlot.Feet, feetSlot },
            { EquipmentSlot.Weapon, weaponSlot },
            { EquipmentSlot.Shield, shieldSlot }
        };
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.EquipSlot;
        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            InventoryManager.Instance.Add(oldItem);
            DestroyEquippedItem(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        SpawnEquipmentModel(newItem);
    }

    private void SpawnEquipmentModel(Equipment equipment)
    {
        if (equipment.prefab == null) return;

        if (slotTransforms.TryGetValue(equipment.EquipSlot, out Transform slotTransform))
        {
            GameObject newEquip = Instantiate(equipment.prefab, slotTransform);
            newEquip.transform.localPosition = Vector3.zero;
            newEquip.transform.localRotation = Quaternion.identity;
        }
    }

    private void DestroyEquippedItem(Equipment oldItem)
    {
        if (slotTransforms.TryGetValue(oldItem.EquipSlot, out Transform slotTransform))
        {
            if (slotTransform.childCount > 0)
            {
                Destroy(slotTransform.GetChild(0).gameObject);
            }
        }
    }
}
