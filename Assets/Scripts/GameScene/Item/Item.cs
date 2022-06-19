using UnityEngine;
using GameScene;

public class Item : MonoBehaviour
{
    public ItemType Type { get; protected set; }

    public void SetType(ItemType type)
    {
        Type = type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound("magic_02");
            Type = ItemType.WEAPON;
            int item = Random.Range(0, 5);
            int parts = Random.Range(0, 3);

            switch (item)
            {
                case 0:
                    SaveManager.Instance.Parts.WEAPON[parts] = true;
                    UIManager.Instance.ChangeWeaponText();
                    break;
                case 1:
                    SaveManager.Instance.Parts.SWEAPON[parts] = true;
                    break;
                case 2:
                    SaveManager.Instance.Parts.BODY[parts] = true;
                    break;
                case 3:
                    SaveManager.Instance.Parts.CORE[parts] = true;
                    break;
                case 4:
                    SaveManager.Instance.Parts.ENGINE[parts] = true;
                    break;
            }

            Destroy(gameObject);
        }
    }
}