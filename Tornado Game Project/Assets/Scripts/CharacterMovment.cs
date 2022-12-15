using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;

    public float xBorderValue;
    public float zBorderValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement(speed);
        BorderTransform(transform ,xBorderValue, zBorderValue);
    }

    private void Movement(float moveSpeed)
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        

        Vector3 moveDirection = new Vector3(xAxis, .0f, yAxis).normalized;
        transform.Translate(moveSpeed * moveDirection * Time.deltaTime);

    }

    static public void BorderTransform(Transform GameObject,float x, float z)
    {
        if (GameObject.position.x >= x)
            GameObject.position = new Vector3(x, GameObject.position.y, GameObject.position.z);
        if (GameObject.position.x <= -x)
            GameObject.position = new Vector3(-x, GameObject.position.y, GameObject.position.z);
        if (GameObject.position.z >= z)
            GameObject.position = new Vector3(GameObject.position.x, GameObject.position.y, z);
        if (GameObject.position.z <= -z)
            GameObject.position = new Vector3(GameObject.position.x, GameObject.position.y, -z);
    }
}
