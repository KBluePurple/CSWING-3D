using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] GameObject bulletPos = null;

    private bool isSkill = false;
    private float curdelay = 0f;
    private float skillDelay = 0f;
    private int energy = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (SaveManager.Instance.Parts.Weapon)
            {
                case WeaponPart.G_01:
                    G_01_ActiveSkill();
                    break;
                case WeaponPart.L_01:
                    L_01_ActiveSkill();
                    break;
                case WeaponPart.M_01:
                    M_01_ActiveSkill();
                    break;
            }
        }

        if (isSkill)
        {
            curdelay += Time.deltaTime;
        }
    }

    void G_01_ActiveSkill()
    {
        isSkill = true;
        skillDelay = 5f;

        PlayerManager.Instance.Stat.Shield += PlayerManager.Instance.Stat.Energy;
        PlayerManager.Instance.Stat.Energy -= PlayerManager.Instance.Stat.Energy;
        SoundManager.Instance.PlaySound("electronic_02");

        if (curdelay >= skillDelay)
        {
            isSkill = false;

            curdelay = 0f;
        }
    }

    void L_01_ActiveSkill()
    {
        isSkill = true;
        skillDelay = 25f;
        energy = 75;

        Time.timeScale = 0.5f;

        if (PlayerManager.Instance.Stat.Energy >= energy)
        {
            PlayerManager.Instance.Stat.Energy -= PlayerManager.Instance.Stat.Energy;
            SoundManager.Instance.PlaySound("skill2");
        }
        else
        {
            Debug.Log("������ ����");
        }

        if (curdelay >= 7f)
        {
            Time.timeScale = 1f;
        }
        if (curdelay >= skillDelay)
        {
            isSkill = false;
            curdelay = 0f;
        }
    }

    void M_01_ActiveSkill()
    {
        isSkill = true;
        energy = 20;
        skillDelay = 15f;

        if (PlayerManager.Instance.Stat.Energy >= energy)
        {
            PlayerManager.Instance.Stat.Energy -= PlayerManager.Instance.Stat.Energy;
            SoundManager.Instance.PlaySound("Missile - Shot 4");
        }
        else
        {
            Debug.Log("������ ����");
        }

        GameObject bullet = GetComponent<PlayerAttack>().bulletPre;
        bullet.transform.localScale = new Vector3(10f, 10f, 10f);
        Instantiate(bullet, bulletPos.transform);

        if (curdelay >= skillDelay)
        {
            isSkill = false;
            curdelay = 0f;
        }

    }
}
