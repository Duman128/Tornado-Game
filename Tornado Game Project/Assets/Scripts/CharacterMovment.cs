using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{

    private Touch Touch;
    public float speedModifier;

    public float speed = 5;
    public float xBorderValue;
    public float zBorderValue;

    private void Start()
    {
        speedModifier = 0.01f;
        
    }

    private void FixedUpdate()
    {
        handMovement();
        Movement(speed);
        BorderTransform(transform ,xBorderValue, zBorderValue);
    }

    private void handMovement()
    {
        if(Input.touchCount > 0)
        {
            Touch = Input.GetTouch(0);
            if(Touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + Touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + Touch.deltaPosition.y * speedModifier
                    );
            }
        }
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
