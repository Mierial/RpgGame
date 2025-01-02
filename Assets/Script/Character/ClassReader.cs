using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassHero : Character
{
    MooveMeh moov = FindObjectOfType<MooveMeh>();
    [SerializeField] private CharacterSettings ClassCharact;
    public float strenght;
    public float intelect;
    public float agility;
   
    

    public float buffsternght;
    public float buffinelect;
    public float buffagility;




   


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
        defense = int.((agility / 3 + strenght / 5)* 1.5f +2);
        damage = int.((agility / 2 + strenght / 2 + intelect / 3) + 15;
    }

   
}
