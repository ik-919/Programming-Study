using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ť�� 1, 2, 3, 4, 5 �� ������� 1�� �������� ����Ͽ�
// �Ǹ��� A ~ D ������ �̵��Ѵ�.
// �Ӽ�: ť�� �ӵ�, Ÿ�ٵ�

public class CubeManager2 : MonoBehaviour
{
    public float speed = 10;
    public float interval = 1;

    //public GameObject cube;
    //public GameObject cube1;
    //public GameObject cube2;
    //public GameObject cube3;
    //public GameObject cube4;

    public List<GameObject> cubes;

    public List<GameObject> targets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �ڷ�ƾ �޼��� 1 ����
        StartCoroutine(CoStart());
    }

    // Update is called once per frame
    void Update()
    {
        print("update");
    }

    // �ڷ�ƾ �޼���: ���μ��� ������ ��� ��ٸ� �� �ִ� ���....
    IEnumerator CoStart()
    {
        // �ڷ�ƾ �޼��� 2 ����
       
        // ����Ʈ ��� 
        foreach (var cube in cubes)
        {
            StartCoroutine(MoveCubeToTargets(cube, targets));
            yield return new WaitForSeconds(interval);  
        }

        //����ũ �̻�� �� �ڵ�

        //StartCoroutine(MoveCubeToTargets(cube, targets));
        //yield return new WaitForSeconds(interval);

        //StartCoroutine(MoveCubeToTargets(cube1, targets));
        //yield return new WaitForSeconds(interval);

        //StartCoroutine(MoveCubeToTargets(cube2, targets));
        //yield return new WaitForSeconds(interval);

        //StartCoroutine(MoveCubeToTargets(cube3, targets));
        //yield return new WaitForSeconds(interval);

        //StartCoroutine(MoveCubeToTargets(cube4, targets));

    }

    IEnumerator MoveCubeToTargets(GameObject cube, List<GameObject> targets)
    {
        int index = 0;

        print(cube.gameObject.name + "���");

        while(true)
        {
            // 1. A���� B�� ���ϴ� ���� -> ��������(ũ�Ⱑ 1�� ����) -> �÷��̾�� �������͸� ������
            Vector3 direction = targets[index].transform.position - cube.transform.position;
            // 2. ��������(ũ�Ⱑ 1�� ����)
            Vector3 normalizedDir = direction.normalized;

            // 3. �Ÿ����
            float distance = Vector3.Magnitude(direction);
            // ������ �� ���ΰ�? cylinderB ���� -> �Ÿ�
            print(distance);

            if (distance < 0.1f)
            {
                index++;
                if(index == targets.Count)
                {
                    break;
                }
            }

            // 4. �÷��̾�� �������͸� ������
            cube.transform.position += normalizedDir * speed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
