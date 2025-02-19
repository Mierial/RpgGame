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
    EnemyDropLoot dropLoot;

    private int Health
    {
        get { return health; }
        set
        {
            if (value < 0) { health = 0; }
            else if (value > maxHealth) { health = maxHealth; }
            else { health = value; }
        }
    }

    public Animator animator; // Добавляем аниматор

    private void Awake()
    {
        health = EnemiInfo.health;
        damage = EnemiInfo.damage;
        defense = EnemiInfo.Defence;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        dropLoot = GetComponent<EnemyDropLoot>();
    }

    public void ClaimDamage(int damage)
    {
        int actualDamage = Mathf.Max(damage - defense, 0);
        Health -= actualDamage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }

    public void Died()
    {
        dropLoot.DropLoot();
        Debug.Log("DropItem");
    }
}
