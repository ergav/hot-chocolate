using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraOffsetChangeArea : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset;
    Vector3 startOffset;
    CinemachineVirtualCamera vCam;
    CinemachineCameraOffsetManager offsetmanager;

    CinemachineFramingTransposer transposer;

    public bool playerInside;

    

    void Start()
    {
        offsetmanager = GameObject.FindObjectOfType<CinemachineCameraOffsetManager>();

    }

    void Update()
    {

    }


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        offsetmanager = collision.GetComponent<CinemachineCameraOffsetManager>();
    //        offsetmanager.CameraOffset(cameraOffset);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = true;
            offsetmanager.inOffsetZone = true;
            offsetmanager.targetOffset = cameraOffset;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInside = false;
            offsetmanager.inOffsetZone = false;
        }

    }
}
