using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type { get; protected set; }

    public void SetType(ItemType type)
    {
        Type = type;
    }
}