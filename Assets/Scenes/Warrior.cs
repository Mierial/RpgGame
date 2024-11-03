using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    [SerializeField] private int _stamina;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Attack(int value)
    {
        if(_stamina> value)
        {
            _stamina -= value;
        }
    }
}
