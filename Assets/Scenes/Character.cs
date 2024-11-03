using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    private int _health = 100;

    private int _maxHealth = 100;

    public int Health
    {
        get { return _health; }
        set
        {
            if(value < 0)
            {
                _health = 0;
            }
            else if(value > _maxHealth) 
            { 
                _maxHealth = 100;
            }
            else
            {
                _health = value;
            }
        }
    }

    private void Start()
    {
        _health = _maxHealth;
    }

    public virtual void TakeDamage(int value)
    {
        _health -= value;
    }

    public virtual void GetHealth(int value)
    {
        _health += value;
    }
    public abstract void Attack(int value);

}
