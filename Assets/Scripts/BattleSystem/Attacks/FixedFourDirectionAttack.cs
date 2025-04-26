using UnityEngine;

public class FixedFourDirectionAttack : Attack
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DoAttack(Transform creatureTransform, Vector3 mousePosition)
    {
        mousePosition.z = 0; // Устанавливаем Z-координату в 0 для 2D

        // Определяем направления для четырех выстрелов
        Vector2[] directions = new Vector2[]
        {
            Vector2.up,    // Вверх
            Vector2.down,  // Вниз
            Vector2.left,  // Влево
            Vector2.right   // Вправо
        };

        // Создаем снаряды в каждом направлении
        foreach (Vector2 direction in directions)
        {
            // Создаем снаряд
            Bullet bullet = Instantiate(bulletPrefab, creatureTransform.position, Quaternion.identity);

            // Устанавливаем направление и скорость снаряда
            bullet.SetDirection(direction);
            bullet.speed = bulletPrefab.speed; // Устанавливаем скорость снаряда

            bullet.isPlayerBullet = isPlayerAttack;
        }
    }
}