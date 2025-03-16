using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public CharacterSettings character;
    [SerializeField] private GameObject player;
    public HealthBar healthBar;
    private int currentHealth;

    private void Start()
    {
        HealthSet();
    }
    public void HealthSet()
    {
        ClassHerro hero = player.GetComponent<ClassHerro>();
        currentHealth = hero.Health;
        Debug.Log($"{currentHealth}");
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
