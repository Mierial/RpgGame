using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSettings weapon;
    public int needLvl;
    public int Damage;

    private void Awake()
    {
        Damage = weapon.Damage;
        needLvl = weapon.NeedLvl;
    }
}
