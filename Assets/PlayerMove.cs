using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _rotate;

    [SerializeField] float _speed = 1f;
    [SerializeField] float _angleSmooth= 3f;
    [SerializeField] Image visual;

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = Mathf.Clamp(vertical, -1f, 1f);

        Vector3 lerpVector = new Vector3(-vertical, horizontal, 0).normalized * ((Mathf.Abs(horizontal) + Mathf.Abs(vertical)) / 2);
        _rotate = Vector3.Lerp(_rotate, lerpVector, _angleSmooth * Time.deltaTime);
        visual.rectTransform.anchoredPosition = new Vector2(_rotate.y, -_rotate.x) * 100;

        transform.Rotate(_rotate);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
