using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class PlayerManager : MonoBehaviour
    {
        //ü��
        private float playerHp;
        //�ǵ�
        private float playerShield;
        //������
        private float playerEnergy;
        //����1, ����2
        private GameObject playerWeapon1;
        private GameObject playerWeapon2;
        //Ư����ų1, Ư����ų2
        private GameObject playerSkill1;
        private GameObject playerSkill2;
        //�ְ�ӵ�
        private float maxSpeed;
        //����ӵ�
        private float curSpeed;
        //���ӵ�
        private float playerAcceleration;
        //���ӵ�
        private float deceleration;
        //�ν�Ʈ �ӵ�, ��Ÿ��
        private float boostSpeed;
        private float boostCooltime;
        //��ü ȸ���ӵ�, ����
        private float rotationSpeed;
        //����? �� ����? ��?��?
    }
}
