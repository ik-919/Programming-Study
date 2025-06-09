using UnityEngine;


  // Unity�� Lifecycle �޼���
  // ��ü�� ����Ű�� �Է��� �޾Ƽ� �̵���Ų��.
public class MovePlayer : MonoBehaviour
{
    public float speed = 2;

    void Start()
    {
        print("��Ƴ�");
    }

    void Update()
    {
        //MoveWithoutTime();

        MoveWithTime();
    }

    private void MoveWithTime()
    {
        // ���̽�ƽ�� ��ǲ�� ����� -1 ~ 1�� ����� �Լ�
        float horizontalInput = Input.GetAxis("Horizontal"); // �¿� ����Ű
        float verticalInput = Input.GetAxis("Vertical");     // ���� ����Ű

        Vector3 deirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += deirection * speed * Time.deltaTime;
    }

    // �ð��� ���� ��� ���� Movw �ż���
    private void MoveWithoutTime()
    {
        bool isWKeyDown = Input.GetKey(KeyCode.W);
        bool isAKeyDown = Input.GetKey(KeyCode.A);
        bool isSKeyDown = Input.GetKey(KeyCode.S);
        bool isDKeyDown = Input.GetKey(KeyCode.D);

        if (isWKeyDown)
        {
            // ���� ���ϱ�
            Vector3 direction = Vector3.forward * speed;        // ���� ��ǥ�� ����
            Vector3 localDirection = transform.forward * speed; // ���� ��ǥ�� ����

            // ������ǥ�� �� ������ġ + ���� ����
            // transform.position = transform.position + direction;
            transform.position += localDirection;
        }
        else if (isAKeyDown)
        {
            Vector3 direction = Vector3.left * speed;
            Vector3 localDirection = -transform.right * speed; // ���� ��ǥ�� ����

            transform.position += localDirection;
        }
        else if (isSKeyDown)
        {
            Vector3 direction = Vector3.back * speed;
            Vector3 localDirection = -transform.forward * speed; // ���� ��ǥ�� ����

            transform.position += localDirection;
        }
        else if (isDKeyDown)
        {
            Vector3 direction = Vector3.right * speed;
            Vector3 localDirection = transform.right * speed; // ���� ��ǥ�� ����

            transform.position += localDirection;
        }
    }
}
