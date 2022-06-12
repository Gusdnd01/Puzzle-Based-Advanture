using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TalkManager : MonoBehaviour
{
    private RectTransform canvasTrm;
    private RectTransform talkPanel;
    private RectTransform talkTxt;
    private RectTransform NPC;

    private Text talkT;

    private int index;
    [SerializeField] private int k;
    void Start()
    {
        canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        talkPanel = canvasTrm.Find("TalkBox").GetComponent<RectTransform>();
        talkTxt = talkPanel.Find("TalkText").GetComponent<RectTransform>();
        NPC = canvasTrm.Find("NPCImage").GetComponent<RectTransform>();

        index = 0;

        talkT = talkTxt.GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index < k)
        {
            index++;
            NPC.DOAnchorPosX(0, 0.5f);

            Sequence seq = DOTween.Sequence();

            seq.Append(talkPanel.DOScaleY(1, 0.5f));
            seq.Append(talkPanel.DOScaleX(1, 0.5f));
            if(index == 1)
            {
                seq.Append(talkT.DOText("안녕", 0.1f));
            }
            else if (index == 2)
            {
                seq.Append(talkT.DOText("", 0));
                seq.Append(talkT.DOText("반가워", 0.3f));
            }
            else if (index == 3)
            {
                seq.Append(talkT.DOText("", 0));
                seq.Append(talkT.DOText("난 유니티가 좋아", 0.5f));
            }
            else
            {
                seq.Append(talkT.DOText("", 0));
                seq.Append(NPC.DOAnchorPosX(700, 0.5f));
                seq.Append(talkPanel.DOScaleX(0, 0.5f));
                seq.Append(talkPanel.DOScaleY(0, 0.5f));
                
            }
        }
    }
}
