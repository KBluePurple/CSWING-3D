using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

namespace GameScene
{
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
        [SerializeField] CinemachineVirtualCamera virtualCamera;

        private bool isSafeZone = false;

        private void Start()
        {
            virtualCamera.m_Lens.FieldOfView = 50;
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");
            float rotate = Input.GetAxis("Horizontal");

            horizontal = Mathf.Clamp(horizontal, -1f, 1f);
            vertical = Mathf.Clamp(vertical, -1f, 1f);

            Vector3 lerpVector = new Vector3(vertical * _xRotateSpeed, -horizontal * _yRotateSpeed, 0).normalized * ((Mathf.Abs(horizontal) + Mathf.Abs(vertical)) / 2);
            _rotate = Vector3.Lerp(_rotate, lerpVector, _smooth * Time.deltaTime);
            transform.Rotate(((-_rotate) + (new Vector3(0, 0, rotate) * _zRotateSpeed * -1)));
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

            Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
            // transform.Translate(transform.forward * _speed * Time.deltaTime);
            transform.position += transform.forward * _speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(LeftDash());
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(RightDash());
            }

            virtualCamera.m_Lens.FieldOfView = 50 + Mathf.Abs(_speed) / _maxSpeed * 50;
        }

        bool isPushedLeft = false;
        IEnumerator LeftDash()
        {
            if (isPushedLeft)
            {
                Debug.Log("LeftDash");
                transform.DOMove(transform.position + -transform.right * _dashSpeed, 1f);
                transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.LocalAxisAdd);
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
            //Debug.Log("�÷��̾� ����");
            yield return new WaitForSeconds(2f);
            Destroy(effect);
            // TODO : �̰� Ǯ�Ŵ��� ���� �ʿ�
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            PlayerManager.Instance.Damaged(10);

            //Debug.Log("�÷��̾� ����");
            //Destroy(gameObject);
        }
    }
}