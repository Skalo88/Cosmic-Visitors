using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpaceshipSettings", menuName = "Create SpaceshipSettings")]
public class SpaceshipSettings : ScriptableObject

{

    public GameObject ProjectilePrefab;

    public int MaxHealth = 100;
    public float MaxSpeed = 6f;
    public float Dampening = 1f;
    public float Acceleration = 1f;
    public float FireDamage = 10f;
    public float FireRate = 10f;
    private float DamageMultiplier = 1f;
    public float Damage { get; private set; } // Add a public property for the damage value

}
