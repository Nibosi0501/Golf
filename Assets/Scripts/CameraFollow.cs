using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public void SetFollowTarget()
    {
        CinemachineVirtualCamera vCam = GetComponent<CinemachineVirtualCamera>();

        vCam.Priority = 12;
    }
}