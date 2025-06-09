using UnityEngine;


  // Unity의 Lifecycle 메서드
  // 물체를 방향키의 입력을 받아서 이동시킨다.
public class MovePlayer : MonoBehaviour
{
    public float speed = 2;

    void Start()
    {
        print("살아남");
    }

    void Update()
    {
        //MoveWithoutTime();

        MoveWithTime();
    }

    private void MoveWithTime()
    {
        // 조이스틱의 인풋을 모방한 -1 ~ 1을 모방한 함수
        float horizontalInput = Input.GetAxis("Horizontal"); // 좌우 방향키
        float verticalInput = Input.GetAxis("Vertical");     // 상하 방향키

        Vector3 deirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += deirection * speed * Time.deltaTime;
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
