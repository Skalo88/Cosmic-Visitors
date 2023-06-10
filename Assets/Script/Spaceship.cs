using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public SpaceshipSettings SpaceShipSettings;
    private UIController uiController;

    
    public GameObject projectile;
    
    private int currentHealth;


    private float currentSpeed;
    private float currentAcceleration;
    private float moveInput;

    private float FireRate;
    private float MaxSpeed;

    private Rigidbody2D rb;

    // added for wrapping
	Renderer[] renderers;
	bool isWrappingX = false;
	bool isWrappingY = false;


	float screenWidth;
	float screenHeight;
    [SerializeField] private HealthController _healthcontroller;



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
        
        StartScreenSwap();
/*
        uiController = FindObjectOfType<UIController>();
        FindObjectOfType<GameScoreController>().UpdateLives(currentHealth);
        uiController.UpdateLivesIcons(currentHealth);
*/
           
        }
    
    void Update()
    {

        ScreenWrap();
        /*
        uiController.UpdateLivesIcons(currentHealth);
        */

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
    private void StartScreenSwap()
         {
        renderers = GetComponentsInChildren<Renderer>();
		var cam = Camera.main;
        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
		// The width is then equal to difference between the rightmost and leftmost x-coordinates
		screenWidth = screenTopRight.x - screenBottomLeft.x;
		// The height, similar to above is the difference between the topmost and the bottom ycoordinates
		screenHeight = screenTopRight.y - screenBottomLeft.y;
        }


   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // update healthController
  
        if (currentHealth <= 0)
        {
            _healthcontroller.playerHealth = _healthcontroller.playerHealth - 1; 
            _healthcontroller.UpdateHealth(); 
            if (_healthcontroller.playerHealth <= 0)
            {
                DestroySpaceship();
            }
            else
            {
                currentHealth = SpaceShipSettings.MaxHealth;

            }
        }

    }

       private void DestroySpaceship()
       {

            Destroy(gameObject);
       }

    void ScreenWrap()
	{	
		// If all parts of the object are invisible we wrap it around
		foreach(var renderer in renderers)
		{
			if(renderer.isVisible)
			{
				isWrappingX = false;
				isWrappingY = false;
				return;
			}
		}

		// If we're already wrapping on both axes there is nothing to do
		if(isWrappingX && isWrappingY) {
			return;
		}
		var cam = Camera.main;
		var newPosition = transform.position;
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
	
		// Wrap it is off screen along the x-axis and is not being wrapped already
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			newPosition.x = -newPosition.x;
			
			isWrappingX = true;
		}
		
		// Wrap it is off screen along the y-axis and is not being wrapped already
		if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
		{
			newPosition.y = -newPosition.y;
			
			isWrappingY = true;
		}
		
		//Apply new position
		transform.position = newPosition;
	}
    
}
