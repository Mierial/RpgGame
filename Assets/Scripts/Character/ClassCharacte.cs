using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character Info")]
public class CharacterSettings : ScriptableObject
{
    [Header("Characteristics")]
    public int strength;
    public int intellect;
    public int agility;
    public int health;


    public int Strength => strength;
    public int Intellect => intellect;
    public int Agility => agility;
    public int Health => health;
 

    public void ModifyHealth(int amount)
    {
        health += amount;
        if (health < 0) health = 0;
    }
}
