using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D creatureRigidbody2D;
    private float movementSpeed;
    public Camera camera;
    void Start()
    {

    }
    void FixedUpdate()
    {
        Vector2 moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) moveInput.y = 1;
        if (Input.GetKey(KeyCode.S)) moveInput.y = -1;
        if (Input.GetKey(KeyCode.A)) moveInput.x = -1;
        if (Input.GetKey(KeyCode.D)) moveInput.x = 1;

        creatureRigidbody2D.linearVelocity = moveInput.normalized * movementSpeed;
    }
    void Update()
    {
        // Проверяем, нажата ли клавиша пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Clicked space");
            // Вызываем метод для уничтожения объекта
            Transgress();
        }
    }
    public void Transgress()
    {
        GameObject clickedObject = GetObjectUnderMouse();
        if (clickedObject != null && clickedObject != GetComponent<Player>().creature.gameObject)
        {
            // Проверяем, имеет ли объект тег "Creature"
            if (clickedObject.CompareTag("Creature"))
            {
                //Destroy(clickedObject);
                GetComponent<Player>().SetCreature(clickedObject.GetComponent<Creature>());
            }
            else
            {
                Debug.Log("Clicked object is not a Creature.");
            }
        }
    }

    public void Set(float movementSpeed, Rigidbody2D creatureRigidbody2D, Camera camera)
    {
        this.creatureRigidbody2D = creatureRigidbody2D;
        this.movementSpeed = movementSpeed;
        this.camera = camera;
    }
    private GameObject GetObjectUnderMouse()
    {
        // Получаем позицию мыши в мировых координатах
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = camera.nearClipPlane; // Устанавливаем Z-координату

        Vector2 mousePosition = camera.ScreenToWorldPoint(mouseScreenPosition);
        Debug.Log("Mouse position in world: " + mousePosition);

        // Проверяем, есть ли коллайдер в этой точке
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider != null)
        {
            return hitCollider.gameObject; // Возвращаем объект, на который наведен курсор
        }

        return null;
    }
}
