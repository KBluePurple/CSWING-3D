using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _rotate;

    [SerializeField] float _speed = 1f;
    [SerializeField] float _xRotateSpeed = 1f;
    [SerializeField] float _yRotateSpeed = 1f;
    [SerializeField] float _zRotateSpeed = 1f;
    [SerializeField] float _speedChange = 1f;
    [SerializeField] float _smooth = 3f;
    [SerializeField] float _maxSpeed = 10f;
    [SerializeField] Image visual;
    [SerializeField] GameObject explosionEffect = null;

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        float rotate = Input.GetAxis("Horizontal");

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = Mathf.Clamp(vertical, -1f, 1f);

        Vector3 lerpVector = new Vector3(vertical * _xRotateSpeed, -horizontal * _yRotateSpeed, 0).normalized * ((Mathf.Abs(horizontal) + Mathf.Abs(vertical)) / 2);
        _rotate = Vector3.Lerp(_rotate, lerpVector, _smooth * Time.deltaTime);
        transform.Rotate(((-_rotate) + (new Vector3(0, 0, rotate) * _zRotateSpeed * -1)) * _speedChange);
        visual.rectTransform.anchoredPosition = new Vector2(-_rotate.y, _rotate.x) * 100;

        float speed = Input.GetAxis("Vertical");

        if (speed < 0 && Input.GetKey(KeyCode.Space))
        {
            _speed = Mathf.Lerp(_speed, 0f, Time.deltaTime * (1 / _speedChange));
            speed = 0;
        }
        else
        {
            _speed += speed * _speedChange * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, -(_maxSpeed / 2), _maxSpeed);
        }
        transform.Translate(transform.forward * _speed * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                StartCoroutine(RightDash());
            }
            else
            {
                StartCoroutine(LeftDash());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PursuitBullet"))
        {
            PlayerExplosion();
        }
    }

    public void PlayerExplosion()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Debug.Log("?÷???? ????");
        //Destroy(gameObject);
    }

    bool isLeftPushed = false;
    IEnumerator LeftDash()
    {
        if (isLeftPushed)
        {
            // 대쉬
        }
        else
        {
            isLeftPushed = true;
            yield return new WaitForSeconds(0.2f);
            isLeftPushed = false;
        }
    }

    bool isRightPushed = false;
    IEnumerator RightDash()
    {
        if (isRightPushed)
        {
            // 대쉬
        }
        else
        {
            isRightPushed = true;
            yield return new WaitForSeconds(0.2f);
            isRightPushed = false;
        }
    }
}
