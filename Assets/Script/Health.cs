using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce the current health by the damage amount
        currentHealth -= Mathf.RoundToInt(damage);

        // Check if the health reaches zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform any necessary actions when the object dies
        // For example, play death animation, remove object from the scene, etc.
        Destroy(gameObject);
    }
}
