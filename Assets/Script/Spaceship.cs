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

    // added for wrapping
	Renderer[] renderers;
	bool isWrappingX = false;
	bool isWrappingY = false;
    
    Transform[] ghosts = new Transform[8];
	
	float screenWidth;
	float screenHeight;

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
        
        //  added
        renderers = GetComponentsInChildren<Renderer>();
		
		var cam = Camera.main;
        
        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
		
		// The width is then equal to difference between the rightmost and leftmost x-coordinates
		screenWidth = screenTopRight.x - screenBottomLeft.x;
		// The height, similar to above is the difference between the topmost and the bottom ycoordinates
		screenHeight = screenTopRight.y - screenBottomLeft.y;
        // CreateGhostShips();

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
        ScreenWrap();

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
		
		// We need to check whether the object went off screen along the horizontal axis (X),
		// or along the vertical axis (Y).
		//
		// The easiest way to do that is to convert the ships world position to
		// viewport position and then check.
		//
		// Remember that viewport coordinates go from 0 to 1?
		// To be exact they are in 0-1 range for everything on screen.
		// If something is off screen, it is going to have
		// either a negative coordinate (less than 0), or
		// a coordinate greater than 1
		//
		// So, we get the ships viewport position
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		
		
		// Wrap it is off screen along the x-axis and is not being wrapped already
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			// The scene is laid out like a mirror:
			// Center of the screen is position the camera's position - (0, 0),
			// Everything to the right is positive,
			// Everything to the left is negative;
			// Everything in the top half is positive
			// Everything in the bottom half is negative
			// So we simply swap the current position with it's negative one
			// -- if it was (15, 0), it becomes (-15, 0);
			// -- if it was (-20, 0), it becomes (20, 0).
			newPosition.x = -newPosition.x;
			
			// If you had a camera that isn't at X = 0 and Y = 0,
			// you would have to use this instead
			// newPosition.x = Camera.main.transform.position - newPosition.x;
			
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



