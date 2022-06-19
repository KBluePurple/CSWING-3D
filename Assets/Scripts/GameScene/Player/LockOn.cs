using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOn : MonoBehaviour
{
    private List<GameObject> pursuitObjects;
    [SerializeField]
    private float shortestDistance;

    private GameObject pursuit;
    private bool isLockOn = false;

    [SerializeField]
    private GameObject lockOnTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isLockOn = !isLockOn;
            lockOnTarget.SetActive(isLockOn);
            FindShortestPursuit();
        }

        if (pursuit != null)
        {
            if (isLockOn)
            {
                transform.LookAt(pursuit.transform);
            }
        }
    }

    void FindShortestPursuit()
    {

        pursuitObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pursuit"));
        pursuitObjects.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        if (pursuitObjects.Count >= 1)
        {

            shortestDistance = Vector3.Distance(gameObject.transform.position, pursuitObjects[0].transform.position);
            pursuit = pursuitObjects[0];

            foreach (GameObject enemyItem in pursuitObjects)
            {
                float distance = Vector3.Distance(transform.position, enemyItem.transform.position);

                if (distance < shortestDistance)
                {
                    pursuit = enemyItem;
                    shortestDistance = distance;
                }
            }
        }
    }
}
