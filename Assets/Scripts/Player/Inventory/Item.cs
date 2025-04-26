using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Item : MonoBehaviour
{
    public Items item;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCreature"))
        {
            Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(item);
                Destroy(gameObject); // Удаляем оригинал из мира
            }
        }
    }
}
