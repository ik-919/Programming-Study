using System;
using UnityEngine;


  // Unity의 Lifecycle 메서드
  // 물체를 방향키의 입력을 받아서 이동시킨다.
public class MovePlayer : MonoBehaviour
{
    public float speed = 2;
    public float rotSpeed = 200;
    float xRot;
    float yRot;

    void Start()
    {
        print("살아남");

        // 회전 초기화
        transform.rotation = Quaternion.identity;  // 회전이 없는 상태
        //transform.rotation = Quaternion.Euler(30, 45, 60);
    }

    void Update()
    {
        //MoveWithoutTime();

        MoveWithTime();

        RotatePlayer();
    }

    private void RotatePlayer()
    {
        // 오일러 회전: 0~360 이해하기 쉬운 각도의 값을 넣어서 회전
        // 쿼터니언 회전: 4원수(x, y, z, w), 오일러 회전의 단점인 짐벌락(Gimber Lock)을 보완
        // 짐벌락: 내부의 회전이 외부의 회전에 의해 자유도를 잃어버리는 현상

        // transform.eulerAngles = new Vector3(30, 45, 60);

        // 오일러 회전의 짐벌락 예시
        // transform.eulerAngles += new Vector3(1 * 0.1f, 1 * 0.1f, 0);

        // 쿼터니언 회전 예시
        //transform.Rotate(transform.up, 0.1f);     // 내 자신의 업 벡터 기준 회전
        //transform.Rotate(transform.right, 0.1f);  // 내 자신의 Rignt벡터 기준 회전

        //Quaternion rotY90 = Quaternion.AngleAxis(0.1f, Vector3.up);  // 쿼터니언 정의

        // Rotate 와 같은 기능
        ////transform.rotation = transform.rotation * rotY90; // Vector3와의 차이. Quaternion은 곱한다.
        //transform.rotation *= rotY90;

        //Vector3 rotDir = Input.mousePosition;
        //print(rotDir);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        print($"MouseX: {mouseX}, MouseY: {mouseY}"); 

        xRot += mouseX * rotSpeed * Time.deltaTime;
        yRot += mouseY * rotSpeed * Time.deltaTime; // 스피드 곱해서 마우스 회전 속도 UP

        transform.rotation = Quaternion.Euler(-yRot, xRot, 0);

    }

    private void MoveWithTime()
    {
        // 조이스틱의 인풋을 모방한 -1 ~ 1을 모방한 함수
        float horizontalInput = Input.GetAxis("Horizontal"); // 좌우 방향키
        float verticalInput = Input.GetAxis("Vertical");     // 상하 방향키

        // 일반적인 벡터 정의 방법
        //Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        // 오브젝트 기준 벡터 정의방법
        Vector3 direction = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.position += direction * speed * Time.deltaTime;

    }

    // 시간에 대한 고려 없는 Movw 매서드
    private void MoveWithoutTime()
    {
        bool isWKeyDown = Input.GetKey(KeyCode.W);
        bool isAKeyDown = Input.GetKey(KeyCode.A);
        bool isSKeyDown = Input.GetKey(KeyCode.S);
        bool isDKeyDown = Input.GetKey(KeyCode.D);

        if (isWKeyDown)
        {
            // 방향 정하기
            Vector3 direction = Vector3.forward * speed;        // 월드 좌표계 기준
            Vector3 localDirection = transform.forward * speed; // 로컬 좌표계 기준

            // 원드좌표의 내 현재위치 + 방향 벡터
            // transform.position = transform.position + direction;
            transform.position += localDirection;
        }
        else if (isAKeyDown)
        {
            Vector3 direction = Vector3.left * speed;
            Vector3 localDirection = -transform.right * speed; // 로컬 좌표계 기준

            transform.position += localDirection;
        }
        else if (isSKeyDown)
        {
            Vector3 direction = Vector3.back * speed;
            Vector3 localDirection = -transform.forward * speed; // 로컬 좌표계 기준

            transform.position += localDirection;
        }
        else if (isDKeyDown)
        {
            Vector3 direction = Vector3.right * speed;
            Vector3 localDirection = transform.right * speed; // 로컬 좌표계 기준

            transform.position += localDirection;
        }
    }
}
