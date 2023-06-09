using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public float lifetime = 2f;
    public int damage = 10;

     public void SetDamage(float value)
    {
        damage = Mathf.RoundToInt(value);
    }

    public int TakeDamage()
    {
        return damage;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        // Check if the projectile collided with an object that has a Health component
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // Destroy the projectile
        Destroy(gameObject);
    }

}

