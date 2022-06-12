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

        seq.Append(speech.DOText("깊은 산 속 아주 작은 마을", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("마을 이곳 저곳에서 일어나는 크고 작은 일들을 해결하는", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("나는 이 마을의 해결사이다.", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("마을 사람들의 소리가 들려온다.", 3f));
        seq.Append(speech.DOText("", 0));
        seq.Append(speech.DOText("오늘은 또 무슨 일이 일어났을까?", 3f));
    }
}
