using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private RectTransform _canvasTrm;
    private RectTransform _fadePanelRight;
    private RectTransform _fadePanelLeft;

    private void Start()
    {
        _fadePanelRight = _canvasTrm.Find("RightPanel").GetComponent<RectTransform>();
        _fadePanelLeft = _canvasTrm.Find("LeftPanel").GetComponent<RectTransform>();
    }

    public void StartStage1()
    {
        StartCoroutine(StartC(1.5f));
    }

    IEnumerator StartC(float sec)
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
        SceneManager.LoadScene(2);
    }
}
