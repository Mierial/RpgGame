using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "atakedpoint")
        {
          Weapon weapon = other.gameObject.GetComponent<Weapon>();
          
        EnemyCharacter enemy = FindAnyObjectByType<EnemyCharacter>();

            int damage = (int)weapon.Damage;

            enemy.ClaimDamage(damage);
        }
    }
}
