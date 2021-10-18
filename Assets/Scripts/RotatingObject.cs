using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public Vector3 rotateSpeed = new Vector3(100, 100, 100);

    Vector3 speedRotate;

    int dirRNGX, dirRNGY, dirRNGZ;

    [SerializeField] bool rotate;

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

        speedRotate = new Vector3(Random.Range(rotateSpeed.x - (rotateSpeed.x * 0.8f), rotateSpeed.x - (rotateSpeed.x * 1.2f)), Random.Range(rotateSpeed.y - (rotateSpeed.y * 0.8f), rotateSpeed.y - (rotateSpeed.y * 1.2f)), Random.Range(rotateSpeed.z - (rotateSpeed.z * 0.8f), rotateSpeed.z - (rotateSpeed.z * 1.2f)));

        dirRNGX = Random.Range(0, 1);
        dirRNGY = Random.Range(0, 1);
        dirRNGZ = Random.Range(0, 1);


        if (dirRNGX == 1)
        {
            speedRotate.x = -speedRotate.x;
        }

        if (dirRNGY == 1)
        {
            speedRotate.y = -speedRotate.y;
        }

        if (dirRNGZ == 1)
        {
            speedRotate.z = -speedRotate.z;
        }

    }

    void Update()
    {
        if (fallingObject != null)
        {
            if (fallingObject.falling)
            {
                rotate = true;

            }
        }


        if (rotate)
        {
            transform.Rotate(speedRotate.x * Time.deltaTime, speedRotate.y * Time.deltaTime, speedRotate.z * Time.deltaTime);
        }
    }
}
