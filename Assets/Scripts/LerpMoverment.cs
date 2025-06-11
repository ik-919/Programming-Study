using System.Collections;
using UnityEngine;

// Lerp �޼��带 ����ؼ� Sphere�� 3�ʵ��� A���� B�������� �̵� ��Ų��.
// �Ӽ�: �ð�, A����, B����
public class LerpMovement : MonoBehaviour
{
    [Range(0, 1f)] public float ration;
    [SerializeField] float time;
    public float elapsedTime;
    public Transform pointA;
    public Transform pointB;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CoMoveAToB(pointA.position, pointB.position, time));
    }

    // Update is called once per frame
    void Update()
    {
        //// 1. ������ �ð��� ���
        //elapsedTime += Time.deltaTime;

        //if (elapsedTime > time)
        //    elapsedTime = 0;

        //Vector3 position = Vector3.Lerp(pointA.position, pointB.position, elapsedTime / time);
        //transform.position = position;
    }

    //A���� B���� �� �ڽ��� �̵�
    IEnumerator CoMoveAToB(Vector3 a, Vector3 b, float t)
    {
        while (true)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > time)
            { 
                elapsedTime = 0;
                break;
            }

            Vector3 position = Vector3.Lerp(a, b, elapsedTime / t);
            transform.position = position;

            yield return new WaitForEndOfFrame();
        }
    }
}
