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
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _fadePanelRight = _canvasTrm.Find("RightPanel").GetComponent<RectTransform>();
        _fadePanelLeft = _canvasTrm.Find("LeftPanel").GetComponent<RectTransform>();
    }

    public void StartStage1()
    {
        StartCoroutine(StartC(1.5f));
    }

    IEnumerator StartC(float sec)
    {
        yield return new WaitForSeconds(sec);
        _fadePanelRight.DOAnchorPosX(-960, 1f);
        _fadePanelLeft.DOAnchorPosX(960, 1f);

        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(2);
    }
}
