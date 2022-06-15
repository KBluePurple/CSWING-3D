using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
            MouseManager.Show(false);
            MouseManager.Lock(true);
            SoundManager.Instance.PlaySound("StreetLove", SoundType.BGM);
        }
    }
}