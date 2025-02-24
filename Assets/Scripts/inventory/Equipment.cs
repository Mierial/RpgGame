using UnityEngine;

public enum EquipmentSlot { Head, Chest, Legs, Feet, Weapon, Shield }

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot EquipSlot; // Тип слота (грудь, голова и т.д.)
    public GameObject prefab; // Префаб модели брони
}
