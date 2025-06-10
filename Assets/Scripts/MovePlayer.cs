using System;
using UnityEngine;


  // Unity�� Lifecycle �޼���
  // ��ü�� ����Ű�� �Է��� �޾Ƽ� �̵���Ų��.
public class MovePlayer : MonoBehaviour
{
    public float speed = 2;
    public float rotSpeed = 200;
    float xRot;
    float yRot;

    void Start()
    {
        print("��Ƴ�");

        // ȸ�� �ʱ�ȭ
        transform.rotation = Quaternion.identity;  // ȸ���� ���� ����
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
        // ���Ϸ� ȸ��: 0~360 �����ϱ� ���� ������ ���� �־ ȸ��
        // ���ʹϾ� ȸ��: 4����(x, y, z, w), ���Ϸ� ȸ���� ������ ������(Gimber Lock)�� ����
        // ������: ������ ȸ���� �ܺ��� ȸ���� ���� �������� �Ҿ������ ����

        // transform.eulerAngles = new Vector3(30, 45, 60);

        // ���Ϸ� ȸ���� ������ ����
        // transform.eulerAngles += new Vector3(1 * 0.1f, 1 * 0.1f, 0);

        // ���ʹϾ� ȸ�� ����
        //transform.Rotate(transform.up, 0.1f);     // �� �ڽ��� �� ���� ���� ȸ��
        //transform.Rotate(transform.right, 0.1f);  // �� �ڽ��� Rignt���� ���� ȸ��

        //Quaternion rotY90 = Quaternion.AngleAxis(0.1f, Vector3.up);  // ���ʹϾ� ����

        // Rotate �� ���� ���
        ////transform.rotation = transform.rotation * rotY90; // Vector3���� ����. Quaternion�� ���Ѵ�.
        //transform.rotation *= rotY90;

        //Vector3 rotDir = Input.mousePosition;
        //print(rotDir);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        print($"MouseX: {mouseX}, MouseY: {mouseY}"); 

        xRot += mouseX * rotSpeed * Time.deltaTime;
        yRot += mouseY * rotSpeed * Time.deltaTime; // ���ǵ� ���ؼ� ���콺 ȸ�� �ӵ� UP

        transform.rotation = Quaternion.Euler(-yRot, xRot, 0);

    }

    private void MoveWithTime()
    {
        // ���̽�ƽ�� ��ǲ�� ����� -1 ~ 1�� ����� �Լ�
        float horizontalInput = Input.GetAxis("Horizontal"); // �¿� ����Ű
        float verticalInput = Input.GetAxis("Vertical");     // ���� ����Ű

        // �Ϲ����� ���� ���� ���
        //Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        // ������Ʈ ���� ���� ���ǹ��
        Vector3 direction = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.position += direction * speed * Time.deltaTime;

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
