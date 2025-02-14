using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Creature")) // Проверка, что столкновение с врагом
        {
            Creature enemy = other.GetComponent<Creature>(); // Получение компонента Enemy
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Нанесение урона врагу
            }
            Destroy(gameObject); // Уничтожение пули после столкновения
        }
        if (other.CompareTag("Wall")) // Проверка, что столкновение с врагом
        {
            Destroy(gameObject); // Уничтожение пули после столкновения
        }
    }
}
