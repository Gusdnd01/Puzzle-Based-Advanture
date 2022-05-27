using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public bool Stage2 = false;
    public bool Stage3 = false;
    public bool Stage4 = false;
    public bool Stage5 = false;
    void Start()
    {
        if(DataController.Instance.gameData.isClear2 == true)
        {
            Stage2 = true;
        }
        if (DataController.Instance.gameData.isClear3 == true)
        {
            Stage3 = true;
        }
        if (DataController.Instance.gameData.isClear4 == true)
        {
            Stage4 = true;
        }
        if (DataController.Instance.gameData.isClear5 == true)
        {
            Stage5 = true;
        }
    }

    void Update()
    {
        
    }
}
