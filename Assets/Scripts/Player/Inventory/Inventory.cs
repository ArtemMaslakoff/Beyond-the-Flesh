using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemCount> itemCounts = new List<ItemCount>();

    // Метод для добавления предмета в инвентарь
    public void AddItem(Items item)
    {
        // Проверяем, есть ли уже этот предмет в инвентаре
        ItemCount existingItemCount = itemCounts.Find(ic => ic.item == item);
        if (existingItemCount != null)
        {
            existingItemCount.count++; // Увеличиваем количество
        }
        else
        {
            itemCounts.Add(new ItemCount(item, 1)); // Добавляем новый предмет
        }

        Debug.Log("Собран предмет: " + item + ", количество: " + GetItemCount(item));
    }

    // Метод для получения количества предмета
    public int GetItemCount(Items item)
    {
        ItemCount existingItemCount = itemCounts.Find(ic => ic.item == item);
        return existingItemCount != null ? existingItemCount.count : 0;
    }
}