using UnityEngine;

[System.Serializable]
public class ItemCount
{
    public Items item;
    public int count;

    public ItemCount(Items item, int count)
    {
        this.item = item;
        this.count = count;
    }
}
