using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _rotate;

    [SerializeField] float _speed = 1f;
    [SerializeField] float _rotateSpeed = 1f;
    [SerializeField] float _speedChange = 1f;
    [SerializeField] float _angleSmooth = 3f;
    [SerializeField] float _maxSpeed = 10f;
    [SerializeField] Image visual;


    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        float rotate = Input.GetAxis("Horizontal");

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = Mathf.Clamp(vertical, -1f, 1f);

        Vector3 lerpVector = new Vector3(vertical, horizontal, 0).normalized * ((Mathf.Abs(horizontal) + Mathf.Abs(vertical)) / 2);
        lerpVector += new Vector3(0, 0, rotate);
        _rotate = Vector3.Lerp(_rotate, lerpVector, _angleSmooth * Time.deltaTime);
        transform.Rotate(_rotate * _rotateSpeed * _speedChange);
        visual.rectTransform.anchoredPosition = new Vector2(_rotate.y, _rotate.x) * 100;

        _speed += Input.GetAxis("Vertical") * _speedChange * Time.deltaTime;
        _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
