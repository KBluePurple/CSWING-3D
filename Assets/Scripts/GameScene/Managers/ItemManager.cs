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
            {
                var gameObject = Instantiate(_corePrefab, position, Quaternion.identity).GetComponent<Item>();
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                return gameObject;
            }
            case ItemType.ENGINE:
            {
                var gameObject = Instantiate(_enginePrefab, position, Quaternion.identity).GetComponent<Item>();
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                return gameObject;
            }
            case ItemType.BODY:
            {
                var gameObject = Instantiate(_bodyPrefab, position, Quaternion.identity).GetComponent<Item>();
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                return gameObject;
            }
            case ItemType.WEAPON:
            {
                var gameObject = Instantiate(_weaponPrefab, position, Quaternion.identity).GetComponent<Item>();
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                return gameObject;
            }
            case ItemType.SPESIAL_WEAPON:
            {
                var gameObject = Instantiate(_spesialWeaponPrefab, position, Quaternion.identity).GetComponent<Item>();
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                return gameObject;
            }
            default:
                return null;
        }
    }
}