using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;

    public GameData _gameData;

    float fadeAlpha = 0f;

    public void ButtonToStart()
    {
        StartCoroutine(FadeIn());

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

        DataController.Instance.gameData.isClear2 = false;
        DataController.Instance.gameData.isClear3 = false;
        DataController.Instance.gameData.isClear4 = false;
        DataController.Instance.gameData.isClear5 = false;
        DataController.Instance.SaveGameData();
        
    }

    public void LoadButton()
    {
        
    }


    IEnumerator FadeIn()
    {
        while(fadeAlpha <= 1f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(255, 255, 255, fadeAlpha);
            if (fadeAlpha >= 1f)
            {
                SceneManager.LoadScene("Play");
            }
        }
    }
}
