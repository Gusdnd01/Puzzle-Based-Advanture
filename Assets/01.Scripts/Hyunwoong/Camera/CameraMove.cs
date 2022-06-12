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

    private RectTransform _canvasTrm;
    private RectTransform _fadePanelRight;
    private RectTransform _fadePanelLeft;

    private Vector3 rigMax;
    private Vector3 rigMin;
    private float halfWidth;
    private void Start()
    {
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _fadePanelRight = _canvasTrm.Find("RightPanel").GetComponent<RectTransform>();
        _fadePanelLeft = _canvasTrm.Find("LeftPanel").GetComponent<RectTransform>();

        rigMax = confiner.bounds.max;
        rigMin = confiner.bounds.min;

        float otho = cmRigCam.m_Lens.OrthographicSize;
        halfWidth = otho * 16/9;

        StartCoroutine(SetFade(0.3f));
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

    IEnumerator SetFade(float sec)
    {
        yield return new WaitForSeconds(sec);
        _fadePanelRight.DOAnchorPosX(-1920, 1f);
        _fadePanelLeft.DOAnchorPosX(1920, 1f);
    }
}
