using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    public float size = 1f;
    public float damage = 1f;
    public PowerLevel powerLevel = PowerLevel.LVL1;
    public Aspect aspect = Aspect.NORMAL;
    public List<Effect> effects = new();
    public float speed = 10f;

    private Vector2 direction;
    public float lifetime = 5f; // Время жизни снаряда
    public bool isPlayerBullet = false;
    void Awake()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void Start()
    {
        // Запускаем корутину для уничтожения снаряда через заданное время
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    void Update()
    {
        // Двигаем снаряд в заданном направлении
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject); // Уничтожаем снаряд
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Creature")) // Проверка, что столкновение с врагом
        {
            Creature enemy = other.GetComponent<Creature>(); // Получение компонента Creature
            if (enemy.CompareTag("PlayerCreature") || enemy == null) // Проверка, что это игрок против игрока
            {
                return;
            }
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Нанесение урона врагу
            }
            Destroy(gameObject); // Уничтожение пули после столкновения
        }
        if (other.CompareTag("Wall")) // Проверка, что столкновение со стеной
        {
            Destroy(gameObject); // Уничтожение пули после столкновения
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}

public enum PowerLevel
{
    LVL1 = 1,
    LVL2 = 2,
    LVL3 = 3,
    LVL4 = 4
}

public enum Aspect
{
    NORMAL = 0, // Нет аспекта
    FLAME = 1, // Огонь
    POISON = 2, // Яд
    ICE = 3, // Лед
    LIGHTNING = 4, // Молния
}

public enum Effect
{
    Burning = 1, // Горение
    Poisoning = 2, // Отравление
    Freezing = 3, // Обморожение
    ElectricShock = 4, // Электрошок
    Bleeding = 5 // Кровотечение
}