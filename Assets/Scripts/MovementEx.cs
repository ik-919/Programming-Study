using System;
using UnityEngine;

// Cube�� CylinderA <-> CylinderB�� �պ� �̵�
public class MovementEx : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject cylinderA;
    public GameObject cylinderB;

    private GameObject currentTarget;

    void Start()
    {
        // �ʱ� ��ǥ�� B�� ����
        currentTarget = cylinderB;
    }

    void Update()
    {
        MoveBetweenAandB();
    }

    private void MoveBetweenAandB()
    {
        Vector3 direction = currentTarget.transform.position - transform.position;
        Vector3 normalizedDir = direction.normalized;

        float distance = direction.magnitude;

        // ��ǥ�� ���� ���������� �ݴ� ��ǥ�� ��ȯ
        if (distance < 0.1f)
        {
            currentTarget = (currentTarget == cylinderB) ? cylinderA : cylinderB;
            return; // ���� �� ���� �����Ӻ��� �̵� ����
        }

        transform.position += normalizedDir * speed * Time.deltaTime;
    }
}