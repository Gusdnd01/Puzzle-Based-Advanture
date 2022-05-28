using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 20f;
    [SerializeField] private PolygonCollider2D confiner;
    [SerializeField] private CinemachineVirtualCamera cmRigCam;
    [SerializeField] private Image _fadePanel;

    private Vector3 rigMax;
    private Vector3 rigMin;
    private float halfWidth;
    private void Start()
    {
        rigMax = confiner.bounds.max;
        rigMin = confiner.bounds.min;

        float otho = cmRigCam.m_Lens.OrthographicSize;
        halfWidth = otho * 16/9;

        _fadePanel.DOFade(0f, 2f);
    }

    private void Update()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 pos = transform.position;

        float min = rigMin.x + halfWidth;
        float max = rigMax.x - halfWidth;

        pos.x = Mathf.Clamp(pos.x + cameraSpeed * h * Time.deltaTime, min, max);

        transform.position = pos;
    }
}
