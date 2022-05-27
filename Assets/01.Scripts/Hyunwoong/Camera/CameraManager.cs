using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private CinemachineVirtualCamera cmPlayerCam;
    [SerializeField] private CinemachineVirtualCamera cmHelpCam;

    private const int backPriority = 10;
    private const int frontPriority = 15;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple CameraManager instance is running");
        }
        instance = this;
    }

    public void SetRigCamActive()
    {
        cmPlayerCam.Priority = frontPriority;
        cmHelpCam.Priority = backPriority;
    }
    public void SetHelpCamActive()
    {
        cmHelpCam.Priority = frontPriority;
        cmPlayerCam.Priority = backPriority;
    }
}
