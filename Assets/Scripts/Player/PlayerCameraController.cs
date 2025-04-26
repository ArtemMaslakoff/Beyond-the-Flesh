using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public new Camera camera;
    public float smoothSpeed = 1f; // Скорость сглаживания
    public Vector3 offset; // Смещение камеры относительно игрока
    public Transform creature; // Игрок
    void Update()
    {
        // Определяем желаемую позицию камеры
        Vector3 desiredPosition = creature.position + offset;
        
        // Сглаживаем движение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Устанавливаем позицию камеры
        transform.position = smoothedPosition;
    }
}
