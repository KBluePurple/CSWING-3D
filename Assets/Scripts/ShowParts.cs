using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowParts : MonoBehaviour
{
    [SerializeField] Image body;
    [SerializeField] TextMeshProUGUI stat;
    [SerializeField] TextMeshProUGUI weapon;

    private void Update()
    {
        body.sprite = BundleLoader.Instance.FindAsset(SaveManager.Instance.Parts.BodySprite);
        stat.SetText($"Core\n[ {SaveManager.Instance.Parts.Core} ]\nEngine\n[ {SaveManager.Instance.Parts.Engine} ]");
        weapon.SetText($"Weapon\n[ {SaveManager.Instance.Parts.Weapon} ]\nSWeapon\n[ {SaveManager.Instance.Parts.SpesialWeapon} ]");
    }

    public void ChangeSprite()
    {

    }
}
