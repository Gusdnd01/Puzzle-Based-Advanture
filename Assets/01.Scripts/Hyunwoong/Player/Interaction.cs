using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    Camera cam;
    [SerializeField] private GameObject QuitButtonA;
    [SerializeField] private LayerMask raycastLayer;
    private float maxDistance = 1.0f;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, maxDistance, raycastLayer);

            if (hit)
            {
                CameraManager.instance.SetHelpCamActive();
                QuitButtonA.SetActive(true);
            }
        }
    }

    public void QuitButton()
    {
        CameraManager.instance.SetRigCamActive();
        QuitButtonA?.SetActive(false);
    }
}
