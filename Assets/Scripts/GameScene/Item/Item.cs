using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType Type { get; protected set; }

    public void SetType(ItemType type)
    {
        Type = type;
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO : 먹는거 만들어줄 사람 구함
    }
}