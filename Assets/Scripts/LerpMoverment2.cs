using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시작이 되면 Sphere가 Capsule A ~ D 의 초기 위치로 이동하는데
// * 조건 : 이동시 interval은 1초, 초기 위치에서 시작
// 속성: Capsule들의 transforms, interval, originPos(초기위치)
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
