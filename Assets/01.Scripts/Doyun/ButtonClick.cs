using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    private AudioSource _bgm;

    private void Start()
    {
        _bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    public void ClickBtn(string btnName)
    {
        if(btnName == "Start")
        {
            SceneManager.LoadScene("Chapter1");
        }
        if(btnName == "Quit")
        {
            Application.Quit();
        }
        if(btnName == "Continue")
        {
            //이어하는 코드 구현
        }
        if(btnName == "BGM")
        {
            if(_bgm.mute == false)
            {
                _bgm.mute = true;
            }
            else
            {
                _bgm.mute = false;
            }
        }
    }
}
