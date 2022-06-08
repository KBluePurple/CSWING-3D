using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class SafeZoneManager : MonoSingleton<SafeZoneManager>
    {
        [SerializeField] PlayerMove playerMove = null;
        Coroutine _safeZoneCountDownCoroutine;

        public Action<int> OnSafeZoneCountDown;

        public void OnEnterSafeZone()
        {
            if (_safeZoneCountDownCoroutine != null)
            {
                StopCoroutine(_safeZoneCountDownCoroutine);
            }
        }

        public void OnExitSafeZone()
        {
            _safeZoneCountDownCoroutine = StartCoroutine(SafeZoneCountDown());
        }

        private IEnumerator SafeZoneCountDown()
        {
            float time = 10f;
            while (time > 0)
            {
                OnSafeZoneCountDown?.Invoke((int)time);
                time -= 1;
                yield return new WaitForSeconds(1);
            }
            playerMove.ResetPosition();
            OnSafeZoneCountDown?.Invoke(0);
        }
    }
}