using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �Ǹ� Sphere�� Capsule A ~ D �� �ʱ� ��ġ�� �̵��ϴµ�
// * ���� : �̵��� interval�� 1��, �ʱ� ��ġ���� ����
// �Ӽ�: Capsule���� transforms, interval, originPos(�ʱ���ġ)
public class LerpMovement2 : MonoBehaviour
{
    public List<Transform> capsules;
    public Transform originPos;
    public float elapsedTime;
    [SerializeField] float time;

    void Start()
    {
        originPos.position = capsules[0].position;
        StartCoroutine(CoMove());

    }

    void Update()
    {
     
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            for (int i = 0; i < capsules.Count - 1; i++)
            {
           
                    Vector3 startPoint = capsules[i].position;
                    Vector3 endPoint = capsules[i + 1].position;


                    while (elapsedTime < time)
                    {
                        transform.position = Vector3.Lerp(startPoint, endPoint, elapsedTime / time);

                        elapsedTime += Time.deltaTime;

                        yield return null;
                    }

                    transform.position = endPoint;
                
            }

            Vector3 lastPoint = capsules[capsules.Count - 1].position;
            Vector3 firstPoint = capsules[0].position;


            while (elapsedTime < time)
            {
                transform.position = Vector3.Lerp(lastPoint, firstPoint, elapsedTime / time);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = firstPoint;
        }
    }
    
}
