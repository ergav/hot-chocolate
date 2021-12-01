using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraOffsetManager : MonoBehaviour
{
    Vector3 defaultOffset;
    [HideInInspector]public Vector3 offsetAmount;
    Vector3 currentOffset;
    //Vector3 smoothedPos;
    CinemachineVirtualCamera vCam;
    CinemachineFramingTransposer transposer;

    [HideInInspector] public bool inOffsetZone;

    float smoothing;

    //[SerializeField] float smoothDuration = 1;
    //float smoothTimer;



    void Start()
    {
        vCam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        transposer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        defaultOffset = transposer.m_TrackedObjectOffset;
    }

    void Update()
    {
        //smoothing = smoothTimer / smoothDuration;

        transposer.m_TrackedObjectOffset = currentOffset;

        if (inOffsetZone)
        {
            CameraOffset(offsetAmount);
        }
        else
        {
            DefaultCameraOffset(defaultOffset);
        }
    }

    public void CameraOffset(Vector3 offset)
    {
        currentOffset = offset;

    }

    public void DefaultCameraOffset(Vector3 offset)
    {
        currentOffset = offset;

    }
}
