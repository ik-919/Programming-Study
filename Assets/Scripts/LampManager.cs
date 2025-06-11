using System.Collections;
using UnityEngine;

// RGB Lamp�� ������ ���� �ð��� ���� ���������� �����̰� �Ѵ�.
// �Ӽ�: �ð�, ���� ����
public class LampManager : MonoBehaviour
{
    public float time;
    public Renderer redLamp;
    public Renderer greenLamp;
    public Renderer blueLamp;
    Coroutine lampCoroutine;

    void Start()
    {
        // ó�� ���۽� ������ �˰� �ʱ�ȭ
        // _Color �� Shader�� Ư�� �Ӽ�: ������ ���ο� ���� ����
        redLamp.material.SetColor("_BaseColor", Color.black);
        greenLamp.material.SetColor("_BaseColor", Color.black);
        blueLamp.material.SetColor("_BaseColor", Color.black);

        lampCoroutine = StartCoroutine(CoStartLamp()); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(lampCoroutine); // �ڷ�ƾ ���� ����
        }
         
    }

    // �ڷ�ƾ�� ���, time �������� ����, �����ϴ� Lamp
    IEnumerator CoStartLamp()
    {
        while (true)
        {
            redLamp.material.SetColor("_BaseColor", Color.red);
            greenLamp.material.SetColor("_BaseColor", Color.black);
            blueLamp.material.SetColor("_BaseColor", Color.black);
            yield return new WaitForSeconds(2);

            redLamp.material.SetColor("_BaseColor", Color.black);
            greenLamp.material.SetColor("_BaseColor", Color.green);
            yield return new WaitForSeconds(3);

            greenLamp.material.SetColor("_BaseColor", Color.black);
            yield return new WaitForSeconds(1);

            blueLamp.material.SetColor("_BaseColor", Color.blue);
            yield return new WaitForSeconds(1);

            blueLamp.material.SetColor("_BaseColor", Color.black);

        }


    }

}
