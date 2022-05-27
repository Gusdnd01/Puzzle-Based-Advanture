using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField] private GameObject poolObject;
    [SerializeField] private Transform content, hip;
    [SerializeField] private Queue<GameObject> poolQueue = new Queue<GameObject>();//�̰� ť
    public void Start()
    {
        for (int i = 0; i < 3; i++)//�⺻�� �����ϱ�
        {
            GameObject obj = Instantiate(poolObject, content);
            obj.name = $"Object {i}";
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
        StartCoroutine(Pool());
    }
    IEnumerator Pool()//��������
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
            GameObject obj;
            if (poolQueue.Count != 0)//Queue �� �Ⱥ������ ��
            {
                obj = poolQueue.Dequeue();//�ڵ������ ���ֱ�(Queue �ڷᱸ��)
            }
            else
            {
                obj = Instantiate(poolObject, content);//�����ϱ� �����ϱ�
                poolQueue.Enqueue(obj);
            }
            obj.SetActive(true);//������Ʈ ���ֱ�
            obj.transform.SetParent(hip);
            StartCoroutine(DePool(obj));
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator DePool(GameObject obj)//�־��ֱ�
    {
        yield return new WaitForSeconds(0.5f);
        obj.SetActive(false);//������Ʈ ���ֱ�
        obj.transform.SetParent(content);
        poolQueue.Enqueue(obj);//�ڵ������ �־��ֱ�(Queue �ڷᱸ��)
    }
}
