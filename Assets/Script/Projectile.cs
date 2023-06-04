using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision logic here
        // You can access the collided object using 'collision.gameObject'
        // Apply damage or any other desired effects using the 'damage' value
    }
}
