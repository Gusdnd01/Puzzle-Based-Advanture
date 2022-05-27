using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //스타트 씬으로 이동하는 코드
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
