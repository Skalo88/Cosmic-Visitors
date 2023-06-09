using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/Enemy Settings", order = 1)]
public class EnemyParameters : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float moveDistance = 1f;
    public float moveDelay = 1f;

    [Header("Shooting")]
    
    public float fireRate = 1f;
    public GameObject EnemyProjectile;

    [Header("Health")]
    public int maxHealth = 100;
}
