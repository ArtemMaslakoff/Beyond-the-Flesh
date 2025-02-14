using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public float smoothSpeed = 1f; // Скорость сглаживания
    public Vector3 offset; // Смещение камеры относительно игрока

    void Update()
    {
        // Определяем желаемую позицию камеры
        Vector3 desiredPosition = player.position + offset;
        
        // Сглаживаем движение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Устанавливаем позицию камеры
        transform.position = smoothedPosition;
    }
}
