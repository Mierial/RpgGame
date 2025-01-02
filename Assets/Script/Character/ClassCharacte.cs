using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Character", menuName = "Character Info")]

public class CharacterSettings : ScriptableObject
{
    [Header("Haracteristik")]
    public float strenght;
    public float intelect;
    public float agility;
    public int health;
    [Header("Buff stats")]
    public float buffsternght;
    public float buffinelect;
    public float buffagility;


    public float Strenght => strenght;
    public float Intelect => intelect;
    public float Agility => agility;
    public float Health => health;
    public float Buffsternght => buffsternght;
    public float Buffinelect => buffinelect;
    public float Buffagility => buffagility;


}
