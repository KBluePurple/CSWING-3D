using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOverlay : MonoBehaviour
{
    [SerializeField] GameObject enemyOverlayPrefab;
    Dictionary<Transform, RectTransform> enemyOverlays = new Dictionary<Transform, RectTransform>();

    private void Awake()
    {
        GameScene.PlayerManager.Instance.OnEnemyAdded += OnEnemyAdded;
        GameScene.PlayerManager.Instance.OnEnemyRemoved += OnEnemyRemoved;
    }

    private void OnEnemyAdded(Transform enemy)
    {
        Debug.Log($"Enemy added: {enemy.name}");
        RectTransform enemyOverlay = Instantiate(enemyOverlayPrefab, transform).GetComponent<RectTransform>();
        enemyOverlay.anchoredPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        enemyOverlays.Add(enemy, enemyOverlay);
    }

    private void OnEnemyRemoved(Transform enemy)
    {
        Debug.Log($"Enemy removed: {enemy.name}");
        Destroy(enemyOverlays[enemy].gameObject);
        enemyOverlays.Remove(enemy);
    }

    void Update()
    {
        foreach (KeyValuePair<Transform, RectTransform> enemyOverlay in enemyOverlays)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(enemyOverlay.Key.position);

            if (screenPoint.z < 0)
            {
                enemyOverlay.Value.GetComponent<Image>().enabled = false;
            }

            var localPoint = enemyOverlay.Value.transform.parent.InverseTransformPoint(screenPoint);
            enemyOverlay.Value.localPosition = localPoint;
        }
    }
}
