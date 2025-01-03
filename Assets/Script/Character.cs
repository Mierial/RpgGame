using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int damage;
    protected int defense;
    protected int health;
    protected int maxHealth;

    public int Damage
    {
        get { return damage; }
        set
        {
            if (value < 0) { damage = 0; }
            else { damage = value; }
        }
    }
           

    public int Health
    {
        get { return health; }
        set
        {
            if (value < 0) { health = 0; }
            else if (value > maxHealth) { health = maxHealth; }
            else { health = value; }
        }
    }
    public void ClaimDamage(int damage)
    {
        Health -= (damage - defense);
    }

    public void GetHealth(int regen)
    {
        Health += regen;
    }
}
