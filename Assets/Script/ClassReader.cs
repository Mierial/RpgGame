using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassReader : MonoBehaviour
{
    [SerializeField] private Class ClassCharact; 
    [SerializeField] public float strenght;
    [SerializeField] public float intelect;
    [SerializeField] public float agility;
    [SerializeField] public float health;

    [SerializeField] public float buffsternght;
    [SerializeField] public float buffinelect;
    [SerializeField] public float buffagility;

    [SerializeField] public float defense;
    [SerializeField] public float damage;

    private void Awake()
    {
        strenght = ClassCharact.strenght;
        intelect = ClassCharact.intelect;
        agility = ClassCharact.agility;
        health = ClassCharact.health;
        buffsternght = ClassCharact.buffsternght;
        buffinelect = ClassCharact.buffinelect;
        buffagility = ClassCharact.buffagility;
        UpdateHaracteristic();
    }

    private void UpdateHaracteristic()
    {
        defense = (agility / 3 + strenght / 5)* 1.5f +2;
        damage = (agility / 2 + strenght / 2 + intelect / 3) + 15;
    }
    private void ClaimDamage(int damagemob)
    {
        health =- (damagemob - defense) ;
    }

    private void SaveStat() { 
    }

    private void OnApplicationPause(bool pause)
    {
        
    }
}
