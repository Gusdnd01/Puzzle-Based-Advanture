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
            //��ŸƮ ������ �̵��ϴ� �ڵ�
        }
        if(btnName == "Quit")
        {
            Application.Quit();
        }
        if(btnName == "Continue")
        {
            //�̾��ϴ� �ڵ� ����
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
