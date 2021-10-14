using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public Vector3 rotateSpeed = new Vector3(100, 100, 100);

    FallingObject fallingObject;

    void Start()
    {
        if (fallingObject == null)
        {
            fallingObject = GetComponent<FallingObject>();
            if (fallingObject == null)
            {
                fallingObject = GetComponentInParent<FallingObject>();
            }
        }
    }

    void Update()
    {
        if (fallingObject.falling)
        {
            transform.Rotate(rotateSpeed.x * Time.deltaTime, rotateSpeed.y * Time.deltaTime, rotateSpeed.z * Time.deltaTime);

        }
    }
}
