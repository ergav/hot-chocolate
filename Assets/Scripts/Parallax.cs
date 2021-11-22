using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startPos, startPosY;
    public Camera cam;
    public float parallaxEffect;

    [SerializeField] bool dontLoop;
    void Start()
    {
        startPos = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.localPosition.x * (1 - parallaxEffect));
        float dist = (cam.transform.localPosition.x * parallaxEffect);

        float disty = (cam.transform.localPosition.y * parallaxEffect);

        transform.localPosition = new Vector3(startPos + dist, startPosY + disty, transform.localPosition.z);

        if (!dontLoop)
        {
            if (temp > startPos + length)
            {
                startPos += length;
            }
            else if (temp < startPos - length)
            {
                startPos -= length;
            }
        }

    }
}
