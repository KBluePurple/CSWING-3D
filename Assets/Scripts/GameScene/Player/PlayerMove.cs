using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScene;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _rotate;

    //[SerializeField] float _speed = 1f;
    public float _speed = 1f;
    [SerializeField] float _xRotateSpeed = 1f;
    [SerializeField] float _yRotateSpeed = 1f;
    [SerializeField] float _zRotateSpeed = 1f;
    [SerializeField] float _speedChange = 1f;
    [SerializeField] float _smooth = 3f;
    [SerializeField] float _maxSpeed = 10f;
    [SerializeField] float _dashSpeed = 10f;
    [SerializeField] Image visual;
    [SerializeField] GameObject explosionEffect = null;
    [SerializeField] GameObject cameraPos = null;

    private bool isSafeZone = false;

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


        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(LeftDash());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(RightDash());
        }

        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        // transform.Translate(transform.forward * _speed * Time.deltaTime);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    bool isPushedLeft = false;
    IEnumerator LeftDash()
    {
        if (isPushedLeft)
        {
            Debug.Log("LeftDash");
            transform.DOMove(transform.position + -transform.right * _dashSpeed, 1f);
            transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.LocalAxisAdd);
            // 이부분 바꾸고 싶은데
            cameraPos.transform.SetParent(null);
            yield return new WaitForSeconds(1f);
            cameraPos.transform.SetParent(transform);
            cameraPos.transform.localPosition = new Vector3(0, 6.5f, -15);
        }
        else
        {
            isPushedLeft = true;
            yield return new WaitForSeconds(0.2f);
            isPushedLeft = false;
        }
    }

    bool isPushedRight = false;
    IEnumerator RightDash()
    {
        if (isPushedRight)
        {
            Debug.Log("RightDash");
            transform.DOMove(transform.position + transform.right * _dashSpeed, 1f);
            transform.DORotate(new Vector3(0, 0, -360), 1f, RotateMode.LocalAxisAdd);

            cameraPos.transform.SetParent(null);
            yield return new WaitForSeconds(1f);
            cameraPos.transform.SetParent(transform);
            cameraPos.transform.localPosition = new Vector3(0, 6.5f, -15);
        }
        else
        {
            isPushedRight = true;
            yield return new WaitForSeconds(0.2f);
            isPushedRight = false;
        }
    }

    // 함수 사용 일단 보류
    // private void CameraRotatePin(int dir = 1)
    // {
    //     cameraPos.transform.DORotate(new Vector3(0, 0, 360 * dir), 1f, RotateMode.LocalAxisAdd);
    //     //cameraPos.transform.DOMove(transform.position + -transform.right * _dashSpeed, 1f);
    // }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PursuitBullet") || other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(PlayerExplosion());
        }

        if (other.gameObject.CompareTag("SafeZone"))
        {
            isSafeZone = true;
            SafeZoneManager.Instance.OnEnterSafeZone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SafeZone"))
        {
            isSafeZone = false;
            SafeZoneManager.Instance.OnExitSafeZone();
        }
    }

    public IEnumerator PlayerExplosion()
    {
        GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Debug.Log("플레이어 폭파");
        yield return new WaitForSeconds(2f);
        Destroy(effect);
        // TODO : 이곳 풀매니저 적용 필요
        //Destroy(gameObject);
    }
}
