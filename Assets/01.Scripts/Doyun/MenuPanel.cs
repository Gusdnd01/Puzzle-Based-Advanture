using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Image _menuPanel;

    private bool _isMenu = false;

    private void Update()
    {
        if (!_isMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            _isMenu = true;
            _menuPanel.gameObject.SetActive(true);

            Sequence sequene = DOTween.Sequence();

            sequene.Append(_menuPanel.rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f));
            sequene.Join(_menuPanel.DOFade(0.7f, 0.3f));
            sequene.Append(_menuPanel.rectTransform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f));
            sequene.Append(_menuPanel.rectTransform.DOScale(new Vector3(1, 1, 1), 0.3f));
        }
    }

    public void ExitBtn()
    {
        _isMenu = false;
        _menuPanel.rectTransform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }
}
