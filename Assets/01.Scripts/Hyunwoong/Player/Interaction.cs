using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    Camera cam;
    [SerializeField] private GameObject QuitButtonA;
    private RectTransform questImage;
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
        questImage = GameObject.Find("Canvas/QuestImage").GetComponent<RectTransform>();

        questImage.gameObject.SetActive(false);
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

                StartCoroutine(QuestImageMove());
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

    IEnumerator QuestImageMove()
    {
        yield return new WaitForSeconds(2.5f);

        questImage.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(questImage.DOScale(new Vector3(1.2f, 1.2f), 0.4f));
        seq.Append(questImage.DOScale(new Vector3(0.9f, 0.9f), 0.1f));
        seq.Append(questImage.DOScale(new Vector3(1f, 1f), 0.1f));
        seq.Insert(0, questImage.DORotate(new Vector3(0, 720f, 0), 0.6f, RotateMode.FastBeyond360));
    }
}
