using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Info")]
public class Weapon : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private int Needlvl;





    public int NeedLvl => Needlvl;
    public float Damage => damage;
}
