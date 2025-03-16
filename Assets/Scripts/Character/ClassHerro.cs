using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassHerro : Character
{
    
    [SerializeField] private CharacterSettings ClassCharact;
    public int strenght;
    public int intelect;
    public int agility;
    private void Awake()
    {
        strenght = ClassCharact.Strength;
        intelect = ClassCharact.Intellect;
        agility = ClassCharact.agility;
        health = ClassCharact.health;
        HealthUp();
    }
    
    public void HealthUp()
    {
        health = (strength * 10) + (agility * 10) + (intelect * 10);
    }
    public void HaracteristicUp(int lvl)
    {
        strenght += 2 * lvl;
        agility += 1 * lvl;
        intelect += 1 * lvl;
        HealthUp();
    }

   


}


