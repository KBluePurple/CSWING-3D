using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class PlayerLightController : MonoBehaviour
{
    private Light[] _lights;

    void Start()
    {
        _lights = GetComponentsInChildren<Light>();
    }

    void Update()
    {
        foreach (var light in _lights)
        {
            light.intensity = Mathf.Lerp(light.intensity, PlayerMove.Instance.Speed / 10, Time.deltaTime);
            light.intensity = Mathf.Clamp(light.intensity, 1, 10);
        }
    }
}
