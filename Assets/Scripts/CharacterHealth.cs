using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public CharacterSettings character;
    public HealthBar healthBar;
    private int currentHealth;

    private void Start()
    {
        currentHealth = character.Health;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        healthBar.SetHealth(currentHealth); 
        Debug.Log("Игрок получил урон! Осталось HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(character.name + " погиб!");
    }
}
