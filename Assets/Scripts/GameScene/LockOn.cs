using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    private List<GameObject> pursuitObjects;
    [SerializeField]
    private GameObject pursuit;
    [SerializeField]
    private float shortestDistance;

    private bool isLockOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isLockOn = !isLockOn;
            FindShortestPursuit();
            transform.LookAt(pursuit.transform.position);
        }
    }

    void FindShortestPursuit()
    {
        pursuitObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pursuit"));
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
