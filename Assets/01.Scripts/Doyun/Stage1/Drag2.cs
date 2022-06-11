using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Vector2 _InitPos;

    [Header("메인 로직 관련")]
    [SerializeField] private List<GameObject> freshPlants = new List<GameObject>();
    [SerializeField] private List<GameObject> notFreshPlants = new List<GameObject>();
    [SerializeField] private List<GameObject> needMark = new List<GameObject>();
    [SerializeField] private List<LayerMask> zeroSheepNeedLayer = new List<LayerMask>();
    private float distance = 1f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _InitPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        #region 레이캐스트
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, zeroSheepNeedLayer[0]);
        RaycastHit2D hit2 = Physics2D.Raycast(ray.origin, ray.direction, distance, zeroSheepNeedLayer[1]);
        RaycastHit2D hit3 = Physics2D.Raycast(ray.origin, ray.direction, distance, zeroSheepNeedLayer[2]);
        RaycastHit2D hit4 = Physics2D.Raycast(ray.origin, ray.direction, distance, zeroSheepNeedLayer[3]);
        RaycastHit2D hit5 = Physics2D.Raycast(ray.origin, ray.direction, distance, zeroSheepNeedLayer[4]);
        #endregion
        if (hit)
        {
            MainLogic(0);
        }
        if (hit2)
        {
            MainLogic(1);
        }
        if (hit3)
        {
            MainLogic(2);
        }
        if (hit4)
        {
            MainLogic(3);
        }
        if (hit5)
        {
            MainLogic(4);
        }
        this.transform.position = _InitPos;
    }

    private void MainLogic(int num)
    {
        notFreshPlants[num].SetActive(false);
        freshPlants[num].SetActive(true);
        needMark[num].SetActive(false);
    }
}
