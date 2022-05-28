using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurtainMove : MonoBehaviour
{
    private Transform curtainTrm;
    [SerializeField] private float moveTrm;

    private void Start()
    {
        curtainTrm = GetComponent<Transform>();

        Sequence seq = DOTween.Sequence();

        seq.Append(curtainTrm.DOMoveY(moveTrm, 2f));
    }
}
