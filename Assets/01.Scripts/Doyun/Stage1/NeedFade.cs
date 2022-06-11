using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NeedFade : MonoBehaviour
{
    [SerializeField] private List<Image> _waterImgList = new List<Image>();
    [SerializeField] private List<Image> _zeroSheepImgList = new List<Image>();

    private Sequence sq;
    private float fadeTime = 0.5f;

    private void Start()
    {
        ImgFade();
    }

    private void ImgFade()
    {
        sq = DOTween.Sequence();

        //���� �̹��� ���̵� �ƿ�
        sq.Append(_waterImgList[0].DOFade(0.2f, fadeTime));
        sq.Join(_waterImgList[1].DOFade(0.2f, fadeTime));
        sq.Join(_waterImgList[2].DOFade(0.2f, fadeTime));
        sq.Join(_waterImgList[3].DOFade(0.2f, fadeTime));
        sq.Join(_waterImgList[4].DOFade(0.2f, fadeTime));
        //���� �̹��� ���̵� �ƿ�
        sq.Join(_zeroSheepImgList[0].DOFade(0.2f, fadeTime));
        sq.Join(_zeroSheepImgList[1].DOFade(0.2f, fadeTime));
        sq.Join(_zeroSheepImgList[2].DOFade(0.2f, fadeTime));
        sq.Join(_zeroSheepImgList[3].DOFade(0.2f, fadeTime));
        sq.Join(_zeroSheepImgList[4].DOFade(0.2f, fadeTime));
        //���� �̹��� ���̵� ��
        sq.Append(_waterImgList[0].DOFade(0.7f, fadeTime));
        sq.Join(_waterImgList[1].DOFade(0.7f, fadeTime));
        sq.Join(_waterImgList[2].DOFade(0.7f, fadeTime));
        sq.Join(_waterImgList[3].DOFade(0.7f, fadeTime));
        sq.Join(_waterImgList[4].DOFade(0.7f, fadeTime));
        //���� �̹��� ���̵� ��
        sq.Join(_zeroSheepImgList[0].DOFade(0.7f, fadeTime));
        sq.Join(_zeroSheepImgList[1].DOFade(0.7f, fadeTime));
        sq.Join(_zeroSheepImgList[2].DOFade(0.7f, fadeTime));
        sq.Join(_zeroSheepImgList[3].DOFade(0.7f, fadeTime));
        sq.Join(_zeroSheepImgList[4].DOFade(0.7f, fadeTime));
        //�ٽ� �ݺ�
        sq.AppendCallback(() =>
        {
            ImgFade();
        });
    }
}
