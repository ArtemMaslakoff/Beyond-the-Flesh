using UnityEngine;

public class OneDirectionAttack : Attack
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

        // Создаем снаряд
        Bullet bullet = Instantiate(bulletPrefab, creatureTransform.position, Quaternion.identity);

        // Вычисляем направление от объекта к курсору
        Vector2 direction = (mousePosition - creatureTransform.position).normalized;

        // Устанавливаем направление и скорость снаряда
        bullet.SetDirection(direction);
        bullet.speed = bulletPrefab.speed; // Устанавливаем скорость снаряда

        bullet.isPlayerBullet = isPlayerAttack;
    }
}
