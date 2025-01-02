using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    ClassReader reader = FindObjectOfType<ClassReader>();
    Weapon readerw = FindObjectOfType<Weapon>();
    public float damage;

    private void TakeDamage()
    {
        damage = (reader.damage) / 2 + (readerw.damage) / 2; 
    }
}
