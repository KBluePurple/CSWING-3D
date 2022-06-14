using UnityEngine;

public enum ItemType
{
    NONE,
    CORE,
    ENGINE,
    BODY,
    WEAPON,
    SPESIAL_WEAPON,
}

public class ItemManager : MonoSingleton<ItemManager>
{
    [SerializeField] GameObject _corePrefab;
    [SerializeField] GameObject _enginePrefab;
    [SerializeField] GameObject _bodyPrefab;
    [SerializeField] GameObject _weaponPrefab;
    [SerializeField] GameObject _spesialWeaponPrefab;

    public Item SpawnItem(ItemType type, Vector3 position)
    {
        Debug.Log("Item 생성");
        switch (type)
        {
            case ItemType.CORE:
                return Instantiate(_corePrefab, position, Quaternion.identity).GetComponent<Item>();
            case ItemType.ENGINE:
                return Instantiate(_enginePrefab, position, Quaternion.identity).GetComponent<Item>();
            case ItemType.BODY:
                return Instantiate(_bodyPrefab, position, Quaternion.identity).GetComponent<Item>();
            case ItemType.WEAPON:
                return Instantiate(_weaponPrefab, position, Quaternion.identity).GetComponent<Item>();
            case ItemType.SPESIAL_WEAPON:
                return Instantiate(_spesialWeaponPrefab, position, Quaternion.identity).GetComponent<Item>();
            default:
                return null;
        }
    }
}