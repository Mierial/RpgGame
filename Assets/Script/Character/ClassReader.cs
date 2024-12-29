using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassReader : MonoBehaviour
{
    private MooveMeh moov; // Убираем инициализацию
    [SerializeField] private Class ClassCharact;

    public float strenght;
    public float intelect;
    public float agility;
    public float health;

    public float buffsternght;
    public float buffinelect;
    public float buffagility;

    public float defense;
    public float damage;

    public int maxhealth = 1400;

    public float Health
    {
        get { return health; }
        set
        {
            if (value < 0)
            {
                health = 0;
            }
            else if (value > maxhealth)
            {
                health = maxhealth;
            }
            else
            {
                health = value;
            }
        }
    }

    private void Awake()
    {
        // Инициализируем moov в Awake
        moov = FindObjectOfType<MooveMeh>();
        if (moov == null)
        {
            Debug.LogError("MooveMeh component not found in the scene!");
        }

        // Инициализируем характеристики, если ClassCharact задан
        if (ClassCharact != null)
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
        else
        {
            Debug.LogError("ClassCharact is not assigned in the inspector!");
        }
    }

    private void UpdateHaracteristic()
    {
        defense = (agility / 3 + strenght / 5) * 1.5f + 2;
        damage = (agility / 2 + strenght / 2 + intelect / 3) + 15;
    }

    private void ClaimDamage(int damagemob)
    {
        Health -= (damagemob - defense); // Используем -=
        if (health <= 0) // Проверяем <= 0
        {
            if (moov != null)
            {
                moov.Dead(); // Вызываем Dead, если moov не null
            }
        }
    }
}
