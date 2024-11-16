using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    ClassReader reader = FindObjectOfType<ClassReader>();
    WeaponReader readerw = FindObjectOfType<WeaponReader>();
    public float damage;

    private void TakeDamage()
    {
        damage = (reader.damage) / 2 + (readerw.damage) / 2; 
    }
}
