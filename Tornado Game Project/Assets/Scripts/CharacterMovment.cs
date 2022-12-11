using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement(speed);
    }

    private void Movement(float moveSpeed)
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        

        Vector3 moveDirection = new Vector3(xAxis, .0f, yAxis).normalized;
        transform.Translate(moveSpeed * moveDirection * Time.deltaTime);
    }

}
