using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceshipSettings", menuName = "Create SpaceshipSettings")]
public class SpaceshipSettings : ScriptableObject
{
    public GameObject ProjectilePrefab;

    public int MaxHealth = 100;

    public int MaxLives = 3;

    public float MaxSpeed = 6f;
    public float Dampening = 1f;
    public float Acceleration = 1f;
    public float FireDamage = 10f;
    public float FireRate = 1f;
    public float DamageMultiplier = 1f;
    public float ProjectileSpeed = 1f;


    public void Shoot(Transform shooter)
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(ProjectilePrefab, shooter.position, shooter.rotation);
        Projectile projectileComponent = projectile.GetComponent<Projectile>();
        

        // Set damage value
        projectileComponent.SetDamage(FireDamage);

        // Apply velocity to the projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = shooter.up * ProjectileSpeed;
        
    }


    public void ApplyDamageMultiplier(float multiplier)
    {
        DamageMultiplier = multiplier;
    }
    
}
