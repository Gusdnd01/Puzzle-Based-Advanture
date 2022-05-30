using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CamMove : MonoBehaviour
{
    private float speed = 5f;

    private Rigidbody2D rb;

    private RectTransform _canvasTrm;
    private RectTransform _fadePanelRight;
    private RectTransform _fadePanelLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _fadePanelRight = _canvasTrm.Find("RightPanel").GetComponent<RectTransform>();
        _fadePanelLeft = _canvasTrm.Find("LeftPanel").GetComponent<RectTransform>();
    }
    void Update()
    {
        Vector2 dir = Vector2.right;
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(SceneMove(2f));
    }

    IEnumerator SceneMove(float sec)
    {
        Sequence seq = DOTween.Sequence();

        Image imgR = _fadePanelRight.GetComponent<Image>();

        Image imgL = _fadePanelLeft.GetComponent<Image>();

        yield return new WaitForSeconds(sec);
        seq.Append(_fadePanelRight.DOAnchorPosX(-960, 1f));
        seq.Append(imgR.DOFade(1, 0.6f));

        seq.Append(_fadePanelLeft.DOAnchorPosX(960, 1f));
        seq.Append(imgL.DOFade(1, 0.6f));

        yield return new WaitForSeconds(sec + 1f);
        SceneManager.LoadScene(1);
    }
}
