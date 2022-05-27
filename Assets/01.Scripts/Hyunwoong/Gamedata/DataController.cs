using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataController : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if(!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    public string GameDataFileName = "StairOfHeaven.json";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    private void Start()
    {

        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            print("�ҷ����� ����");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }

        else
        {
            print("���� ����");
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        print("����Ϸ�");
        print("2�� " + gameData.isClear2);
        print("3�� " + gameData.isClear3);
        print("4�� " + gameData.isClear4);
        print("5�� " + gameData.isClear5);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
