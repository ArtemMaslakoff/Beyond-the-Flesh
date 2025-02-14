using UnityEngine;

public class Creature : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
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
