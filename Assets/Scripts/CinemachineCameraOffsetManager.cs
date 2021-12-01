using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraOffsetManager : MonoBehaviour
{
    Vector3 defaultOffset;
    [HideInInspector]public Vector3 targetOffset;
    Vector3 currentOffset;
    //Vector3 smoothedPos;
    CinemachineVirtualCamera vCam;
    CinemachineFramingTransposer transposer;

    [HideInInspector] public bool inOffsetZone;

    //float smoothing;

    [SerializeField] float smoothspeed = 5;
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

        currentOffset = transposer.m_TrackedObjectOffset;

        transposer.m_TrackedObjectOffset = Vector3.MoveTowards(currentOffset, targetOffset, smoothspeed * Time.deltaTime);

        if (!inOffsetZone)
        {
            targetOffset = defaultOffset;
        }
    }

    //public void CameraOffset(Vector3 offset)
    //{
    //    //transposer.m_TrackedObjectOffset = offset;
    //    transposer.m_TrackedObjectOffset = Vector3.MoveTowards(currentOffset, offset, smoothspeed * Time.deltaTime);
    //}

    //public void DefaultCameraOffset(Vector3 offset)
    //{
    //    //transposer.m_TrackedObjectOffset = offset;
    //    transposer.m_TrackedObjectOffset = Vector3.MoveTowards(currentOffset, offset, smoothspeed * Time.deltaTime);


    //}
}
