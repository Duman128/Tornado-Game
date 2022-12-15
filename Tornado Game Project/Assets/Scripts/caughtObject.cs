using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class caughtObject : MonoBehaviour
{
    GameObject Tornado;
    Rigidbody myRigitBody;
    Collider myCollision;
    public float pullSpeed = 2;
    public bool isCaught;
    TornadoForce tornadoForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            myRigitBody.velocity = Vector3.zero;
            isCaught = true;
        }
    }

    private void Awake()
    {
        Tornado = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        tornadoForce = Tornado.GetComponent<TornadoForce>();
        myRigitBody = GetComponent<Rigidbody>();
        myCollision = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        StartCoroutine(pullForce());
    }

    IEnumerator pullForce()
    {
        if(Physics.CheckSphere(Tornado.transform.position, tornadoForce.forceRadius + 1, tornadoForce.objectLayer))
        {

            if (isCaught)
            {
                myCollision.isTrigger = true;
                Vector3 pullDir = Tornado.transform.position - transform.position;

                transform.parent = Tornado.transform;
                myRigitBody.useGravity = false;

                myRigitBody.AddForce(pullDir * pullSpeed * 3, ForceMode.Force);
                myRigitBody.AddForce(Vector3.up * pullSpeed * 5, ForceMode.Force);

                transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale / 2, Time.deltaTime);

                if (transform.localScale.x < 0.05f)
                    gameObject.SetActive(false);
            }

        }
        yield return new WaitForSeconds(0.01f);
    }
}
