using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
<<<<<<< HEAD
<<<<<<< HEAD
    public EquipmentSlot EquipSlot; // Тип слота (грудь, голова и т.д.)
    public GameObject prefab; // Префаб модели брони
=======
    public EquipmentSlot EquipSlot; 
    public GameObject prefab; 
>>>>>>> origin/test
=======
    public EquipmentSlot EquipSlot;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
    }
>>>>>>> stas-nps
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
