using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Interaction : MonoBehaviour
{
    Camera cam;
    [SerializeField] private GameObject QuitButtonA;
    [SerializeField] private LayerMask raycastLayer;
    private float maxDistance = 1.0f;
    private bool isLookHouse = false;

    private Transform house;

    CameraMove _camMove;

    void Start()
    {
        cam = Camera.main;
        _camMove = FindObjectOfType<CameraMove>();
        house = GameObject.Find("HouseTransform").GetComponent<Transform>();
    }

    void Update()
    {
        HitAble();
    }

    void HitAble()
    {
        if (Input.GetMouseButtonDown(0) && isLookHouse == false)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, maxDistance, raycastLayer);

            if (hit)
            {
                house.transform.position = hit.point;
                isLookHouse = true;
                _camMove.cameraSpeed = 0;
                CameraManager.instance.SetHelpCamActive();
                QuitButtonA.SetActive(true);
            }
        }
    }

    public void QuitButton()
    {
        isLookHouse = false;    
        _camMove.cameraSpeed = 40f;
        CameraManager.instance.SetRigCamActive();
        QuitButtonA?.SetActive(false);

    }
}
