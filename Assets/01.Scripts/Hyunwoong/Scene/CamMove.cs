using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CamMove : MonoBehaviour
{
    private float speed = 4f;

    private Rigidbody2D rb;

    [SerializeField] private Image _fadePanel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        yield return new WaitForSeconds(sec);
        _fadePanel.DOFade(1f, 2f);

        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(1);
    }
}
