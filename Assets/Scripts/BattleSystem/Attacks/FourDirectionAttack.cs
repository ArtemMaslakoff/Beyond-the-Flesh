using UnityEngine;

public class FourDirectionAttack : Attack
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

        // Создаем первый снаряд, который будет направлен на курсор
        Bullet bullet = Instantiate(bulletPrefab, creatureTransform.position, Quaternion.identity);
        
        // Вычисляем направление от объекта к курсору
        Vector2 directionToMouse = (mousePosition - creatureTransform.position).normalized;

        // Устанавливаем направление и скорость снаряда
        bullet.SetDirection(directionToMouse);
        bullet.speed = bulletPrefab.speed; // Устанавливаем скорость снаряда
        bullet.isPlayerBullet = isPlayerAttack;

        // Определяем углы для остальных трех снарядов относительно первого
        float angleOffset = 90f; // Угол смещения для остальных снарядов

        for (int i = 1; i <= 3; i++)
        {
            // Вычисляем угол для каждого из трех снарядов
            float angle = angleOffset * i; // 90, 180, 270 градусов
            Vector2 direction = Quaternion.Euler(0, 0, angle) * directionToMouse;

            // Создаем снаряд
            Bullet additionalBullet = Instantiate(bulletPrefab, creatureTransform.position, Quaternion.identity);

            // Устанавливаем направление и скорость снаряда
            additionalBullet.SetDirection(direction);
            additionalBullet.speed = bulletPrefab.speed; // Устанавливаем скорость снаряда
            additionalBullet.isPlayerBullet = isPlayerAttack;
        }
    }
}