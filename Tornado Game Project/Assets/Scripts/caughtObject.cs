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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            isCaught = true;
            Tornado = collision.gameObject;
        }
            
    }

    private void Start()
    {
        myRigitBody = GetComponent<Rigidbody>();
        myCollision = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        StartCoroutine(pullForce());
    }

    IEnumerator pullForce()
    {

        if (isCaught)
        {
            myCollision.isTrigger = true;
            myRigitBody.useGravity = false;
            Vector3 pullDir = Tornado.transform.position - transform.position;

            myRigitBody.AddForce(pullDir * pullSpeed, ForceMode.Impulse);
            myRigitBody.AddForce(Vector3.left * (pullSpeed - 1), ForceMode.Impulse);
            myRigitBody.AddForce(Vector3.up * pullSpeed, ForceMode.Impulse);

            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale / 2, Time.deltaTime);

            if (transform.localScale.x < 0.05f)
                gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(0.01f);
    }
}
