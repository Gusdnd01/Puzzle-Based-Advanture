using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage1 : MonoBehaviour
{
    #region 아이템 선택 관련 코드
    [Header("아이템 선택 관련")]
    [SerializeField] private List<GameObject> noneSelectItem = new List<GameObject>();
    [SerializeField] private List<GameObject> Item = new List<GameObject>();
    [SerializeField] private LayerMask noneSelectItemLayer;
    [SerializeField] private LayerMask noneSelectItemLayer2;
    #endregion

    private float _distance = 1f;

    private void Update()
    {
        ItemSelect();
    }

    public void ItemSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _distance, noneSelectItemLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(ray.origin, ray.direction, _distance, noneSelectItemLayer2);

            if (hit)
            {
                noneSelectItem[0].SetActive(false);
                Item[0].SetActive(true);
            }
            if (hit2)
            {
                noneSelectItem[1].SetActive(false);
                Item[1].SetActive(true);
            }
        }
    }
}
