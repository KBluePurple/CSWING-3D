using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float rayMaxDistance = 30f;
    [SerializeField]
    private Transform rayTransform;
    private RaycastHit rayHit;

    void Update()
    {
        Debug.DrawRay(rayTransform.position, (transform.position - rayTransform.position) * rayMaxDistance, Color.red, 0.1f);
        if (Physics.Raycast(rayTransform.position, (transform.position - rayTransform.position), out rayHit, rayMaxDistance))
        {
            Debug.Log("적 감지");
        }
    }
}
