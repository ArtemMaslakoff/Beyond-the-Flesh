using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public GameObject bulletPrefab; // Префаб пули
    public float bulletSpeed = 10f; // Скорость пули
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        // Получение позиции курсора
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0; // Убедитесь, что z-координата равна 0

        // Вычисление направления и угла
        Vector2 direction = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Применение поворота
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Проверка нажатия левой кнопки мыши
        if (Input.GetMouseButtonDown(0)) // 0 - левая кнопка мыши
        {
            Shoot(direction);
        }
    }
    void FixedUpdate()
    {
        Vector2 moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) moveInput.y = 1;
        if (Input.GetKey(KeyCode.S)) moveInput.y = -1;
        if (Input.GetKey(KeyCode.A)) moveInput.x = -1;
        if (Input.GetKey(KeyCode.D)) moveInput.x = 1;

        rb.linearVelocity = moveInput.normalized * speed;
    }
    void Shoot(Vector2 direction)
    {
        // Создание пули
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        
        // Установка скорости пули
        bulletRb.linearVelocity = direction * bulletSpeed;
    }
}
