using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public float moveSpeed = 1f;
    public float moveDistance = 1f;
    public float moveDelay = 1f;
    public float fireRate = 1f;
    public GameObject EnemyProjectile;

    private int currentHealth;
    private float moveDirection = 1f;
    private float moveTimer;
    private float fireTimer;

    private Rigidbody2D rb;


    private void Start()
    {
        currentHealth = maxHealth;
        moveTimer = moveDelay;
        fireTimer = fireRate;
    }

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

        // Disable rotation
        rb.freezeRotation = true; 
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        // Move horizontally based on moveDirection
        Vector3 newPosition = transform.position + new Vector3(moveSpeed * moveDirection * Time.deltaTime, 0f, 0f);
        transform.position = newPosition;

        // Check if the enemy needs to change direction
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0f)
        {
            moveDirection *= -1f; // Reverse the moveDirection
            moveTimer = moveDelay; // Reset the move timer
            transform.position += new Vector3(0f, -moveDistance, 0f); // Move down
        }
    }

    private void Shoot()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            // Instantiate and shoot a projectile
            GameObject projectile = Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
            
            fireTimer = fireRate; // Reset the fire timer
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with a projectile
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            TakeDamage(projectile.TakeDamage());
            Destroy(projectile.gameObject);
        }
    }
}
