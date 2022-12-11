using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoForce : MonoBehaviour
{
    public LayerMask objectLayer;
    public float pullForce;



    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f, objectLayer);
        foreach (Collider collider in hitColliders)
        {
            if (!collider.GetComponent<caughtObject>().isCaught)
            {
                GameObject hitObject = collider.gameObject;
                Vector3 targetDir = hitObject.transform.position - transform.position;

                hitObject.GetComponent<Rigidbody>().AddForce(targetDir * -pullForce, ForceMode.Impulse);
            }
        }

    }
}
