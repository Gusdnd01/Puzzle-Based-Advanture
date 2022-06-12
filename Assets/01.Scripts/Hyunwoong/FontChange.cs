using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FontChange : MonoBehaviour
{
    Text speech;

    private void Start()
    {
        speech = GetComponent<Text>(); 

        StartCoroutine(Speech(2.3f));
    }

    IEnumerator Speech(float sec)
    {
        yield return new WaitForSeconds(sec);

        Sequence seq = DOTween.Sequence();

        seq.Append(speech.DOText("���� �� �� ���� ���� ����", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("���� �̰� �������� �Ͼ�� ũ�� ���� �ϵ��� �ذ��ϴ�", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("���� �� ������ �ذ���̴�.", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("���� ������� �Ҹ��� ����´�.", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("������ �� ���� ���� �Ͼ����?", 3f));
    }
}
