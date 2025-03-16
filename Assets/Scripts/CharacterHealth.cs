using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public CharacterSettings character;
    public HealthBar healthBar;
    private int currentHealth;
    public ArmorBar armorBar;
    private int currentArmor;

    private void Start()
    {
        currentHealth = character.Health;
        healthBar.SetHealth(currentHealth);

        currentArmor = character.armor;
        armorBar.SetHealth(currentArmor);
    }


    public void TakeDamage(int damage)
    {
        if (currentArmor > 0)
        {
            int damageToArmor = Mathf.Min(damage, currentArmor);
            currentArmor -= damageToArmor;
            damage -= damageToArmor;
            armorBar.SetHealth(currentArmor);
        }

        if (damage > 0)
        {
            currentHealth -= damage;
            if (currentHealth < 0) currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {

    }
}
