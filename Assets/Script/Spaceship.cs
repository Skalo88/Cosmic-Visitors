using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public SpaceshipSettings SpaceShipSettings;
    
    public GameObject projectile;
    
    private int currentHealth;

    private float currentSpeed;
    private float currentAcceleration;
    private float moveInput;

    private float FireRate;
    private float MaxSpeed;

    private Rigidbody2D rb;

    

    void Awake()
    {
        SpaceShipSettings = Resources.Load<SpaceshipSettings>("SpaceshipSettings");

        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;
        currentAcceleration = SpaceShipSettings.Acceleration;
        
        // Initialize FireRate to current time
        FireRate = Time.time;
        
        // Disable rotation
        rb.freezeRotation = true; 

    }

    private void Start()
    {
        currentHealth = SpaceShipSettings.MaxHealth;
    }


     public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroySpaceship();
        }
    }

        private void DestroySpaceship()
        {
            Destroy(gameObject);
        }

    void Update()
    {
        // Get input for horizontal movement
        moveInput = Input.GetAxis("Horizontal");

        // Shooting
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= FireRate)
        {
            SpaceShipSettings.Shoot(transform);
        }
    }

    void FixedUpdate()
    {
        // Calculate target speed based on input
        float targetSpeed = moveInput * SpaceShipSettings.MaxSpeed;

        // Accelerate towards the target speed
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, currentAcceleration * Time.fixedDeltaTime);

        // Apply lateral movement
        Vector2 movement = new Vector2(currentSpeed, 0f);
        rb.velocity = movement;

        // Apply dampening to gradually slow down when no input is given
        if (moveInput == 0f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, SpaceShipSettings.Dampening * Time.fixedDeltaTime);
            MaxSpeed = targetSpeed;
        }
    }
    
}



