using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword; // Перетяни сюда меч в инспекторе
    private Collider swordCollider;
    InventoryManager inventoryManager;

    private void Start()
    {
        if (sword != null)
        {
            swordCollider = sword.GetComponent<Collider>();
        }
        else
        {
        
        }
    }

    public void StartAttack()
    {
        if (swordCollider != null)
        {
            swordCollider.isTrigger = true;
        }
    }
    public void EndAttack()
    {
        if (swordCollider != null)
        {
            swordCollider.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyCharacter enemy = other.GetComponent<EnemyCharacter>();
            if (enemy != null)
            {
                enemy.ClaimDamage(100);
            }
        }
        
        
    }
}
