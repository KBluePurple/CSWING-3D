using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlaySound("Epic Backing Track", SoundType.BGM);
    }
}
