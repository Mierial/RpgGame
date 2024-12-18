using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] private EnemyInfo EnemiInfo;
    public int health;
    private int damage;
    private int defense;
    private int maxHealth;

    private int Health { 
        get { return health; }
        set {
            if (value < 0) { health = 0; }
            else if (value > maxHealth) {  health = maxHealth; }
            else { health = value; }
        }
    }

    private void Awake()
    {
        health = EnemiInfo.health;
        damage = EnemiInfo.damage;
        defense = EnemiInfo.Defence;
    }

    public void ClaimDamage(int damage) 
    {
        Health =- (damage - defense);
    }

    public void GetHealth(int regen) 
    {
        Health =+ regen;
    }
}
