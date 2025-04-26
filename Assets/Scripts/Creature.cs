using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Health
    public float maxHealth;
    public float currentHealth;
    //

    // Speed
    public float movementSpeed;
    public float rotationSpeed;
    //

    // Size
    public float bodySize;
    //

    // Attack
    public Attack attack;
    public float attackCooldown;
    //

    // Defense
    public float defense;
    public List<AspectImmunity> aspectImmunities;
    //

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) { Die(); }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}

public class AspectImmunity
{
    public Aspect aspect;
    public float immunityValue;
}