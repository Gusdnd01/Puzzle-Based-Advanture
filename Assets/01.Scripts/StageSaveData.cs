using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSaveData : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;

    public PlayerData p;
    private void Start()
    {
        string json = PlayerPrefs.GetString("Json", null);

        JObject obj = JObject.Parse(json);
        float posX = (float)obj["playerPosX"];
        float posY = (float)obj["playerPosY"];

        Debug.Log($"{posX}/{posY}");

        if(json == null)
        {
            p = new PlayerData() { playerPosX = 0.0f, playerPosY = 0.0f };
        }
        else
        {
            p = JsonUtility.FromJson<PlayerData>(json);
        }
       
        //StartCoroutine(JsonAutoSave());
    }

    /*IEnumerator JsonAutoSave()
    {
        while (true)
        {
                p = new PlayerData() { playerPosX = _playerPos.position.x, playerPosY = _playerPos.position.y };
                string json = JsonUtility.ToJson(p);
                Debug.Log(json);
                PlayerPrefs.SetString("Json", json);
                yield return new WaitForSecondsRealtime(30f);
        }
    }*/

}
