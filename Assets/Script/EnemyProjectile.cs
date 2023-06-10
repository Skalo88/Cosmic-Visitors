using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 2f;
    public int damage = 10;

     public  int EnemyProjectileDamage = 1;



     public void SetDamage(float value)
    {
        damage = Mathf.RoundToInt(value);
    }

    public int GetDamage()
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
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collides with the player
        Spaceship spaceship = other.GetComponent<Spaceship>();
        if (spaceship != null)
        {
            spaceship.TakeDamage(damage);

            //detroy the bullet 
            Destroy(gameObject);
        }
    }
}


