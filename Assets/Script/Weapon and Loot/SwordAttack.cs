using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    private Collider swordCollider;

    private void Start()
    {
        
        swordCollider = sword.GetComponent<Collider>();
        swordCollider.enabled = false; 
    }

    public void StartAttack()
    {
        
        swordCollider.enabled = true;
        Debug.Log("Sword attack started!");
    }

    public void EndAttack()
    {
        
        swordCollider.enabled = false;
        Debug.Log("Sword attack ended!");
    }
}
