using System;
using UnityEngine;

// Cube를 CylinderA <-> CylinderB로 왕복 이동
public class MovementEx : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject cylinderA;
    public GameObject cylinderB;

    private GameObject currentTarget;

    void Start()
    {
        // 초기 목표를 B로 설정
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

        // 목표에 거의 도달했으면 반대 목표로 전환
        if (distance < 0.1f)
        {
            currentTarget = (currentTarget == cylinderB) ? cylinderA : cylinderB;
            return; // 도착 후 다음 프레임부터 이동 시작
        }

        transform.position += normalizedDir * speed * Time.deltaTime;
    }
}